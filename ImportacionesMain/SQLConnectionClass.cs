using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


//Bien se termina hoy
class SqlConnectionClass
{
    public static string SqlConnection = "Server = localhost; Database = RepublicShipping; " +
                                         "User Id = admin; Password = 1234;";
    #region Procedimientos para Añadir

    public static void GuardarTratamiento(string tratamiento, float costo, int IdRes)
    {
        GuardarProc("GuardarTratamiento", new List<object> { tratamiento, costo, IdRes });
    }

    public static void GuardarProc(string command, List<object> list)
    {
        SqlConnection con = new SqlConnection(SqlConnection);
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = command;
        con.Open();
        int i = 0;

        SqlCommandBuilder.DeriveParameters(cmd);
        foreach (SqlParameter p in cmd.Parameters)
        {
            if (p.ParameterName != "@RETURN_VALUE")
            {
                p.Value = list[i];
                i++;
            }
        }

        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public static void AgregarLote(string Corral)
    {
        Sql_Command("insert into Lotes(IdCorral, IdDieta) values (" + Corral + " , 1)");
        Sql_Command("update Corrales set Estado = 'ALIMENTACION' where Id = " + Corral);
    }

    public static void GuardarProveedor(string Nombre, string Tipo)
    {
        GuardarProc("GuardarProveedor", new List<object> { Nombre, Tipo });
    }

    public static void GuardarAcreedor(string Nombre, string Tipo)
    {
        GuardarProc("GuardarAcreedor", new List<object> { Nombre, Tipo });
    }

    public static void AgregarUsuario(string nombre, string Password, string Permiso)
    {
        GuardarProc("AgregarUsuario", new List<object> { nombre, Password, Permiso });
    }

    public static void AgregarAlimentacion(int IdProveedor, int IdDieta, float Costo)
    {
        GuardarProc("GuardarAlimento", new List<object> { IdProveedor, IdDieta, Costo });
    }

    public static void InsertarEnTablaAuxiliar(string Arete, string PesoInicio)
    {
        Sql_Command("insert into CorralAuxiliar(Arete, PesoInicio) values ('" + Arete + "' , '" + PesoInicio + "')");
    }

    public static void GuardarReses(int Arete, int PesoInicio)
    {
        GuardarProc("GuardarLoteReses", new List<object> { Arete, PesoInicio });
    }

    public static void GuardarCompra(int cantidad, float total, int proveedor)
    {
        GuardarProc("GuardarCompra", new List<object> { cantidad, total, proveedor });
    }

    public static void AnadirCorrales(string nombre)
    {
        Sql_Command("insert into Corrales nombre = '" + nombre + "', Estado = 'DISPONIBLE'");
    }

    #endregion

    public static DataTable CargarTablaProc(string command, List<object> list)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(SqlConnection);
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = command;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        con.Open();
        int i = 0;

        SqlCommandBuilder.DeriveParameters(cmd);
        foreach (SqlParameter p in cmd.Parameters)
        {
            if (p.ParameterName != "@RETURN_VALUE")
            {
                cmd.Parameters.Add(new SqlParameter(p.ParameterName, list[i]));
                i++;
            }
        }

        cmd.Connection = con;
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public static DataTable CargarTablaCommand(string command)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(SqlConnection);
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = command;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        con.Open();
        cmd.Connection = con;
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public static void Sql_Command(string command)
    {
        SqlConnection con = new SqlConnection(SqlConnection);
        SqlCommand cmd = con.CreateCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        con.Open();
        cmd.CommandText = command;
        cmd.ExecuteNonQuery();
        con.Close();
    }
    
    #region Procedimientos para Cargar Datos
    public static DataTable CargarProcedimiento(string procedure)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(SqlConnection);
        SqlCommand cmd = con.CreateCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = procedure;
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.Close();

        return dt;
    }

    public static DataTable CargarTabla(string command)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(SqlConnection);
        SqlCommand cmd = con.CreateCommand();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        con.Open();
        cmd.CommandText = "select * from " + command;
        cmd.Connection = con;
        da.SelectCommand = cmd;
        da.Fill(dt);
        con.Close();
        return dt;
    }

    #endregion

    #region Procedimientos para Eliminar


    public static void EliminarTablaCorralAuxiliar()
    {
        Sql_Command("delete from CorralAuxiliar");
    }

    public static void EliminarProveedor(string idProveedor)
    {
        Sql_Command("delete from Proveedor where ID = '" + idProveedor + "'");
    }

    public static void EliminarAcreedor(string idAcreedor)
    {
        Sql_Command("delete from Acreedor where ID = '" + idAcreedor + "'");
    }

    public static void EliminarCorral(string idCorral)
    {
        Sql_Command("delete from Corrales where Id = '" + idCorral + "'");
    }

    public static void EliminarUsuario(string idUsuario)
    {
        Sql_Command("delete from Usuario where Id = '" + idUsuario + "'");
    }
    #endregion

    #region Procedimientos para Modificar

    public static void LoteaArete(string Arete)
    {
        GuardarProc("LoteaReses", new List<object> { Arete });
    }

    public static void ModificarProveedor(string idProveedor, string nombre, string Tipo)
    {
        //Update Proveedor set Nombre = 'nombre', Tipo = 'tipo' where idProveedor = 0
        Sql_Command("update Proveedor set Nombre = '" + nombre + "', Tipo = '" + Tipo + "'where id =" + idProveedor);
    }
    public static void ModificarAcreedor(string idAcreedor, string nombre)
    {
        //Update Proveedor set Nombre = 'nombre', Tipo = 'tipo' where idAcreedor = 0
        Sql_Command("update Acreedor set Nombre = '" + nombre + "'where id =" + idAcreedor);
    }

    public static void ModificarUsuario(string idUsuario, string nombre, string Password, string Permiso)
    {
        //Update Usuario set Nombre = 'nombre', Tipo = 'tipo' where idUsuario = 0
        Sql_Command("update Usuario set Nombre = '" + nombre + "', Password  = '" + Password + "', Permiso ='" + Permiso + "' where id =" + idUsuario);
    }

    #endregion

    #region Procedimientos para Buscar
    public static DataTable BuscarUsuario(string idUsuario)
    {
        return CargarTabla("Usuario where Id = " + idUsuario);
    }
    public static DataTable BuscarProveedor(string idProveedor)
    {
        return CargarTabla("Proveedor where Id = " + idProveedor);
    }
    public static DataTable BuscarAcreedor(string idAcreedor)
    {
        return CargarTabla("Acreedor where Id = " + idAcreedor);
    }
    public static DataTable BuscarCorral(string idCorral)
    {
        return CargarTabla("Corrales where Id = " + idCorral);
    }

    public static DataTable CargarResesVacias()
    {
        return CargarTabla("Reses where Id = 0");
    }

    public static DataTable BuscarAnadirArete(string arete)
    {
        return CargarTabla("Reses where Arete = " + arete);
    }
    #endregion
}