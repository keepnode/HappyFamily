using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HappyFamily.Enties
{
    ///<summary>
    ///公司或组织信息
    ///</summary>
    [SugarTable("Sys_Organize")]
    public partial class Sys_Organize
    {
           public Sys_Organize(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int F_Id {get;set;}

           /// <summary>
           /// Desc:机构名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_FullName {get;set;}

           /// <summary>
           /// Desc:简称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_ShortName {get;set;}

           /// <summary>
           /// Desc:座机
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_TelPhone {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_MobilePhone {get;set;}

           /// <summary>
           /// Desc:微信
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_WeChat {get;set;}

           /// <summary>
           /// Desc:邮箱
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_Email {get;set;}

           /// <summary>
           /// Desc:传真
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_Fax {get;set;}

           /// <summary>
           /// Desc:地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_Address {get;set;}

           /// <summary>
           /// Desc:删除状态（0=未删除；1=已删除；默认是0）
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? F_DeleteMark {get;set;}

           /// <summary>
           /// Desc:使用状态（0=禁用；1=启用；默认是1）
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public bool? F_EnableMark {get;set;}

           /// <summary>
           /// Desc:组织描述/简介
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
           /// Desc:最后修改时间
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
