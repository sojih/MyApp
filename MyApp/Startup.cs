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
            // => 에러 발생으로 인해 이 코드를 사용(option으로 endPointRounting을 설정)
            // https://stackoverflow.com/questions/57684093/using-usemvc-to-configure-mvc-is-not-supported-while-using-endpoint-routing
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddRazorPages();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // http 프로세싱 pipeLine을 설정해주는 메서드
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

            // 미들웨어 추가 - 앱 실행 시 .NET Core 안에서 wwwroot 폴더 안 파일을 인지함
            app.UseStaticFiles();
            // 라우팅 설정
            app.UseMvc(routes =>
            {
                // 라우트 매핑
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Student}/{id?}");
                // controller/action/선택적 매개변수
                // : MVC에서는 url의 패턴을 보고 라우팅을 결정
                // ex) localhost:57939/Home/Student 이나
                // localhost:57939/Home/Student/2
                // => ?가 있으므로 선택적인 매개변수가 됨 -> 쳐도 안쳐도 됨

                // 도메인주소를 쳤을때 메인 화면 설정 - 첫 화면은 Student.cshtml이 됨

                //라우팅 매핑 후 하나 더 설정해야함
                // ConfigureServices함수에 mvc를 service collection container에 추가시켜야함 => 프로젝트 안에 mvc시스템이 주입됨
            });
        }

        private RequestDelegate async(Action<object> p)
        {
            throw new NotImplementedException();
        }
    }
}
