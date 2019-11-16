using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RC403ZhangChenYang.TMessage_Model
{
    /// <summary>
    /// TFriend:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TMessage_data
    {
        public TMessage_data()
        { }
        #region TMessage_Model
        private string _qqid;
        private string _QQFriendID;
        private DateTime _messagetime;
        private string _message;
        public string QQId
        {
            set { _qqid = value; }
            get { return _qqid; }
        }
        public string QQFriendID
        {
            set { _QQFriendID = value; }
            get { return _QQFriendID; }
        }
        public DateTime messagetime
        {
            set { _messagetime = value; }
            get { return _messagetime; }
        }
        public string message
        {
            set { _message = value; }
            get { return _message; }
        }
        #endregion TMessage_Model

    }
}
