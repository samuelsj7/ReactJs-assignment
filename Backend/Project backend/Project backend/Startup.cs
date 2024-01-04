using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Project_backend.Data;
using Project_backend.Repositories.Interfaces;
using Project_backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_backend
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
            services.AddCors(c=>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });



            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings
            .ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options =>options.SerializerSettings.ContractResolver
            =new DefaultContractResolver()
            );

            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("Conn");

            services.AddDbContextPool<DBService>(
                options => options.UseSqlServer(connectionString)
                );
            //Enable Repository
            services.AddScoped<IStudent, StudentRepo>();
            services.AddScoped<ITeacher, TeacherRepo>();
            services.AddScoped<ISubject, SubjectRepo>();
            services.AddScoped<IClassroom, ClassroomRepo>();
            services.AddScoped<IAllocateClassroom, AllocateClassRoomRepo>();
            services.AddScoped<IAllocateSubject, AllocateSubjectRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
