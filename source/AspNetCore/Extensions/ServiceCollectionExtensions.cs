using DotNetCore.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCore.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthenticationJwtBearer(this IServiceCollection services)
        {
            var jsonWebTokenSettings = services.BuildServiceProvider().GetRequiredService<JsonWebTokenSettings>();

            void JwtBearer(JwtBearerOptions options)
            {
                options.TokenValidationParameters = jsonWebTokenSettings.TokenValidationParameters();
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
        }

        public static void AddControllersDefault(this IServiceCollection services)
        {
            static void MvcOptions(MvcOptions options)
            {
                options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            }

            static void JsonOptions(JsonOptions options)
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }

            services.AddControllers(MvcOptions).AddJsonOptions(JsonOptions);
        }

        public static void AddFileExtensionContentTypeProvider(this IServiceCollection services)
        {
            services.AddSingleton<IContentTypeProvider, FileExtensionContentTypeProvider>();
        }

        public static void AddSpaStaticFiles(this IServiceCollection services, string rootPath)
        {
            services.AddSpaStaticFiles(options => options.RootPath = rootPath);
        }

        public static void ConfigureFormOptions(this IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
            });
        }
    }
}
