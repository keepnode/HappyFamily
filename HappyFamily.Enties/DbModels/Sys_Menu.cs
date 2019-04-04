using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HappyFamily.Enties
{
    ///<summary>
    ///系统菜单
    ///</summary>
    [SugarTable("Sys_Menu")]
    public partial class Sys_Menu
    {
           public Sys_Menu(){


           }
           /// <summary>
           /// Desc:主键，自增长
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int F_Id {get;set;}

           /// <summary>
           /// Desc:父级ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? F_ParentId {get;set;}

           /// <summary>
           /// Desc:ICON图标
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_Icon {get;set;}

           /// <summary>
           /// Desc:菜单名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_FullName {get;set;}

           /// <summary>
           /// Desc:菜单层级（默认是1）
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public int? F_Layers {get;set;}

           /// <summary>
           /// Desc:删除状态（0=未删除；1=已删除；默认是0）
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? F_DeleteMark {get;set;}

           /// <summary>
           /// Desc:可用状态（0=禁用；1=启用；默认是1）
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
           /// Desc:最后更新时间（默认当前时间）
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? F_LastModifyTime {get;set;}

           /// <summary>
           /// Desc:最后修改人
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
