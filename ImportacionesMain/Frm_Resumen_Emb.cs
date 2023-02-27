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
            gridControl1.DataSource = BaseDatos.CargarReporte2();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Frm_Resumen_Add form = new Frm_Resumen_Add();
            form.modificando = false;
            form.ShowDialog();
            gridControl1.DataSource = BaseDatos.CargarReporte2();
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Frm_Resumen_Add form = new Frm_Resumen_Add();
            form.modificando = true;
            form.Id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            form.ShowDialog();
            gridControl1.DataSource = BaseDatos.CargarReporte2();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel files (*.xlsx)||All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(saveFileDialog1.FileName + ".xlsx");
            }
        }
    }
}