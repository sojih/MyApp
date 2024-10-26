using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
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
            //services.AddMvc();
            // Warning MVC1005 Using 'UseMvc' to configure MVC is not supported while using Endpoint Routing.
            // To continue using 'UseMvc', please set 'MvcOptions.EnableEndpointRouting = false' inside 'ConfigureServices'.MyApp   D:\itStudy\Study_ASP\MyApp\MyApp\Startup.cs 65  Active
            // => ���� �߻����� ���� �� �ڵ带 ���(option���� endPointRounting�� ����)
            // https://stackoverflow.com/questions/57684093/using-usemvc-to-configure-mvc-is-not-supported-while-using-endpoint-routing
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddRazorPages();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // http ���μ��� pipeLine�� �������ִ� �޼���
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});

            // �̵���� �߰� - �� ���� �� .NET Core �ȿ��� wwwroot ���� �� ������ ������
            app.UseStaticFiles();
            // ����� ����
            app.UseMvc(routes =>
            {
                // ���Ʈ ����
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Student}/{id?}");
                // controller/action/������ �Ű�����
                // : MVC������ url�� ������ ���� ������� ����
                // ex) localhost:57939/Home/Student �̳�
                // localhost:57939/Home/Student/2
                // => ?�� �����Ƿ� �������� �Ű������� �� -> �ĵ� ���ĵ� ��

                // �������ּҸ� ������ ���� ȭ�� ���� - ù ȭ���� Student.cshtml�� ��

                //����� ���� �� �ϳ� �� �����ؾ���
                // ConfigureServices�Լ��� mvc�� service collection container�� �߰����Ѿ��� => ������Ʈ �ȿ� mvc�ý����� ���Ե�
            });
        }

        private RequestDelegate async(Action<object> p)
        {
            throw new NotImplementedException();
        }
    }
}
