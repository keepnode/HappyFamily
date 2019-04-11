using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;

namespace HappyFamily.UserAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            /** Polly用法
             * 1.指定要处理的异常或者指定需要处理什么样的错误返回
             * 2.指定重试次数和重试策略
             * 3.执行具体任务
             * 参考例子：https://www.cnblogs.com/willick/p/polly.html
             * *
             */
            Policy.Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.BadGateway)
                .Retry(3, (exception, retryCount, context) => { Console.WriteLine($"开始第 {retryCount} 次重试。"); })
                .Execute(ExecuteMockRequest);
        }

        static HttpResponseMessage ExecuteMockRequest()
        {
            //模拟网络请求
            Console.WriteLine("正在执行网络请求。。。");
            Thread.Sleep(3000);
            //模拟网络错误
            return new HttpResponseMessage(HttpStatusCode.BadGateway);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}