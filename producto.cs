using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;


namespace CapaDatos
{
    class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public DateTime CaducidadProducto { get; set; }
        public string NombreMarca { get; set; }
        public int IdCatProducto { get; set; }
        public int IdPresentacion { get; set; }
        public int IdImg { get; set; }

        public Producto(int idProducto, string nombreProducto, decimal precioProducto, DateTime caducidadProducto, string nombreMarca, int idCatProducto, int idImg)
        {
            this.IdProducto = idProducto;
            this.NombreProducto = nombreProducto;
            this.PrecioProducto = precioProducto;
            this.CaducidadProducto = caducidadProducto;
            this.NombreMarca = nombreMarca;
            this.IdCatProducto = idCatProducto;
            this.IdImg = idImg;
        }

        //Metodo Insertar

        public string Insertar(Producto Producto)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();

            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand("SP_INSERT_PRODUCTO", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros

                //idProducto
                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ParIdProducto);

                //nombreProducto
                SqlParameter ParNombreProducto = new SqlParameter();
                ParNombreProducto.ParameterName = "@nombreProducto";
                ParNombreProducto.SqlDbType = SqlDbType.VarChar;
                ParNombreProducto.Size = 64;
                ParNombreProducto.Value = Producto.NombreProducto;
                cmd.Parameters.Add(ParNombreProducto);

                //precioProducto
                SqlParameter ParPrecioProducto = new SqlParameter();
                ParPrecioProducto.ParameterName = "@precioProducto";
                ParPrecioProducto.SqlDbType = SqlDbType.Decimal;
                ParPrecioProducto.Value = Producto.PrecioProducto;
                cmd.Parameters.Add(ParPrecioProducto);

                //caducidadProducto
                SqlParameter ParCaducidadProducto = new SqlParameter();
                ParPrecioProducto.ParameterName = "@caducidadProducto";
                ParPrecioProducto.SqlDbType = SqlDbType.Date;
                ParPrecioProducto.Value = Producto.CaducidadProducto;
                cmd.Parameters.Add(ParCaducidadProducto);

                //nombreMarca
                SqlParameter ParNombreMarca = new SqlParameter();
                ParNombreMarca.ParameterName = "@nombreMarca";
                ParNombreMarca.SqlDbType = SqlDbType.VarChar;
                ParNombreMarca.Size = 64;
                ParNombreMarca.Value = Producto.NombreMarca;
                cmd.Parameters.Add(ParNombreMarca);

                //idCatProducto
                SqlParameter ParIdCatProducto = new SqlParameter();
                ParIdCatProducto.ParameterName = "@idCatProducto";
                ParIdCatProducto.SqlDbType = SqlDbType.Int;
                ParIdCatProducto.Value = Producto.IdCatProducto;
                cmd.Parameters.Add(ParIdCatProducto);

                //idPresentacion
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Producto.IdPresentacion;
                cmd.Parameters.Add(ParIdPresentacion);

                //idImg
                SqlParameter ParIdImg = new SqlParameter();
                ParIdImg.ParameterName = "@idImg";
                ParIdImg.SqlDbType = SqlDbType.Int;
                ParIdImg.Value = Producto.IdImg;
                cmd.Parameters.Add(ParIdImg);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";



            }
            catch (Exception ex)
            {

                rpta = ex.Message;

            }
            finally
            {

                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }

            return rpta;
        }

        //Metodo Editar

        public string Editar(Producto Producto)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();

            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("SP_UPDATE_PRODUCTO", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros

                //idProducto
                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.IdProducto;
                cmd.Parameters.Add(ParIdProducto);

                //nombreProducto
                SqlParameter ParNombreProducto = new SqlParameter();
                ParNombreProducto.ParameterName = "@nombreProducto";
                ParNombreProducto.SqlDbType = SqlDbType.VarChar;
                ParNombreProducto.Size = 64;
                ParNombreProducto.Value = Producto.NombreProducto;
                cmd.Parameters.Add(ParNombreProducto);


                //precioProducto
                SqlParameter ParPrecioProducto = new SqlParameter();
                ParPrecioProducto.ParameterName = "@precioProducto";
                ParPrecioProducto.SqlDbType = SqlDbType.Decimal;
                ParPrecioProducto.Value = Producto.PrecioProducto;
                cmd.Parameters.Add(ParPrecioProducto);

                //caducidadProducto
                SqlParameter ParCaducidadProducto = new SqlParameter();
                ParPrecioProducto.ParameterName = "@caducidadProducto";
                ParPrecioProducto.SqlDbType = SqlDbType.Date;
                ParPrecioProducto.Value = Producto.CaducidadProducto;
                cmd.Parameters.Add(ParCaducidadProducto);

                //nombreMarca
                SqlParameter ParNombreMarca = new SqlParameter();
                ParNombreMarca.ParameterName = "@nombreMarca";
                ParNombreMarca.SqlDbType = SqlDbType.VarChar;
                ParNombreMarca.Size = 64;
                ParNombreMarca.Value = Producto.NombreMarca;
                cmd.Parameters.Add(ParNombreMarca);

                //idCatProducto
                SqlParameter ParIdCatProducto = new SqlParameter();
                ParIdCatProducto.ParameterName = "@idCatProducto";
                ParIdCatProducto.SqlDbType = SqlDbType.Int;
                ParIdCatProducto.Value = Producto.IdCatProducto;
                cmd.Parameters.Add(ParIdCatProducto);

                //idPresentacion
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Producto.IdPresentacion;
                cmd.Parameters.Add(ParIdPresentacion);

                //idImg
                SqlParameter ParIdImg = new SqlParameter();
                ParIdImg.ParameterName = "@idImg";
                ParIdImg.SqlDbType = SqlDbType.Int;
                ParIdImg.Value = Producto.IdImg;
                cmd.Parameters.Add(ParIdImg);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se editó registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }

            return rpta;


        }


        //Metodo Eliminar

        public string Eliminar(Producto Producto)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();


            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand("SP_DELETE_PRODUCTO", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros

                //idProducto
                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.IdProducto;
                cmd.Parameters.Add(ParIdProducto);

                rpta =  cmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
            }
            return rpta;
        }

        //Metodo Listar

        public DataTable Listar()
        {
            DataTable DtResultado = new DataTable("LISTAPRODUCTO"); //Nombre de ejemplo
            SqlConnection sqlcon = new SqlConnection();

            try
            {
                sqlcon.ConnectionString = Conexion.cn;
                SqlCommand cmd = new SqlCommand("SP_LIST_PRODUCTO", sqlcon);
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







    }
}

