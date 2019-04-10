namespace HappyFamily.UserAPI.Models
{
    public class RedisConfiguration
    {
        public RedisConfiguration()
        {
            Ip = "127.0.0.1";
            Port = 6379;
            Password = "";
            DefaultDatabase = 0;
            Prefix = "";
            PoolSize = 50;
            ConnectionTimeout = 5000;
            PreHeat = true;
            Ssl = false;
        }
        /// <summary>
        /// ip地址
        /// 默认：127.0.0.1
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 端口号
        /// 默认：6379
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 密码
        /// 默认：空
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 默认数据库
        /// 默认：0
        /// </summary>
        public int DefaultDatabase { get; set; }
        /// <summary>
        /// key前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 连接池大小
        /// 默认：50
        /// </summary>
        public int PoolSize { get; set; }
        /// <summary>
        /// 连接超时设置（毫秒）
        /// 默认：5000
        /// </summary>
        public int ConnectionTimeout { get; set; }
        /// <summary>
        /// 预热连接
        /// 默认：true
        /// </summary>
        public bool PreHeat { get; set; }
        /// <summary>
        /// 是否开启加密传输
        /// 默认：false
        /// </summary>
        public bool Ssl { get; set; }
    }
}