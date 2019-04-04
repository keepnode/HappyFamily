﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using RazorEngine;
using RazorEngine.Templating;

namespace SugarCodeGeneration.Codes
{
    /// <summary>
    /// 生成所需要的代码
    /// </summary>
    public class Methods
    {
        public static Dictionary<string, string> ProjectIds = new Dictionary<string, string>();
        public static string GetCurrentProjectPath
        {

            get
            {
                return Environment.CurrentDirectory.Replace(@"\bin\Debug\netcoreapp2.2", "");
            }
        }
        public static string GetSlnPath
        {

            get
            {
                var path = Directory.GetParent(GetCurrentProjectPath).FullName;
                return path;

            }
        }

        public static void AddRef(string projectName, string refProjectName)
        {

            var xmlPath = GetSlnPath + @"\" + projectName + @"\" + projectName + ".csproj";

            var xml = File.ReadAllText(xmlPath, System.Text.Encoding.UTF8);
            if (xml.Contains(refProjectName)) return;
            var firstLine = System.IO.File.ReadLines(xmlPath, System.Text.Encoding.UTF8).First();
            var newXml = xml.Replace(firstLine, "").TrimStart('\r').TrimStart('\n');
            XDocument xe = XDocument.Load(xmlPath);
            var root = xe.Root;

            XElement itemGroup = new XElement("ItemGroup");
            var refItem = new XElement("ProjectReference", new XAttribute("Include", string.Format(@"..\{0}\{0}.csproj", refProjectName)));
            refItem.Add(new XElement("Name", refProjectName));
            refItem.Add(new XElement("Project", "{" + ProjectIds[refProjectName] + "}"));
            itemGroup.Add(refItem);
            root.Add(itemGroup);

            newXml = xe.ToString().Replace("xmlns=\"\"", "");
            xe = XDocument.Parse(newXml);
            xe.Save(xmlPath);
        }

        public static void AddCsproj(string classPath, string projectName)
        {
            CreateProject(projectName);
            var classDirectory = Methods.GetSlnPath + "\\" + projectName + "\\" + classPath.TrimStart('\\');
            if (FileHelper.IsExistDirectory(classDirectory) == false)
            {
                FileHelper.CreateDirectory(classDirectory);
            }
            var files = Directory.GetFiles(classDirectory).ToList().Select(it => classPath + "\\" + Path.GetFileName(it));
            var xmlPath = GetSlnPath + @"\" + projectName + @"\" + projectName + ".csproj";

            var xml = File.ReadAllText(xmlPath, System.Text.Encoding.UTF8);
            var firstLine = System.IO.File.ReadLines(xmlPath, System.Text.Encoding.UTF8).First();
            var newXml = xml.Replace(firstLine, "").TrimStart('\r').TrimStart('\n');
            XDocument xe = XDocument.Load(xmlPath);
            //var itemGroup = xe.Root.Elements().Where(it => it.Name.LocalName == "ItemGroup" && it.Elements().Any(y => y.Name.LocalName == "Compile")).First();
            //var compieList = itemGroup.Elements().ToList();
            //var noAddFiles = files.Where(it => !compieList.Any(f => it.Equals(f.Attribute("Include").Value, StringComparison.CurrentCultureIgnoreCase))).ToList();
            //if (noAddFiles.Any())
            //{
            //    foreach (var item in noAddFiles)
            //    {
            //        var addItem = new XElement("Compile", new XAttribute("Include", item.TrimStart('\\')));
            //        itemGroup.AddFirst(addItem);
            //    }
            //}
            newXml = xe.ToString().Replace("xmlns=\"\"", "");
            xe = XDocument.Parse(newXml);
            xe.Save(xmlPath);
        }

        public static void RenameSln(string solutionName)
        {
            var slns = Directory.GetFiles(GetSlnPath).Where(it => it.Contains(".sln"));
            if (slns.Any())
            {
                File.Move(slns.First(), GetSlnPath+"\\"+solutionName+".sln");
            }
        }

        public static void CreateBLL(string templatePath, string savePath, List<string> tables, string classNamespace)
        {

            string template = System.IO.File.ReadAllText(templatePath); //从文件中读出模板内容
            string templateKey = "bll"; //取个名字
            foreach (var item in tables)
            {
                BLLParameter model = new BLLParameter()
                {
                    Name = item,
                    ClassNamespace = classNamespace
                };
                var result = Engine.Razor.RunCompile(template, templateKey, model.GetType(), model);
                var cp = savePath + "\\" + item + "Manager.cs";
                if (FileHelper.IsExistFile(cp) == false)
                    FileHelper.CreateFile(cp, result, System.Text.Encoding.UTF8);
            }
        }

        public static void CreateDbContext(string templatePath, string savePath, object model)
        {
            string template = System.IO.File.ReadAllText(templatePath); //从文件中读出模板内容
            string templateKey = "dbcontext"; //取个名字
            var result = Engine.Razor.RunCompile(template, templateKey, model.GetType(), model);
            FileHelper.CreateFile(savePath, result, System.Text.Encoding.UTF8);
        }


        public static void CreateProject(string name)
        {
            var templatePath = GetCurrentProjectPath + "/Template/Project.txt";
            string projectId = Guid.NewGuid().ToString();
            string project = System.IO.File.ReadAllText(templatePath).Replace("@pid", projectId).Replace("@AssemblyName", name); //从文件中读出模板内容
            var projectPath = GetSlnPath + "\\" + name + "\\" + name + ".csproj";
            var projectDic = GetSlnPath + "\\" + name + "\\";
            var binDic = GetSlnPath + "\\" + name + "\\bin";
            if (!FileHelper.IsExistFile(projectPath))
            {

                if (!FileHelper.IsExistDirectory(projectDic))
                {
                    FileHelper.CreateDirectory(projectDic);
                }
                if (!FileHelper.IsExistDirectory(binDic))
                {
                    FileHelper.CreateDirectory(binDic);
                }
                FileHelper.CreateFile(projectPath, project, System.Text.Encoding.UTF8);
                FileHelper.CreateFile(projectDic + "\\class1.cs", "", System.Text.Encoding.UTF8);
                File.Copy(GetCurrentProjectPath + "/Template/nuget.txt", projectDic + "packages.config");
                ProjectIds.Add(name, projectId);
                AppendProjectToSln(projectId, name);
            }
        }

        public static void AppendProjectToSln(string projectId, string projectName)
        {

            var slns = Directory.GetFiles(GetSlnPath).Where(it => it.Contains(".sln"));
            if (slns.Any())
            {
                var sln = slns.First();
                var templatePath = GetCurrentProjectPath + "/Template/sln.txt";
                string appendText = System.IO.File.ReadAllText(templatePath)
                    .Replace("@pid", projectId)
                    .Replace("@name", projectName)
                    .Replace("@sid", Guid.NewGuid().ToString());
                FileStream fs = new FileStream(sln, FileMode.Append);
                var sw = new StreamWriter(fs);
                sw.WriteLine(appendText);
                sw.Close();
                fs.Close();
            }

        }
    }
}
