using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
        public bool modificando;
        public int Id;

        public Frm_Resumen_Add()
        {
            InitializeComponent();
            gridControl1.DataSource = CreateTable(1);
        }

        private DataTable CreateTable(int row)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Cantidad", typeof(int));
            tbl.Columns.Add("Costo", typeof(int));
            return tbl;
        }

        Dictionary<int, decimal> customTotals = new Dictionary<int, decimal>();

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            int rowIndex = e.ListSourceRowIndex;
            decimal unitPrice = Convert.ToDecimal(view.GetListSourceRowCellValue(rowIndex, "Costo"));
            decimal quantity = Convert.ToDecimal(view.GetListSourceRowCellValue(rowIndex, "Cantidad"));
            decimal discount = Convert.ToDecimal(view.GetListSourceRowCellValue(rowIndex, "Size"));
            if (e.Column.FieldName != "Total") return;
            if (e.IsGetData)
            {
                if (!customTotals.ContainsKey(rowIndex))
                    customTotals.Add(rowIndex, unitPrice * quantity * (1 - discount));
                e.Value = customTotals[rowIndex];
            }
            if (e.IsSetData)
            {
                customTotals[rowIndex] = Convert.ToDecimal(e.Value);
            }
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

            if (modificando)
            {
                gridControl1.DataSource = BaseDatos.CargarSizes(Id);
                DataTable dt = BaseDatos.CargarReporte(Id);
                cb_agente.SelectedItem = dt.Rows[0]["Agente"];
                cb_consignee.SelectedItem = dt.Rows[0]["Consignee"];
                cb_carrier.SelectedItem = dt.Rows[0]["Carrier"];
                cb_Pol.SelectedItem = dt.Rows[0]["Pol"];
                cb_Pod.SelectedItem = dt.Rows[0]["Pod"];
                cb_incoterm.SelectedItem = dt.Rows[0]["incoterm"];
                cb_FormaPago.Text = dt.Rows[0]["FormaPago"].ToString();

                txtBK.Text = dt.Rows[0]["Bk"].ToString();
                txtHBL.Text = dt.Rows[0]["HBL"].ToString();
                txtMBL.Text = dt.Rows[0]["MBL"].ToString();
                txtREF.Text = dt.Rows[0]["REF"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripción"].ToString();
                txtDGastos.Text = dt.Rows[0]["DGastos"].ToString();

                txtOf.Text = dt.Rows[0]["Of"].ToString();
                txtPAgent.Text = dt.Rows[0]["Pagent"].ToString();
                txtOM.Text = dt.Rows[0]["Om"].ToString();
                txtINLAN.Text = dt.Rows[0]["INCTOMGA"].ToString();
                txtTHC.Text = dt.Rows[0]["THC"].ToString();
                txtCVLocal.Text = dt.Rows[0]["CLocal"].ToString();
                txtTlocal.Text = dt.Rows[0]["TLocal"].ToString();
                txtRebate.Text = dt.Rows[0]["rebate"].ToString();
                txtReintegro.Text = dt.Rows[0]["Reintegro"].ToString();
                txtTEspecial.Text = dt.Rows[0]["TEspecial"].ToString();
                txtQuotation.Text = dt.Rows[0]["quotation"].ToString();
                txtOTotal.Text = dt.Rows[0]["TOrigen"].ToString();
                txtOtros.Text = dt.Rows[0]["Otros"].ToString();
                txt_Profit.Text = dt.Rows[0]["Profit"].ToString();
                txtCotizacion.Text = dt.Rows[0]["Cotizacion"].ToString();
                txtRefAgente.Text = dt.Rows[0]["RefAgente"].ToString();
                dt_ETA.EditValue = dt.Rows[0]["ETA"];
                dt_ETD.EditValue = dt.Rows[0]["ETD"];
            }



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
            s = BaseDatos.CargarCarrier().AsEnumerable().Select(x => x[1].ToString()).ToList();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string prueba;
            float pruaba;
            DateTime pruebo;

            try
            {
                prueba = cb_agente.Text;
                prueba = cb_Pol.Text;
                prueba = cb_Pod.Text;
                prueba = cb_carrier.Text;
                prueba = cb_consignee.Text;
                prueba = txtBK.Text;
                prueba = txtHBL.Text;
                prueba = txtMBL.Text;
                prueba = txtRefAgente.Text;
                prueba = cb_FormaPago.Text;
            
            }
            catch
            {
                MessageBox.Show("Verifique la informacion");
            }


            try
            {
                prueba = txtREF.Text;
                pruebo = (DateTime)dt_ETD.EditValue;
                pruebo = (DateTime)dt_ETA.EditValue;
                prueba = txtDescripcion.Text;
                pruaba = float.Parse(txtOf.Text);
                pruaba = float.Parse(txtPAgent.Text);
                prueba = cb_incoterm.Text;
                prueba = txtQuotation.Text;
            }
            catch
            {
                MessageBox.Show("Verifique la informacion");
            }

            try
            {
                pruaba = float.Parse(txtOTotal.Text);
                pruaba = float.Parse(txtOM.Text);
                pruaba = float.Parse(txtINLAN.Text);
                pruaba = float.Parse(txtTHC.Text);
                prueba = txtDGastos.Text;
                pruaba = float.Parse(txtCVLocal.Text);
                pruaba = float.Parse(txtTlocal.Text);
                pruaba = float.Parse(txtTEspecial.Text);
                
                try
                {
                    pruaba = float.Parse(txtOtros.Text);
                }
                catch
                {
                    txtOtros.Text = "0";
                }

                try
                {
                    pruaba = float.Parse(txtRebate.Text);
                }
                catch
                {
                    txtRebate.Text = "0";
                }

                try
                {
                    pruaba = float.Parse(txtReintegro.Text);
                }
                catch
                {
                    txtReintegro.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show("Verifique la informacion");
            }

            if (modificando)
            {
                try
                {
                    BaseDatos.ModificarReporte(cb_agente.Text, cb_Pol.Text, cb_Pod.Text, cb_carrier.Text,
                        cb_consignee.Text, txtBK.Text,
                   txtHBL.Text, txtMBL.Text,
                   txtREF.Text, (DateTime)dt_ETD.EditValue, (DateTime)dt_ETA.EditValue,
                   txtDescripcion.Text, float.Parse(txtOf.EditValue.ToString()),
                   float.Parse(txtPAgent.Text), cb_incoterm.Text, txtQuotation.Text,
                   float.Parse(txtOTotal.Text), float.Parse(txtOM.Text), float.Parse(txtINLAN.Text),
                   float.Parse(txtTHC.Text), txtDGastos.Text,
                   float.Parse(txtCVLocal.Text), float.Parse(txtTlocal.Text),
                   float.Parse(txtRebate.Text), float.Parse(txtReintegro.Text),
                   float.Parse(txtTEspecial.Text), float.Parse(txtOtros.Text), Id, float.Parse(txt_Profit.Text),
                   float.Parse(txtCotizacion.Text)
                   ,txtRefAgente.Text, cb_FormaPago.Text
                   );

                    this.Close();


                }
                catch
                {
                    MessageBox.Show("Error en la base de datos");
                }
            }
            else
            {
                //try
                {
                    BaseDatos.GuardarReporte(cb_agente.Text, cb_Pol.Text, cb_Pod.Text, cb_carrier.Text,
                        cb_consignee.Text, txtBK.Text,
                   txtHBL.Text, txtMBL.Text,
                   txtREF.Text, (DateTime)dt_ETD.EditValue, (DateTime)dt_ETA.EditValue,
                   txtDescripcion.Text, float.Parse(txtOf.EditValue.ToString()),
                   float.Parse(txtPAgent.Text), cb_incoterm.Text, txtQuotation.Text,
                   float.Parse(txtOTotal.Text), float.Parse(txtOM.Text), float.Parse(txtINLAN.Text),
                   float.Parse(txtTHC.Text), txtDGastos.Text,
                   float.Parse(txtCVLocal.Text), float.Parse(txtTlocal.Text),
                   float.Parse(txtRebate.Text), float.Parse(txtReintegro.Text),
                   float.Parse(txtTEspecial.Text), float.Parse(txtOtros.Text),
                   float.Parse(txt_Profit.Text), float.Parse(txtCotizacion.Text), txtRefAgente.Text, cb_FormaPago.Text);
                    
                   for(int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        BaseDatos.GuardarSizes(float.Parse(gridView1.GetDataRow(i)["Cantidad"].ToString()), 
                            float.Parse(gridView1.GetDataRow(i)["Costo"].ToString()),
                            gridView1.GetDataRow(i)["Costo"].ToString());
                    }

                    this.Close();


                }
                //catch
                ////{
                //    MessageBox.Show("Error en la base de datos");
                //}

            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOf_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPAgent_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtQuotation_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtOf_Leave(object sender, EventArgs e)
        {
            float of, pagent;

            try
            {
                of = float.Parse(txtOf.EditValue.ToString());
            }
            catch
            {
                of = 0;
            }

            try
            {
                pagent = float.Parse(txtPAgent.Text);
            }
            catch
            {
                pagent = 0;
            }


            //MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            txtOTotal.Text = (of + pagent).ToString();
        }

        private void txtPAgent_Leave(object sender, EventArgs e)
        {
            float of, pagent;

            try
            {
                of = float.Parse(txtOf.EditValue.ToString());
            }
            catch
            {
                of = 0;
            }

            try
            {
                pagent = float.Parse(txtPAgent.Text);
            }
            catch
            {
                pagent = 0;
            }


            //MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            txtOTotal.Text = (of + pagent).ToString();
        }

        private void txtQuotation_Leave(object sender, EventArgs e)
        {
            //float of, pagent, quotation;

            //try
            //{
            //    of = float.Parse(txtOf.EditValue.ToString());
            //}
            //catch
            //{
            //    of = 0;
            //}

            //try
            //{
            //    pagent = float.Parse(txtPAgent.Text);
            //}
            //catch
            //{
            //    pagent = 0;
            //}

            //try
            //{
            //    quotation = float.Parse(txtQuotation.Text);
            //}
            //catch
            //{
            //    quotation = 0;
            //}
            ////MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            //txtOTotal.Text = (of + pagent + quotation).ToString();
        }

        private void txtOM_Leave(object sender, EventArgs e)
        {
            float om, inlan, thc, otros, comision;

            try
            {
                om = float.Parse(txtOM.EditValue.ToString());
            }
            catch
            {
                om = 0;
            }

            try
            {
                inlan = float.Parse(txtINLAN.Text);
            }
            catch
            {
                inlan = 0;
            }
            try
            {
                thc = float.Parse(txtTHC.Text);
            }
            catch
            {
                thc = 0;
            }
            try
            {
                otros = float.Parse(txtOtros.Text);
            }
            catch
            {
                otros = 0;
            }
            try
            {
                comision = float.Parse(txtCVLocal.Text);
            }
            catch
            {
                comision = 0;
            }
            //MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            txtTlocal.Text = (om + inlan + thc + otros + comision).ToString();
        }

        private void txtINLAN_Leave(object sender, EventArgs e)
        {
            float om, inlan, thc, otros, comision;

            try
            {
                om = float.Parse(txtOM.EditValue.ToString());
            }
            catch
            {
                om = 0;
            }

            try
            {
                inlan = float.Parse(txtINLAN.Text);
            }
            catch
            {
                inlan = 0;
            }
            try
            {
                thc = float.Parse(txtTHC.Text);
            }
            catch
            {
                thc = 0;
            }
            try
            {
                otros = float.Parse(txtOtros.Text);
            }
            catch
            {
                otros = 0;
            }
            try
            {
                comision = float.Parse(txtCVLocal.Text);
            }
            catch
            {
                comision = 0;
            }
            //MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            txtTlocal.Text = (om + inlan + thc + otros + comision).ToString();
        }

        private void txtTHC_Leave(object sender, EventArgs e)
        {
            float om, inlan, thc, otros, comision;

            try
            {
                om = float.Parse(txtOM.EditValue.ToString());
            }
            catch
            {
                om = 0;
            }

            try
            {
                inlan = float.Parse(txtINLAN.Text);
            }
            catch
            {
                inlan = 0;
            }
            try
            {
                thc = float.Parse(txtTHC.Text);
            }
            catch
            {
                thc = 0;
            }
            try
            {
                otros = float.Parse(txtOtros.Text);
            }
            catch
            {
                otros = 0;
            }
            try
            {
                comision = float.Parse(txtCVLocal.Text);
            }
            catch
            {
                comision = 0;
            }
            //MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            txtTlocal.Text = (om + inlan + thc + otros + comision).ToString();
        }

        private void txtOtros_Leave(object sender, EventArgs e)
        {
            float om, inlan, thc, otros, comision;

            try
            {
                om = float.Parse(txtOM.EditValue.ToString());
            }
            catch
            {
                om = 0;
            }

            try
            {
                inlan = float.Parse(txtINLAN.Text);
            }
            catch
            {
                inlan = 0;
            }
            try
            {
                thc = float.Parse(txtTHC.Text);
            }
            catch
            {
                thc = 0;
            }
            try
            {
                otros = float.Parse(txtOtros.Text);
            }
            catch
            {
                otros = 0;
            }
            try
            {
                comision = float.Parse(txtCVLocal.Text);
            }
            catch
            {
                comision = 0;
            }
            //MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            txtTlocal.Text = (om + inlan + thc + otros + comision).ToString();
        }

        private void txtCVLocal_Leave(object sender, EventArgs e)
        {
            float om, inlan, thc, otros, comision;

            try
            {
                om = float.Parse(txtOM.EditValue.ToString());
            }
            catch
            {
                om = 0;
            }

            try
            {
                inlan = float.Parse(txtINLAN.Text);
            }
            catch
            {
                inlan = 0;
            }
            try
            {
                thc = float.Parse(txtTHC.Text);
            }
            catch
            {
                thc = 0;
            }
            try
            {
                otros = float.Parse(txtOtros.Text);
            }
            catch
            {
                otros = 0;
            }
            try
            {
                comision = float.Parse(txtCVLocal.Text);
            }
            catch
            {
                comision = 0;
            }
            //MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            txtTlocal.Text = (om + inlan + thc + otros + comision).ToString();
        }

        private void txtRebate_Leave(object sender, EventArgs e)
        {
            float rebate, reintegro;

            try
            {
                rebate = float.Parse(txtRebate.Text);
            }
            catch
            {
                rebate = 0;
            }

            try
            {
                reintegro = float.Parse(txtReintegro.Text);
            }
            catch
            {
                reintegro = 0;
            }

            //MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            txtTEspecial.Text = (rebate + reintegro).ToString();
        }

        private void txtReintegro_Leave(object sender, EventArgs e)
        {
            float rebate, reintegro;

            try
            {
                rebate = float.Parse(txtRebate.Text);
            }
            catch
            {
                rebate = 0;
            }

            try
            {
                reintegro = float.Parse(txtReintegro.Text);
            }
            catch
            {
                reintegro = 0;
            }

            //MessageBox.Show(of.ToString() + " " + pagent.ToString() + " " + quotation.ToString() + " ");
            txtTEspecial.Text = (rebate + reintegro).ToString();
        }

        private void txtCotizacion_Leave(object sender, EventArgs e)
        {
            try
            {
                txt_Profit.Text = (float.Parse(txtCotizacion.Text) - float.Parse(txtOTotal.Text) -
                    float.Parse(txtTlocal.Text)).ToString();
            }catch
            {
                txt_Profit.Text = "0";
            }
        }

        private void txtTlocal_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txt_Profit.Text = (float.Parse(txtCotizacion.Text) - float.Parse(txtOTotal.Text) -
                    float.Parse(txtTlocal.Text)).ToString();
            }
            catch
            {
                txt_Profit.Text = "0";
            }
        }

        private void txtTEspecial_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtOTotal_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txt_Profit.Text = (float.Parse(txtCotizacion.Text) - float.Parse(txtOTotal.Text) -
                    float.Parse(txtTlocal.Text)).ToString();
            }
            catch
            {
                txt_Profit.Text = "0";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}