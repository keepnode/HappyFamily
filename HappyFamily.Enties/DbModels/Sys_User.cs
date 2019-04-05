using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HappyFamily.Enties
{
    ///<summary>
    ///用户信息
    ///</summary>
    [SugarTable("Sys_User")]
    public partial class Sys_User
    {
           public Sys_User(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int F_Id {get;set;}

           /// <summary>
           /// Desc:账号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_Account {get;set;}

           /// <summary>
           /// Desc:真实姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_RealName {get;set;}

           /// <summary>
           /// Desc:昵称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_NickName {get;set;}

           /// <summary>
           /// Desc:头像
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_HeadIcon {get;set;}

           /// <summary>
           /// Desc:性别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? F_Sex {get;set;}

           /// <summary>
           /// Desc:生日
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? F_Birthday {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_MobilePhone {get;set;}

           /// <summary>
           /// Desc:邮箱
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_Email {get;set;}

           /// <summary>
           /// Desc:微信
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_WeChat {get;set;}

           /// <summary>
           /// Desc:组织ID
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
           /// Desc:是否是超级管理员(默认是0；0=否；1=是)
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? F_IsAdministrator {get;set;}

           /// <summary>
           /// Desc:排序(默认是0)
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? F_SortCode {get;set;}

           /// <summary>
           /// Desc:删除状态（0=未删除；1=已删除；默认是0）
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? F_DeleteMark {get;set;}

           /// <summary>
           /// Desc:启用状态（0=禁用；1=启用）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? F_EnableMark {get;set;}

           /// <summary>
           /// Desc:备注
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
