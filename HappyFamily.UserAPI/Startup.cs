using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace HappyFamily.UserAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //添加options
            services.AddOptions();
            
            #region swagger配置
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "HappyFamily API",
                    Version = "v1",
                    Description = ".Net Core快速开发框架，后台API",
                    Contact = new Contact
                    {
                        Email = "ibliveicando@gmail.com",
                        Name = "keepnode",
                        Url = "https://github.com/keepnode"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion

            #region CsRedis配置

            var csRedisConfigurationList = Configuration.GetSection("RedisConfigurations").Get<List<Models.RedisConfiguration>>();
            
            int csRedisCount = csRedisConfigurationList.Count;
            var csRedisConfigurationArrayList = new string[csRedisCount];
            int tempRedisConfigurationIndex = 0;
            foreach (var item in csRedisConfigurationList)
            {
                csRedisConfigurationArrayList[tempRedisConfigurationIndex] = $"{item.Ip}:{item.Port},password={item.Password},defaultDatabase={item.DefaultDatabase},poolsize={item.PoolSize}";
            }
            //配置Redis客户端
            var csRedisClient=new CSRedis.CSRedisClient(string.Empty,csRedisConfigurationArrayList);
            //初始化RedisHelper
            RedisHelper.Initialization(csRedisClient);
            //注册MVC分布式缓存
            services.AddSingleton<IDistributedCache>(
                new Microsoft.Extensions.Caching.Redis.CSRedisCache(RedisHelper.Instance));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //在开发环境使用swagger，线上不使用
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HappyFamily API");
                    c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();


            app.UseMvc();
        }
    }
}
