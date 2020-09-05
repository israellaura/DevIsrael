using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class NProveedor
    {
        //metodo insertar que llama a la clase DProveedor de la capa datos
        //Se pasa los parametros de los metodos de la capa de datos y se devuelve el objeto lleno
        public static string Insertar(string nombre, string razons, int telefono,
            string nomrep1, string correorep1, int celularrep1,string nomrep2,
            string correorep2, int celularrep2, string ruc) 
        {
            DProveedor obj = new DProveedor();
            obj.NombreProveedor = nombre;
            obj.RazonSProveedor = razons;
            obj.TelefonoProveedor = telefono;
            obj.NombreRep1Proveedor = nomrep1;
            obj.CorreoRep1Proveedor = correorep1;
            obj.CelularRep1Proveedor = celularrep1;
            obj.NombreRep2Proveedor = nomrep2;
            obj.CorreoRep2Proveedor = correorep2;
            obj.CelularRep2Proveedor = celularrep2;
            obj.Ruc = ruc;

            return obj.Insertar(obj);
        }

        //metodo Editar que llama a la clase DProveedor de la capa datos
        public static string Editar(int idprov,string nombre, string razons, int telefono,
           string nomrep1, string correorep1, int celularrep1, string nomrep2,
           string correorep2, int celularrep2, string ruc)
        {
            DProveedor obj = new DProveedor();
            obj.IdProveedor = idprov;
            obj.NombreProveedor = nombre;
            obj.RazonSProveedor = razons;
            obj.TelefonoProveedor = telefono;
            obj.NombreRep1Proveedor = nomrep1;
            obj.CorreoRep1Proveedor = correorep1;
            obj.CelularRep1Proveedor = celularrep1;
            obj.NombreRep2Proveedor = nomrep2;
            obj.CorreoRep2Proveedor = correorep2;
            obj.CelularRep2Proveedor = celularrep2;
            obj.Ruc = ruc;

            return obj.Editar(obj);
        }

        //metodo Eliminar que llama a la clase DProveedor de la capa datos
        public static string Eliminar(int idprov)
        {
            DProveedor obj = new DProveedor();
            obj.IdProveedor = idprov;
            
            return obj.Eliminar(obj);

        }

        //metodo Listar que llama a la clase DProveedor de la capa datos
        public static DataTable Listar() 
        {
            return new DProveedor().Listar();
        }

        //metodo buscar que llama a la clase DProveedor de la capa datos
        //Si se requiere aplicar un metodo para el filtro de busqueda
        //public static DataTable BuscarNombre(string textoDeBusqueda) { }
    }
}
