using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EvyThingUtil
{
    public partial class FormMain : Form
    {
        private XmlConfigLoader xmlConfig;
        public FormMain()
        {
            InitializeComponent();
            xmlConfig = new XmlConfigLoader();
            this.Width = xmlConfig.GetWindowW();
            this.Height = xmlConfig.GetWindowH();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            toolTipEnableRegex(xmlConfig.GetMatchRegex());
            newSearchToolStripMenuItem.PerformClick();
        }

        #region Config related items
        private const string ENABLE_REGEX = "Enable Regex";
        private void enableRegexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool enable = !enableRegexToolStripMenuItem.Text.StartsWith("√");
            toolTipEnableRegex(enable);
            xmlConfig.SetMatchRegex(enable);
        }

        private void toolTipEnableRegex(bool value)
        {
            EverythingInvoker.Everything_SetRegex(value);
            if (value)
            {
                enableRegexToolStripMenuItem.Text = "√" + ENABLE_REGEX;
                enableRegexToolStripMenuItem.ForeColor = Color.Red;
            }
            else
            {
                enableRegexToolStripMenuItem.Text = ENABLE_REGEX;
                enableRegexToolStripMenuItem.ForeColor = Color.Black;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            xmlConfig.SetWindowH(this.Height);
            xmlConfig.SetWindowW(this.Width);
            EverythingInvoker.Everything_CleanUp();
        }
        #endregion

        #region SearchTab management
        private void newSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchControl sc = new SearchControl();
            sc.Dock = DockStyle.Fill;
            sc.OnSearch += OnSCSearched;
            TabPage tb = new TabPage("New Search");
            tb.Controls.Add(sc);
            tabMain.TabPages.Add(tb);
            tabMain.SelectedTab = tb;
            sc.Focus();
        }

        private void OnSCSearched(string key)
        {
            TabPage cur = tabMain.SelectedTab;
            if (cur != null)
            {
                cur.Text = key;
            }
        }

        private void deleteCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage cur = tabMain.SelectedTab;
            if (cur != null)
            {
                SearchControl sc = cur.Controls[0] as SearchControl;
                sc.OnSearch -= OnSCSearched;
                tabMain.TabPages.Remove(cur);
            }
        }

        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

      
    }
}
