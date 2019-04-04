﻿using SugarCodeGeneration;
using SugarCodeGeneration.Codes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HappyFamily.CodeGenerator
{
    /// <summary>
    /// F5直接运行生成项目
    /// </summary>
    /// <param name="args"></param>
    class Program
    {

        /***3个必填参数***/

        //如果你不需要自定义，直接配好数据库连接，F5运行项目
        const SqlSugar.DbType dbType = SqlSugar.DbType.SqlServer;
        /// <summary>
        /// 连接字符串
        /// </summary>
        const string connectionString = "Server=.;Initial Catalog=happyfamilydb;User ID=sa;Password=heihei;";
        /// <summary>
        ///解决方案名称
        /// </summary>
        const string SolutionName = "HappyFamily";

        /***3个必填参数***/




        /// <summary>
        /// 执行生成
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /***连接数据库***/
            var db = GetDB();


            /***生成实体***/ //CodeFirst可以注释生成实体

            //配置参数
            string classProjectName = SolutionName + ".Enties";//实体类项目名称
            string classPath = "DbModels";//生成的目录
            string classNamespace = "HappyFamily.Enties";//实体命名空间
            var classDirectory = Methods.GetSlnPath + "\\" + classProjectName + "\\" + classPath.TrimStart('\\');
            //执行生成
            GenerationClass(classProjectName, classPath, classNamespace, classDirectory);
            Print("实体创建成功");





            /***生成DbContext***/

            //配置参数
            var contextProjectName = SolutionName + ".BusinessCore";//DbContext所在项目
            var contextPath = "DbCore";//dbcontext存储目录
            var savePath = Methods.GetSlnPath + "\\" + contextProjectName + "\\" + contextPath + "\\DbContext.cs";//具体文件名
            var tables = db.DbMaintenance.GetTableInfoList().Select(it => it.Name).ToList();
            //执行生成
            GenerationDContext(contextProjectName, contextPath, savePath, tables, classNamespace);
            Print("DbContext创建成功");





            /***生成BLL***/

            //配置参数
            var bllProjectName2 = SolutionName + ".BusinessCore";//具体项目
            var bllPath2 = "BaseCore";//文件目录
            var savePath2 = Methods.GetSlnPath + "\\" + bllProjectName2 + "\\" + bllPath2;//保存目录
            var tables2 = db.DbMaintenance.GetTableInfoList().Select(it => it.Name).ToList();
            //执行生成
            GenerationBLL(bllProjectName2, bllPath2, savePath2, tables2, classNamespace);
            Print("BLL创建成功");





            /***修改解决方案***/
            UpdateCsproj();
            Methods.RenameSln(SolutionName);
            Print("项目解决方案修改成功");


            /***添加项目引用***/
            Methods.AddRef(bllProjectName2, classProjectName);
            Print("引用添加成功");

            //如何使用创建好的业务类（注意 SchoolManager 不能是静态的）
            //SchoolManager sm = new SchoolManager();
            //sm.GetList();
            //sm.StudentDb.AsQueryable().Where(it => it.Id == 1).ToList();
            //sm.Db.Queryable<Student>().ToList();

        }


        /// <summary>
        /// 生成BLL
        /// </summary>
        private static void GenerationBLL(string bllProjectName, string bllPath, string savePath, List<string> tables, string classNamespace)
        {
            var templatePath = Methods.GetCurrentProjectPath + "\\Template\\Bll.txt";//bll模版地址
            //下面代码不动
            Methods.CreateBLL(templatePath, savePath, tables, classNamespace);
            AddTask(bllProjectName, bllPath);
        }



        /// <summary>
        /// 生成DbContext
        /// </summary>
        private static void GenerationDContext(string contextProjectName, string contextPath, string savePath, List<string> tables, string classNamespace)
        {
            var templatePath = Methods.GetCurrentProjectPath + "\\Template\\DbContext.txt";//dbcontexts模版文件
            //下面代码不动
            var model = new DbContextParameter
            {
                ConnectionString = connectionString,
                DbType = dbType,
                Tables = tables,
                ClassNamespace = classNamespace
            };
            Methods.CreateDbContext(templatePath, savePath, model);
            AddTask(contextProjectName, contextPath);
        }

        /// <summary>
        /// 生成实体类
        /// </summary>
        private static void GenerationClass(string classProjectName, string classPath, string classNamespace, string classDirectory)
        {
            //连接数据库
            var db = GetDB();
            //下面代码不动
            db.DbFirst.IsCreateAttribute().CreateClassFile(classDirectory, classNamespace);
            AddTask(classProjectName, classPath);
        }

        #region 辅助方法
        /// <summary>
        ///  修改解决方案
        /// </summary>
        private static void UpdateCsproj()
        {
            foreach (var item in CsprojList)
            {
                item.Start();
                item.Wait();
            }
        }
        private static void Print(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(message);
            Console.WriteLine("");
        }

        private static void AddTask(string bllProjectName, string bllPath)
        {
            var task = new Task(() =>
            {
                Methods.AddCsproj(bllPath, bllProjectName);
            });
            CsprojList.Add(task);
        }
        static List<Task> CsprojList = new List<Task>();
        static SqlSugar.SqlSugarClient GetDB()
        {

            return new SqlSugar.SqlSugarClient(new SqlSugar.ConnectionConfig()
            {
                DbType = dbType,
                ConnectionString = connectionString,
                IsAutoCloseConnection = true,
                InitKeyType = SqlSugar.InitKeyType.Attribute
            });
        }
        #endregion
    }
}
