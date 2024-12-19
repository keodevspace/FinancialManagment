using FinancialManagement.Api.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinancialManagement.Api
    {
    public class Startup
        {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
            {
            _configuration = configuration;
            }

        public void ConfigureServices(IServiceCollection services)
            {
            // Adicionar configura��o do banco de dados (Oracle)
            services.AddDatabaseConfiguration(_configuration);

            // Adicionar servi�os de aplica��o
            services.AddApplicationServices();

            // Configurar autentica��o (se necess�rio)
            services.AddAuthenticationConfiguration();

            // Configurar CORS
            services.AddCorsConfiguration();

            // Adicionar Swagger
            services.AddSwaggerConfiguration();

            // Adicionar Controllers
            services.AddControllers();
            }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
            if (env.IsDevelopment())
                {
                // Ativar Swagger no ambiente de desenvolvimento
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinancialManagement API v1"));
                }

            // Configurar CORS
            app.UseCors("AllowAll");

            // Ativar autentica��o
            app.UseAuthentication();

            // Ativar autoriza��o
            app.UseAuthorization();

            // Configurar os middlewares da aplica��o
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            }
        }
    }
