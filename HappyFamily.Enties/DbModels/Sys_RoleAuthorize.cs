using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HappyFamily.Enties
{
    ///<summary>
    ///角色权限信息
    ///</summary>
    [SugarTable("Sys_RoleAuthorize")]
    public partial class Sys_RoleAuthorize
    {
           public Sys_RoleAuthorize(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int F_Id {get;set;}

           /// <summary>
           /// Desc:机构ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? F_OrganizeId {get;set;}

           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? F_RoleId {get;set;}

           /// <summary>
           /// Desc:菜单ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? F_MenuId {get;set;}

           /// <summary>
           /// Desc:创建时间（默认当前时间）
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
           /// Desc:更新时间（默认当前时间）
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? F_LastModifyTime {get;set;}

           /// <summary>
           /// Desc:更新人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_LastModifyUserId {get;set;}

    }
}
