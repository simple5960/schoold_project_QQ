using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using CCWin.SkinClass;

namespace RC403ZhangChenYang
{
    public partial class QQTalk : CCSkinMain
    {
        public QQTalk()
        {
            InitializeComponent();
        }

        private void toolStripSplitButton8_MouseHover(object sender, EventArgs e)
        {
            toolStripSplitButton8.ToolTipText = "显示消息";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            output.Text += "\n" +"星夜永恒(142435)"+System.DateTime.Now + "\n" + input.Text;
            input.Text = "";
        }


    }
}
