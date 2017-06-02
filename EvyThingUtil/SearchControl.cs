using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EvyThingUtil
{
    public partial class SearchControl : UserControl
    {
        public delegate void OnsSearch(string key);

        public event OnsSearch OnSearch;

        public SearchControl()
        {
            InitializeComponent();
            txtKey.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKey = txtKey.Text;
            if (string.IsNullOrEmpty(searchKey)) return;
            OnSearch(searchKey);
            this.Cursor = Cursors.WaitCursor;
            const int bufsize = 260;
            StringBuilder buf = new StringBuilder(bufsize);

            // set the search
            EverythingInvoker.Everything_SetSearchW(searchKey);
            // execute the query
            EverythingInvoker.Everything_QueryW(true);

            int numResults = EverythingInvoker.Everything_GetNumResults();
            txtResultCnt.Text = numResults + " Objects";
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Path");
            dt.Columns.Add("Org");
            // loop through the results, adding each result to the listbox.
            string tmp;
            int idx;
            for (int i = 0; i < numResults; i++)
            {
                // get the result's full path and file name.
                EverythingInvoker.Everything_GetResultFullPathNameW(i, buf, bufsize);
                DataRow row = dt.NewRow();
                tmp = buf.ToString();
                idx = tmp.LastIndexOf("\\");
                row["Path"] = tmp.Substring(0, idx);
                row["Name"] = tmp.Substring(idx+1);
                row["Org"] = tmp;
                dt.Rows.Add(row);
            }
            grdResult.DataSource = dt;
            grdResult.Columns["Org"].Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void grdResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                Clipboard.SetText(grdResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if (grdResult.Columns[e.ColumnIndex].Name.Equals("Path"))
                {
                    System.Diagnostics.Process.Start("Explorer", "/select," + grdResult.Rows[e.RowIndex].Cells["Org"].Value); 
                }
                else if (grdResult.Columns[e.ColumnIndex].Name.Equals("Name"))
                {
                    ProcessStartInfo pInfo = new ProcessStartInfo();
                    pInfo.UseShellExecute = true;
                    pInfo.FileName = grdResult.Rows[e.RowIndex].Cells["Org"].Value.ToString();
                    Process.Start(pInfo);
                }
            }
        }

        private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSearch.PerformClick();
            }
        }

        private void grdResult_DataSourceChanged(object sender, EventArgs e)
        {
            if (grdResult.DataSource == null) return;
            grdResult.Columns[0].Width = Convert.ToInt32(Math.Floor(grdResult.Width * 0.4));
            grdResult.Columns[1].Width = grdResult.Width - grdResult.Columns[0].Width;
        }
    }
}
