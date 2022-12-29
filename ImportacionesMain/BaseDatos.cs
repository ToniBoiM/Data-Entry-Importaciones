using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacionesMain
{
    class BaseDatos
    {
        public static DataTable CargarAgentes()
        {
            return SqlConnectionClass.CargarTabla("Agente");
        }

        public static DataTable CargarConsigneer()
        {
            return SqlConnectionClass.CargarTabla("Consigneer");
        }

        public static DataTable CargarCarrier()
        {
            return SqlConnectionClass.CargarTabla("Carrier");
        }

        public static DataTable CargarPOL()
        {
            return SqlConnectionClass.CargarTabla("Pol");
        }

        public static DataTable CargarPOD()
        {
            return SqlConnectionClass.CargarTabla("Pod");
        }

        public static DataTable CargarIncoterm()
        {
            return SqlConnectionClass.CargarTabla("Incoterm");
        }

        public static void InsertarNuevo(string tabla, string data)
        {
            SqlConnectionClass.GuardarProc("GuardarInfo", new List<object> { tabla, data });
                }
    }
}
