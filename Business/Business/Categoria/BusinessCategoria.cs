using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using DataAccess.Connection;
using DataAccess.Entity;
using System.Data;

namespace Business.Business.Categoria
{
    public class BusinessCategoria
    {
        private ClsManejador M = new ClsManejador();
        public String RegistrarCategoria(Entity.Categoria c)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Code_category", c.Code_category));
                lst.Add(new ClsParameter("@Category_name", c.Category_name));
                lst.Add(new ClsParameter("@Description", c.Description));
                lst.Add(new ClsParameter("@Created_at", c.created_at));
                lst.Add(new ClsParameter("@Updated_at", c.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarCategoria", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String DeleteCategoria(Entity.Categoria c)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_category", c.Code_category));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EliminarCategoria", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable ListarCategoria()
        {
            return M.Listado("ListarCategoria", null);
        }
        public String ActualizarCategoria(Entity.Categoria c)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_category", c.Code_category));
                lst.Add(new ClsParameter("@Category_name", c.Category_name));
                lst.Add(new ClsParameter("@Description", c.Description));
                lst.Add(new ClsParameter("@Updated_at", c.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarCategoria", ref lst);
                Mensaje = lst[4].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
