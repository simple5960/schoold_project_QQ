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
using RC403ZhangChenYang.Model;
using RC403ZhangChenYang.DAL;
using RC402HehuiHai.LB3_QQ_Demo;

namespace RC403ZhangChenYang
{
    public partial class QQ2013 : CCSkinMain
    {
        public QQ2013()
        {
            InitializeComponent();
        }

        String TempPassword = "123456";

        private void skinButtom1_Click(object sender, EventArgs e)
        {
            DAL.Tuser manage = new DAL.Tuser();
            if (manage.Exists(comboBox1.Text.ToString().Trim()))
            {
                if (comboBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("账号或密码不能为空.");
                    return;
                }

                RC403ZhangChenYang.DAL.Tuser lg_ck = new RC403ZhangChenYang.DAL.Tuser();
                //检测账号是否存在
                if (lg_ck.Exists(comboBox1.Text) == false)
                {
                    MessageBox.Show("账号不存在, 请注册.");
                    return;
                }

                //检测密码是否正确
                RC403ZhangChenYang.Model.Tuser get_data = lg_ck.GetModel(comboBox1.Text);
                if (get_data.password.Trim() != textBox1.Text.Trim())
                {
                    MessageBox.Show("密码或账号有误.");
                    return;
                }

                this.Close();
                new QQMain(get_data).Show();

            }
            
            
            //QQMain QQmain = new QQMain();
            //QQmain.Show();
            //this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Close();
            new register().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0) textBox1.Text = TempPassword;
        }

        private void QQ2013_Load(object sender, EventArgs e)
        {
            
        }
    
    }
}
