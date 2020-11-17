using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DataAccess.Entity;
using DataAccess.Connection;

namespace Business.Business.Modelo
{
    public class BisnessModelo
    {
        private ClsManejador M = new ClsManejador();
        public String RegistrarModelo(Entity.Modelo md)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Code_model", md.Code_model));
                lst.Add(new ClsParameter("@Model_name", md.Model_name));
                lst.Add(new ClsParameter("@Description", md.Description));
                lst.Add(new ClsParameter("@Created_at", md.created_at));
                lst.Add(new ClsParameter("@Updated_at", md.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarModelo", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        public String DeleteModelo(Entity.Modelo md)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_model", md.Code_model));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EliminarModelo", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable ListarModelo()
        {
            return M.Listado("ListarModelo", null);
        }
        public String ActualizarModelo(Entity.Modelo md)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_model", md.Code_model));
                lst.Add(new ClsParameter("@Model_name", md.Model_name));
                lst.Add(new ClsParameter("@Description", md.Description));
                lst.Add(new ClsParameter("@Updated_at", md.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarModelo", ref lst);
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
