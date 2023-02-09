using Microsoft.AspNetCore.Builder;

namespace ProyextoZ
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerEndpoint(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            return app;
        }
    }
}
