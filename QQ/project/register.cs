using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RC403ZhangChenYang.Model;
using RC403ZhangChenYang;

namespace RC402HehuiHai.LB3_QQ_Demo
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void bt_register_Click(object sender, EventArgs e)
        {
            //创建用户类, 保存用户各种信息字段

             //判断输入是否合法 昵称和密码和确认密码不能为空
             if (tbNickname.Text == "" || tbPwcl.Text == "" || tb_confirm.Text == "")
             {
                 MessageBox.Show("昵称或密码不能为空, 请重新输入信息.");
                 return;
             }
             //判断密码是否相同
             if (tbPwcl.Text != tb_confirm.Text)
             {
                 MessageBox.Show("两次输入密码不相同, 请重新输入密码.");
                 return;
             }

             //创建qq用户对象,将信息保存到对象中,将对象传给ADD函数
             RC403ZhangChenYang.DAL.Tuser A = new RC403ZhangChenYang.DAL.Tuser();
             RC403ZhangChenYang.Model.Tuser data= new RC403ZhangChenYang.Model.Tuser();
             //昵称
             data.Username = tbNickname.Text;

             //随机生成ID
             Random rd_id = new Random();
             data.QQId = rd_id.Next(1000, 100000).ToString();
             while (A.Exists(data.QQId) == true)
             {
                 data.QQId = rd_id.Next(1000, 100000).ToString();
             }

             //密码
             data.password = tb_confirm.Text;
             //性别
             if (ck_man.Checked == true)
                 data.Sex = "男";
             else
                 data.Sex = "女";
             //生日
             data.BirthDay = dtpBirthday.Value;
             //地址
             data.Address = tb_address.Text;

             try
             {

                 A.Add(data);
             }
             catch //(Exception error)
             {
                 //MessageBox.Show(error.Message);
                 MessageBox.Show("服务器错误, 插入失败, 请稍后重试.");
                 return;
             }
             QQ2013 QQlogin = new QQ2013();
             MessageBox.Show("注册成功!您的QQ账号是:" + data.QQId + ".请妥善保管.");
             this.Close();
             QQlogin.Show();
        }
    }
}