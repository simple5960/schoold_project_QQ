using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CCWin;
using CCWin.SkinControl;
using CCWin.SkinClass;
using System.Windows.Forms;
using RC403ZhangChenYang.Properties;

namespace RC403ZhangChenYang
{
    public partial class QQMain : CCSkinMain
    {
        Model.Tuser Data;

        public QQMain(Model.Tuser data)
        {
            InitializeComponent();
            this.Data = data;

        }

        private void chatListBox2_DoubleClickSubItem(object sender, ChatListEventArgs e)
        {
            QQTalk qqtalk = new QQTalk();
            qqtalk.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void QQMain_Load(object sender, EventArgs e)
        {
            //本函数用于加载数据库, 加载好友列表

            //加载数据库, 查找所有我的好友
            TFriend_DAL.TFriend manage = new TFriend_DAL.TFriend();
            DataSet DataSet = manage.GetList(" QQID= " + Data.QQId + " ");

            //遍历表的每一行
            foreach (DataRow row in DataSet.Tables[0].Rows)
            {
                if (ChatListItem_Exist(row["FriendGroup"].ToString()) == false)
                    ChatListItem_Add_Item(row["FriendGroup"].ToString());
                TFriend_Model.TFriend_data data = new TFriend_Model.TFriend_data();

                data.QQId = this.Data.QQId;
                data.QQFriendID = row["QQFriendID"].ToString();
                data.MakeFriendDate = System.DateTime.Now;
                data.FriendName = row["FriendName"].ToString();
                data.FriendGroup = row["FriendGroup"].ToString();
                data.FriendSign = row["FriendSign"].ToString();

                //MessageBox.Show(row["QQID"] + " " + row["QQFriendID"] + " " + row["FriendGroup"] + "\n" );
                ChatListItem_Add_Friend(GetGroup(row["FriendGroup"].ToString()), data);
            }
        }

        /// <summary>
        /// 增加结点sub_ttem到parent_item中
        /// </summary>
        /// <param name="parent_item"></param>
        /// <param name="sub_item_id"></param>
        private void ChatListItem_Add_Friend(CCWin.SkinControl.ChatListItem parent_item, TFriend_Model.TFriend_data sub_item_data)
        {
            CCWin.SkinControl.ChatListSubItem chatListSubItem = new CCWin.SkinControl.ChatListSubItem();


            chatListSubItem.DisplayName = sub_item_data.FriendName;//"displayName";
            chatListSubItem.ID = int.Parse(sub_item_data.QQFriendID);
            chatListSubItem.NicName = "ID : " + sub_item_data.QQFriendID;
            chatListSubItem.PersonalMsg = sub_item_data.FriendSign;


            //设置一些默认值
            chatListSubItem.Bounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            chatListSubItem.HeadImage = null;
            chatListSubItem.HeadRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            chatListSubItem.IpAddress = null;
            chatListSubItem.IsTwinkle = false;
            chatListSubItem.IsTwinkleHide = false;

            chatListSubItem.OwnerListItem = parent_item;
            chatListSubItem.Status = CCWin.SkinControl.ChatListSubItem.UserStatus.Online;
            chatListSubItem.Tag = null;
            chatListSubItem.TcpPort = 0;
            chatListSubItem.UpdPort = 0;
            parent_item.SubItems.AddRange(new CCWin.SkinControl.ChatListSubItem[] {
            chatListSubItem});
        }

        /// <summary>
        ///  增加一个新的分组 Item
        /// </summary>
        /// <param name="Item_name"></param>
        private void ChatListItem_Add_Item(string Item_name)
        {
            if (ChatListItem_Exist(Item_name.Trim()) == false)
            {
                chatListBox1.Items.Add(new CCWin.SkinControl.ChatListItem(Item_name));
            }

        }

        /// <summary>
        /// 判断一个分组是否存在
        /// </summary>
        /// <param name="Item_name"></param>
        /// <returns></returns>
        private bool ChatListItem_Exist(string Item_name)
        {
            foreach (CCWin.SkinControl.ChatListItem tn in this.chatListBox1.Items)
            {
                if (tn.Text == Item_name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取分组
        /// </summary>
        /// <param name="Item_name"></param>
        /// <returns></returns>
        private CCWin.SkinControl.ChatListItem GetGroup(string Item_name)
        {
            foreach (CCWin.SkinControl.ChatListItem tn in this.chatListBox1.Items)
            {
                if (tn.Text == Item_name)
                    return tn;
            }
            return null;
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {

        }
     }
}
