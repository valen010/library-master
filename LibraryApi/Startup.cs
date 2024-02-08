using Library.DataAccess;
using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete;
using Library.Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace LibraryApi
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
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<ILibraryBase<Category>, LibraryBase<Category>>();
            services.AddScoped<ILibraryBase<Book>, LibraryBase<Book>>();
            services.AddScoped<ILibraryBase<Member>, LibraryBase<Member>>();
            services.AddScoped<IMemberRepository, MemberRespository>();
            services.AddScoped<ILibraryBase<BookStatus>, LibraryBase<BookStatus>>();
            services.AddScoped<IBookStatusRepository, BookStatusRepository>();
            services.AddScoped<LibraryContext>();
           // services.AddMvcCore().AddNewtonsoftJson(x => { x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
              
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger/.json", "v1");
                   // options.DefaultModelRendering(ModelRendering.Model);
                   // options.DefaultModelsExpandDepth(1);
                    options.RoutePrefix=string.Empty;
                });
               
              

            }
         
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
