using HappyFamily.Enties;
using SqlSugar;
using System;
using System.Collections.Generic;
public class Sys_OrganizeManager : DbContext<Sys_Organize>
{
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="fullName"></param>
    /// <param name="mobilePhone"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="totalNumber"></param>
    /// <returns></returns>
    public List<Sys_Organize> PageList(string fullName,string mobilePhone,int pageIndex,int pageSize,ref int totalNumber)
    {
        var query = Db.Queryable<Sys_Organize>().WhereIF(!string.IsNullOrEmpty(fullName),a=>a.F_FullName.Contains(fullName));
        query = query.WhereIF(!string.IsNullOrEmpty(mobilePhone),a=>a.F_MobilePhone==mobilePhone);
        return query.Where(a => a.F_DeleteMark == false).ToPageList(pageIndex, pageSize, ref totalNumber);
    }
 
    //当前类已经继承了 DbContext增、删、查、改的方法

    //这里面写的代码不会给覆盖,如果要重新生成请删除 Sys_OrganizeManager.cs

    
    #region 教学方法
    /// <summary>
    /// 如果DbContext中的增删查改方法满足不了你，你可以看下具体用法
    /// </summary>
    public void Study()
    {
	     
	   /*********查询*********/

        var data1 = Sys_OrganizeDb.GetById(1);//根据ID查询
        var data2 = Sys_OrganizeDb.GetList();//查询所有
        var data3 = Sys_OrganizeDb.GetList(it => 1 == 1);  //根据条件查询  
        //var data4 = Sys_OrganizeDb.GetSingle(it => 1 == 1);//根据条件查询一条,如果超过一条会报错

        var p = new PageModel() { PageIndex = 1, PageSize = 2 };// 分页查询
        var data5 = Sys_OrganizeDb.GetPageList(it => 1 == 1, p);
        Console.Write(p.PageCount);//返回总数

        var data6 = Sys_OrganizeDb.GetPageList(it => 1 == 1, p, it => SqlFunc.GetRandom(), OrderByType.Asc);// 分页查询加排序
        Console.Write(p.PageCount);//返回总数
     
        List<IConditionalModel> conModels = new List<IConditionalModel>(); //组装条件查询作为条件实现 分页查询加排序
        conModels.Add(new ConditionalModel() { FieldName = typeof(Sys_Organize).GetProperties()[0].Name, ConditionalType = ConditionalType.Equal, FieldValue = "1" });//id=1
        var data7 = Sys_OrganizeDb.GetPageList(conModels, p, it => SqlFunc.GetRandom(), OrderByType.Asc);

        Sys_OrganizeDb.AsQueryable().Where(x => 1 == 1).ToList();//支持了转换成queryable,我们可以用queryable实现复杂功能

        //我要用事务
        var result = Db.Ado.UseTran(() =>
         {
            //写事务代码
        });
        if (result.IsSuccess)
        {
            //事务成功
        }

        //多表查询地址 http://www.codeisbug.com/Doc/8/1124



        /*********插入*********/
        var insertData = new Sys_Organize() { };//测试参数
        var insertArray = new Sys_Organize[] { insertData };
        Sys_OrganizeDb.Insert(insertData);//插入
        Sys_OrganizeDb.InsertRange(insertArray);//批量插入
        var id = Sys_OrganizeDb.InsertReturnIdentity(insertData);//插入返回自增列
        Sys_OrganizeDb.AsInsertable(insertData).ExecuteCommand();//我们可以转成 Insertable实现复杂插入



		/*********更新*********/
	    var updateData = new Sys_Organize() {  };//测试参数
        var updateArray = new Sys_Organize[] { updateData };//测试参数
        Sys_OrganizeDb.Update(updateData);//根据实体更新
        Sys_OrganizeDb.UpdateRange(updateArray);//批量更新
        //Sys_OrganizeDb.Update(it => new Sys_Organize() { Name = "a", CreateTime = DateTime.Now }, it => it.id==1);// 只更新Name列和CreateTime列，其它列不更新，条件id=1
        Sys_OrganizeDb.AsUpdateable(updateData).ExecuteCommand();



		/*********删除*********/
	    var deldata = new Sys_Organize() {  };//测试参数
        Sys_OrganizeDb.Delete(deldata);//根据实体删除
        Sys_OrganizeDb.DeleteById(1);//根据主键删除
        Sys_OrganizeDb.DeleteById(new int[] { 1,2});//根据主键数组删除
        Sys_OrganizeDb.Delete(it=>1==2);//根据条件删除
        Sys_OrganizeDb.AsDeleteable().Where(it=>1==2).ExecuteCommand();//转成Deleteable实现复杂的操作
    } 
    #endregion

 
 
}