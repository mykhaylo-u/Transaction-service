using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using transaction_service.database;
using transaction_service.domain.Interfaces;
using transaction_service.services;
using transaction_service.services.Services;
using transaction_service.services.Services.Transactions;
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
            services.AddControllersWithViews();
            services.AddScoped<IFileUploader, FileUploader>();
            services.AddScoped<IFileParserFactory, FileParserFactory>();
            services.AddScoped<ITransactionsService, TransactionsService>();

            //Add database
            services
                .AddDbContext<ITransactionDbContext, TransactionDbContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("TransactionConnection"),
                        builder => builder.MigrationsAssembly("transaction-service.database")));

            // AutoMapper
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ITransactionDbContext dbContext)
        {
            // Error handling
            app.UseMiddleware<ExceptionMiddleware>();

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

            dbContext.DatabaseCheckCreate();
        }
    }
}
