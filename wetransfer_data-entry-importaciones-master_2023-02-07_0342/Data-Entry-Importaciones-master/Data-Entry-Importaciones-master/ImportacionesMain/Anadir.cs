using System;

namespace ImportacionesMain
{
    public partial class Anadir : DevExpress.XtraEditors.XtraForm
    {
        public string tabla;

        public Anadir()
        {
            InitializeComponent();
        }

        private void Anadir_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BaseDatos.InsertarNuevo(tabla, textEdit1.Text);
            this.Close();
        }
    }
}