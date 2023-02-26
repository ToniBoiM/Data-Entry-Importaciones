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

        public static DataTable CargarReporte()
        {
            return SqlConnectionClass.CargarTabla("Reporte");
        }

        public static DataTable CargarReporte(int Id)
        {
            return SqlConnectionClass.CargarTabla("Reporte where Id = " + Id);
        }

        public static DataTable CargarReporte2()
        {
            return SqlConnectionClass.CargarTablaCommand("select Id, Agente, POL, POD, Carrier, Consignee, BK, HBL, MBL," +
                "REF, ETD, ETA, TOrigen, TLocal, TEspecial, Profit from Reporte order by Id desc");
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

        public static void GuardarReporte(string Agente, string POL, string POD, 
            string Carrier, string Consigneer, string BK, string HBL, string MBL, string REF, 
            string Size, DateTime ETD, DateTime ETA, string Descripcion, float OF, float PAgent,
            string INCOTERM, string Quotation, float TOrigen, float OM, float INTOMGA, float THC,
            string DGastos, float CLocal, float TLocal, float Rebate, float Reintegro, float Tespecial, float Otros, float Profit, float Cotizacion)
        {
            SqlConnectionClass.GuardarProc("GuardarReporte", new List<object> { Agente, POL, POD, Carrier, Consigneer, BK, HBL, MBL, REF, Size, ETD, ETA, Descripcion, OF,
            PAgent, INCOTERM, Quotation, TOrigen, OM, INTOMGA, THC, DGastos, CLocal, TLocal, Rebate, Reintegro, Tespecial, Otros, Profit, Cotizacion});
        }

        public static void ModificarReporte(string Agente, string POL, string POD,
           string Carrier, string Consigneer, string BK, string HBL, string MBL, string REF,
           string Size, DateTime ETD, DateTime ETA, string Descripcion, float OF, float PAgent,
           string INCOTERM, string Quotation, float TOrigen, float OM, float INTOMGA, float THC,
           string DGastos, float CLocal, float TLocal, float Rebate, float Reintegro, float Tespecial, float Otros, int Id, float Profit, float Cotizacion)
        {
            SqlConnectionClass.GuardarProc("ModificarReporte", new List<object> { Agente, POL, POD, Carrier, Consigneer, BK, HBL, MBL, REF, Size, ETD, ETA, Descripcion, OF,
            PAgent, INCOTERM, Quotation, TOrigen, OM, INTOMGA, THC, DGastos, CLocal, TLocal, Rebate, Reintegro, Tespecial, Otros, Id, Profit, Cotizacion});
        }
    }


}
