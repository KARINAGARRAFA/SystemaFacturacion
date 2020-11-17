using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;
using DataAccess;
using DataAccess.Connection;
using DataAccess.Entity;
using System.Data;

namespace Business.Business.Producto
{
    public class BusinessProducto
    {       
        private ClsManejador M = new ClsManejador();
        public String RegistrarProducto(Entity.ClsProduct p)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Code_product", p.Code_product));
                lst.Add(new ClsParameter("@Product_name", p.Product_name));
                lst.Add(new ClsParameter("@Code_trademark", p.Code_trademark));
                lst.Add(new ClsParameter("@Code_category", p.Code_category));
                lst.Add(new ClsParameter("@Description", p.Description));
                lst.Add(new ClsParameter("@Created_at", p.created_at));
                lst.Add(new ClsParameter("@Updated_at", p.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarProducto", ref lst);
                Mensaje = lst[7].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String Delete(Entity.ClsProduct p)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_product", p.Code_product));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EliminarProducto", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable Listado()
        {
            return M.Listado("Listarproducto", null);
        }
        public String ActualizarProductos(Entity.ClsProduct p)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_product", p.Code_product));
                lst.Add(new ClsParameter("@Product_name", p.Product_name));
                lst.Add(new ClsParameter("@Code_trademark", p.Code_trademark));
                lst.Add(new ClsParameter("@Code_category", p.Code_category));
                lst.Add(new ClsParameter("@Description", p.Description));
                lst.Add(new ClsParameter("@Created_at", p.created_at));
                lst.Add(new ClsParameter("@Updated_at", p.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarProducto", ref lst);
                Mensaje = lst[7].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
