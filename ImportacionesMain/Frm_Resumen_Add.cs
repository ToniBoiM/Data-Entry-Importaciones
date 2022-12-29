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
    public partial class Frm_Resumen_Add : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Resumen_Add()
        {
            InitializeComponent();
        }

        private void Frm_Resumen_Add_Load(object sender, EventArgs e)
        {
            List<string> s;
            s = BaseDatos.CargarAgentes().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_agente.Properties.Items.AddRange(s);
            s = BaseDatos.CargarConsigneer().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_consignee.Properties.Items.AddRange(s);
            s = BaseDatos.CargarCarrier().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_carrier.Properties.Items.AddRange(s);
            s = BaseDatos.CargarPOL().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_Pol.Properties.Items.AddRange(s);
            s = BaseDatos.CargarPOD().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_Pod.Properties.Items.AddRange(s);
            s = BaseDatos.CargarIncoterm().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_incoterm.Properties.Items.AddRange(s);
        }

        private void sb_CrearAgente_Click(object sender, EventArgs e)
        {
            Anadir anadir = new Anadir();
            anadir.tabla = "Agente";
            anadir.ShowDialog();
            cb_agente.Properties.Items.Clear();
            List<string> s;
            s = BaseDatos.CargarAgentes().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_agente.Properties.Items.AddRange(s);
        }

        private void sb_CrearCarrier_Click(object sender, EventArgs e)
        {
            Anadir anadir = new Anadir();
            anadir.tabla = "Carrier";
            anadir.ShowDialog();
            cb_carrier.Properties.Items.Clear();
            List<string> s;
            s = BaseDatos.CargarAgentes().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_carrier.Properties.Items.AddRange(s);
        }

        private void sb_CrearPol_Click(object sender, EventArgs e)
        {
            Anadir anadir = new Anadir();
            anadir.tabla = "Pol";
            anadir.ShowDialog();
            cb_Pol.Properties.Items.Clear();
            List<string> s;
            s = BaseDatos.CargarPOL().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_Pol.Properties.Items.AddRange(s);
        }

        private void sb_CrearPod_Click(object sender, EventArgs e)
        {
            Anadir anadir = new Anadir();
            anadir.tabla = "Pod";
            anadir.ShowDialog();
            cb_Pod.Properties.Items.Clear();
            List<string> s;
            s = BaseDatos.CargarPOD().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_Pod.Properties.Items.AddRange(s);
        }

        private void sb_CrearConsignee_Click(object sender, EventArgs e)
        {
            Anadir anadir = new Anadir();
            anadir.tabla = "Consigneer";
            anadir.ShowDialog();
            cb_consignee.Properties.Items.Clear();
            List<string> s;
            s = BaseDatos.CargarConsigneer().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_consignee.Properties.Items.AddRange(s);
        }

        private void sb_CrearIncoterm_Click(object sender, EventArgs e)
        {
            Anadir anadir = new Anadir();
            anadir.tabla = "Incoterm";
            anadir.ShowDialog();
            cb_incoterm.Properties.Items.Clear();
            List<string> s;
            s = BaseDatos.CargarIncoterm().AsEnumerable().Select(x => x[1].ToString()).ToList();
            cb_incoterm.Properties.Items.AddRange(s);
        }
    } 
}