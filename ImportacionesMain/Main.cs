using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportacionesMain
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Resumen_Emb form = new Frm_Resumen_Emb();
            form.MdiParent = this;
            form.Show();
        }
    }
}