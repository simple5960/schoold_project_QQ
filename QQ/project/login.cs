using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RC403ZhangChenYang
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        int num = 0;
        private void BtOk_Click(object sender, EventArgs e)
        {
            //RC403BaseCod.ShuMiMa mima = new RC403BaseCod.ShuMiMa();暂时不会
            if (textBox1.Text != "RC403" || textBox2.Text != "RC403") 
            { 
                ++num;
                MessageBox.Show("您已输入错误密码" + num + "次！", "温馨提示");
                return; 
            }
            LabMain Lm = new LabMain();
            Lm.Show();
            this.Close();
        }

    }
}
