using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HappyFamily.Enties
{
    ///<summary>
    ///角色信息
    ///</summary>
    [SugarTable("Sys_Role")]
    public partial class Sys_Role
    {
           public Sys_Role(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int F_Id {get;set;}

           /// <summary>
           /// Desc:组织ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? F_OrganizeId {get;set;}

           /// <summary>
           /// Desc:角色名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_FullName {get;set;}

           /// <summary>
           /// Desc:排序（默认是0）
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? F_SortCode {get;set;}

           /// <summary>
           /// Desc:删除状态（0=未删除；1=已删除；）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? F_DeleteMark {get;set;}

           /// <summary>
           /// Desc:启用状态（0=未启用；1=启用；默认是1）
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public bool? F_EnableMark {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_Description {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? F_CreatorTime {get;set;}

           /// <summary>
           /// Desc:创建人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_CreatorUserId {get;set;}

           /// <summary>
           /// Desc:修改时间
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? F_LastModifyTime {get;set;}

           /// <summary>
           /// Desc:修改人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_LastModifyUserId {get;set;}

           /// <summary>
           /// Desc:删除时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? F_DeleteTime {get;set;}

           /// <summary>
           /// Desc:删除人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_DeleteUserId {get;set;}

    }
}
