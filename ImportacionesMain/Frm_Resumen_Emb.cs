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
    public partial class Frm_Resumen_Emb : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Resumen_Emb()
        {
            InitializeComponent();
        }

        private void Frm_Resumen_Emb_Load(object sender, EventArgs e)
        {
            //gridControl1.DataSource = SqlConnectionClass.CargarResumen();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Frm_Resumen_Add form = new Frm_Resumen_Add();
            form.ShowDialog();
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}