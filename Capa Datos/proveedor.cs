using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos librerias
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;

namespace CapaDatos
{
    class DProveedor
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string RazonSProveedor { get; set; }
        public int TelefonoProveedor { get; set; }
        public string NombreRep1Proveedor { get; set; }
        public string CorreoRep1Proveedor { get; set; }
        public int CelularRep1Proveedor { get; set; }
        public string NombreRep2Proveedor { get; set; }
        public string CorreoRep2Proveedor { get; set; }
        public int CelularRep2Proveedor { get; set; }
        public string Ruc { get; set; } //char(11)

        //contructor vacio

        //Constructor con parametros
        public DProveedor(int idProveedor, string nombreProveedor, string razonSProveedor, int telefonoProveedor, string nombreRep1Proveedor, string correoRep1Proveedor, int celularRep1Proveedor, string nombreRep2Proveedor, string correoRep2Proveedor, int celularRep2Proveedor, string ruc)
        {
            //pueden ponerle el prefijo "this." ej: this.IdProveedor, pero no afecta en nada

            IdProveedor = idProveedor;
            NombreProveedor = nombreProveedor;
            RazonSProveedor = razonSProveedor;
            TelefonoProveedor = telefonoProveedor;
            NombreRep1Proveedor = nombreRep1Proveedor;
            CorreoRep1Proveedor = correoRep1Proveedor;
            CelularRep1Proveedor = celularRep1Proveedor;
            NombreRep2Proveedor = nombreRep2Proveedor;
            CorreoRep2Proveedor = correoRep2Proveedor;
            CelularRep2Proveedor = celularRep2Proveedor;
            Ruc = ruc;
        }

        //Metodo Insertar

        public string Insertar(DProveedor Proveedor) 
        {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //codigo

                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                //establecer el comando
                SqlCommand cmd = new SqlCommand("SP_INSERTARPROVEEDOR", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                //@IDPROV
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@IDPROV";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ParIdProveedor);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@NOMBRE";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size=64;
                ParNombre.Value = Proveedor.NombreProveedor;
                cmd.Parameters.Add(ParNombre);

                //RazonSocial
                SqlParameter ParRazonS = new SqlParameter();
                ParRazonS.ParameterName = "@RAZONSOC";
                ParRazonS.SqlDbType = SqlDbType.VarChar;
                ParRazonS.Size = 64;
                ParRazonS.Value = Proveedor.RazonSProveedor;
                cmd.Parameters.Add(ParRazonS);

                //telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@TELEFONOPRO";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = Proveedor.TelefonoProveedor;
                cmd.Parameters.Add(ParTelefono);

                //nombreRepresentante1
                SqlParameter ParNomRep1 = new SqlParameter();
                ParNomRep1.ParameterName = "@NOMREP1";
                ParNomRep1.SqlDbType = SqlDbType.VarChar;
                ParNomRep1.Size = 64;
                ParNomRep1.Value = Proveedor.NombreRep1Proveedor;
                cmd.Parameters.Add(ParNomRep1);

                //correoRepresentante1
                SqlParameter ParCorreoRep1 = new SqlParameter();
                ParCorreoRep1.ParameterName = "@CORREOREP1";
                ParCorreoRep1.SqlDbType = SqlDbType.VarChar;
                ParCorreoRep1.Size = 64;
                ParCorreoRep1.Value = Proveedor.CorreoRep1Proveedor;
                cmd.Parameters.Add(ParCorreoRep1);

                //celularRepresentante1
                SqlParameter ParCeluRep1 = new SqlParameter();
                ParCeluRep1.ParameterName = "@CELULARREP1";
                ParCeluRep1.SqlDbType = SqlDbType.Int;
                ParCeluRep1.Value = Proveedor.CelularRep1Proveedor;
                cmd.Parameters.Add(ParCeluRep1);

                //nombreRepresentante2
                SqlParameter ParNomRep2 = new SqlParameter();
                ParNomRep2.ParameterName = "@NOMREP2";
                ParNomRep2.SqlDbType = SqlDbType.VarChar;
                ParNomRep2.Size = 64;
                ParNomRep2.Value = Proveedor.NombreRep2Proveedor;
                cmd.Parameters.Add(ParNomRep2);

                //correoRepresentante2
                SqlParameter ParCorreoRep2 = new SqlParameter();
                ParCorreoRep2.ParameterName = "@CORREOREP2";
                ParCorreoRep2.SqlDbType = SqlDbType.VarChar;
                ParCorreoRep2.Size = 64;
                ParCorreoRep2.Value = Proveedor.CorreoRep2Proveedor;
                cmd.Parameters.Add(ParCorreoRep2);

                //celularRepresentante2
                SqlParameter ParCeluRep2 = new SqlParameter();
                ParCeluRep2.ParameterName = "@CELULARREP2";
                ParCeluRep2.SqlDbType = SqlDbType.Int;
                ParCeluRep2.Value = Proveedor.CelularRep2Proveedor;
                cmd.Parameters.Add(ParCeluRep2);

                //RUC
                SqlParameter ParRuc = new SqlParameter();
                ParRuc.ParameterName = "@RUC";
                ParRuc.SqlDbType = SqlDbType.VarChar;
                ParRuc.Size = 64;
                ParRuc.Value = Proveedor.Ruc;
                cmd.Parameters.Add(ParRuc);

                //Se ejecuta el comando
                /*si se ejecuta correctamente el comando resultado es "OK", caso contrario "no se ingreso el registro"*/
                /* El cmd.ExecuteNonQuery() bota como resultado un Booleano donde en binario 0 = false y 1 = true
                De ahi sale la comparativa de la condicion "cmd.ExecuteNonQuery() == 1"*/
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }
            catch (Exception ex)
            {
                rpta= ex.Message;
            }
            finally {
                //Cerramos la conexion
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }

            return rpta;

        }
        
