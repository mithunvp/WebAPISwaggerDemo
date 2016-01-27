using Swashbuckle.Application;
using System.Web.Http;
using WebActivatorEx;
using WebAPISwaggerDemo;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebAPISwaggerDemo
{   
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration.EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Books Swagger Demo Api");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\WebAPISwaggerDemo.XML",
                                             System.AppDomain.CurrentDomain.BaseDirectory));                        
                    })
                    .EnableSwaggerUi();
        }
    }
}