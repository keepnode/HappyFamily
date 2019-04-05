using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HappyFamily.Enties
{
    ///<summary>
    ///用户登录信息
    ///</summary>
    [SugarTable("Sys_UserLogOn")]
    public partial class Sys_UserLogOn
    {
           public Sys_UserLogOn(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int F_Id {get;set;}

           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? F_UserId {get;set;}

           /// <summary>
           /// Desc:用户密码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_UserPassword {get;set;}

           /// <summary>
           /// Desc:用户密钥
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_UserSecretkey {get;set;}

           /// <summary>
           /// Desc:允许登录开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? F_AllowStartTime {get;set;}

           /// <summary>
           /// Desc:允许登录时间结束
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? F_AllowEndTime {get;set;}

           /// <summary>
           /// Desc:暂停用户开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? F_LockStartDate {get;set;}

           /// <summary>
           /// Desc:暂停用户结束时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? F_LockEndDate {get;set;}

           /// <summary>
           /// Desc:首次访问时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? F_FirstVisitTime {get;set;}

           /// <summary>
           /// Desc:最后一次访问时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? F_LastVisitTime {get;set;}

           /// <summary>
           /// Desc:最后修改密码日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? F_ChangePasswordDate {get;set;}

           /// <summary>
           /// Desc:登录次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? F_LogOnCount {get;set;}

           /// <summary>
           /// Desc:在线状态(0=不在线；1=在线)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? F_UserOnLine {get;set;}

           /// <summary>
           /// Desc:密码提示问题
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_Question {get;set;}

           /// <summary>
           /// Desc:密码提示答案
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string F_AnswerQuestion {get;set;}

           /// <summary>
           /// Desc:是否限制访问
           /// Default:
           /// Nullable:True
           /// </summary>           
           public bool? F_CheckIPAddress {get;set;}

    }
}
