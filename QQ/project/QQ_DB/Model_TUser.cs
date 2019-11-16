using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RC403ZhangChenYang.Model
{
    /// <summary>
    /// Tuser:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Tuser
    {
        public Tuser()
        { }
        #region Model
        private string _qqid;
        private string _username;
        private string _password;
        private string _sex;
        private DateTime _birthday;
        private string _address;
        /// <summary>
        /// 
        /// </summary>
        public string QQId
        {
            set { _qqid = value; }
            get { return _qqid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BirthDay
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        #endregion Model

    }
}
