using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using transaction_service.database;
using transaction_service.database.Repository;
using transaction_service.domain.Interfaces;
using transaction_service.services;
using transaction_service.services.Services;
using transaction_service.services.Services.Transactions;
using transaction_service.services.Services.Transactions.Mapping;
using transaction_service.web.ErrorHandling;

namespace transaction_service.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFileUploader, FileUploader>();
            services.AddScoped<IFileParserFactory, FileParserFactory>();
            services.AddScoped<ITransactionsService, TransactionsService>();
            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            //Add database
            services
                .AddDbContext<EFDbContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("TransactionConnection"),
                        builder => builder.MigrationsAssembly("transaction-service.database")));

            // AutoMapper
            services.AddAutoMapper(typeof(TransactionMap));


            //Add Json converting rules
            services.AddMvc().AddNewtonsoftJson(obj =>
            {
                obj.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            // Add logging
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EFDbContext dbContext, ILoggerFactory loggerFactory)
        {
            // Error handling
            app.UseMiddleware<ExceptionMiddleware>();

            // Logging
            loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=FileUpload}/{action=Index}");
            });

            //create Db if it not exist
            dbContext.DatabaseCheckCreate();
        }
    }
}