        //Metodo Editar

        public string Editar(DProveedor Proveedor) {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //codigo

                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                //establecer el comando
                SqlCommand cmd = new SqlCommand("SP_ACTUALIZARPROVEEDOR", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                //@IDPROV
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@IDPROV";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
                cmd.Parameters.Add(ParIdProveedor);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@NOMBRE";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 64;
                ParNombre.Value = Proveedor.NombreProveedor;
                cmd.Parameters.Add(ParNombre);

                //RazonSocial
                SqlParameter ParRazonS = new SqlParameter();
                ParRazonS.ParameterName = "@RAZONSOC";
                ParRazonS.SqlDbType = SqlDbType.VarChar;
                ParRazonS.Size = 64;
                ParRazonS.Value = Proveedor.RazonSProveedor;
                cmd.Parameters.Add(ParRazonS);

                //telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@TELEFONOPRO";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = Proveedor.TelefonoProveedor;
                cmd.Parameters.Add(ParTelefono);

                //nombreRepresentante1
                SqlParameter ParNomRep1 = new SqlParameter();
                ParNomRep1.ParameterName = "@NOMREP1";
                ParNomRep1.SqlDbType = SqlDbType.VarChar;
                ParNomRep1.Size = 64;
                ParNomRep1.Value = Proveedor.NombreRep1Proveedor;
                cmd.Parameters.Add(ParNomRep1);

                //correoRepresentante1
                SqlParameter ParCorreoRep1 = new SqlParameter();
                ParCorreoRep1.ParameterName = "@CORREOREP1";
                ParCorreoRep1.SqlDbType = SqlDbType.VarChar;
                ParCorreoRep1.Size = 64;
                ParCorreoRep1.Value = Proveedor.CorreoRep1Proveedor;
                cmd.Parameters.Add(ParCorreoRep1);

                //celularRepresentante1
                SqlParameter ParCeluRep1 = new SqlParameter();
                ParCeluRep1.ParameterName = "@CELULARREP1";
                ParCeluRep1.SqlDbType = SqlDbType.Int;
                ParCeluRep1.Value = Proveedor.CelularRep1Proveedor;
                cmd.Parameters.Add(ParCeluRep1);

                //nombreRepresentante2
                SqlParameter ParNomRep2 = new SqlParameter();
                ParNomRep2.ParameterName = "@NOMREP2";
                ParNomRep2.SqlDbType = SqlDbType.VarChar;
                ParNomRep2.Size = 64;
                ParNomRep2.Value = Proveedor.NombreRep2Proveedor;
                cmd.Parameters.Add(ParNomRep2);

                //correoRepresentante2
                SqlParameter ParCorreoRep2 = new SqlParameter();
                ParCorreoRep2.ParameterName = "@CORREOREP2";
                ParCorreoRep2.SqlDbType = SqlDbType.VarChar;
                ParCorreoRep2.Size = 64;
                ParCorreoRep2.Value = Proveedor.CorreoRep2Proveedor;
                cmd.Parameters.Add(ParCorreoRep2);

                //celularRepresentante2
                SqlParameter ParCeluRep2 = new SqlParameter();
                ParCeluRep2.ParameterName = "@CELULARREP2";
                ParCeluRep2.SqlDbType = SqlDbType.Int;
                ParCeluRep2.Value = Proveedor.CelularRep2Proveedor;
                cmd.Parameters.Add(ParCeluRep2);

                //RUC
                SqlParameter ParRuc = new SqlParameter();
                ParRuc.ParameterName = "@RUC";
                ParRuc.SqlDbType = SqlDbType.VarChar;
                ParRuc.Size = 64;
                ParRuc.Value = Proveedor.Ruc;
                cmd.Parameters.Add(ParRuc);

                //Se ejecuta el comando
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Edito el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Cerramos la conexion
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }

            return rpta;
        }
        
        //Metodo Eliminar

        public string Eliminar(DProveedor Proveedor) {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //codigo

                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                //establecer el comando
                SqlCommand cmd = new SqlCommand("SP_ELIMINARPROVEEDOR", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                //@IDPROV
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@IDPROV";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
                cmd.Parameters.Add(ParIdProveedor);

                //Se ejecuta el comando
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Cerramos la conexion
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }

            return rpta;

        }
        
        //Metodo Listar

        public DataTable Listar() {

            DataTable DtResultado = new DataTable("PROVEEDOR");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand cmd = new SqlCommand("SP_LISTARPROVEEDOR", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(cmd);
                sqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        /* //Realizar solo si se necesita el filtrado
        //Metodo Buscar
        public DataTable BuscarNombreProv(DProveedor Proveedor) { }
        */


        /*vavava*/
    }
}
