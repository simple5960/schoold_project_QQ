using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RC403ZhangChenYang.TFriend_Model
{
    /// <summary>
    /// TFriend:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TFriend_data
    {
        public TFriend_data()
        { }
        #region TUser_Model
        private string _qqid;
        private string _friendname;
        private string _QQFriendID;
        private string _FriendGroup;
        private DateTime _MakeFriendDate;
        private string _FriendSign;
        public string QQId
        {
            set { _qqid = value; }
            get { return _qqid; }
        }
        public string FriendName
        {
            set { _friendname = value; }
            get { return _friendname; }
        }
        public string QQFriendID
        {
            set { _QQFriendID = value; }
            get { return _QQFriendID; }
        }
        public string FriendGroup
        {
            set { _FriendGroup = value; }
            get { return _FriendGroup; }
        }
        public DateTime MakeFriendDate
        {
            set { _MakeFriendDate = value; }
            get { return _MakeFriendDate; }
        }
        public string FriendSign
        {
            set { _FriendSign = value; }
            get { return _FriendSign; }
        }
        #endregion TFriend_Model

    }
}
