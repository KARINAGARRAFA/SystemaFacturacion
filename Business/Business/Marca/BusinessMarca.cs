using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using DataAccess.Connection;
using DataAccess.Entity;
using System.Data;

namespace Business.Business.Marca
{
    public class BusinessMarca
    {
        private ClsManejador M = new ClsManejador();
        public String RegistrarMarca(Entity.Marca m)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Code_trademark", m.Code_trademark));
                lst.Add(new ClsParameter("@Trademark_name", m.Trademark_name));
                lst.Add(new ClsParameter("@Description", m.Description));
                lst.Add(new ClsParameter("@Created_at", m.created_at));
                lst.Add(new ClsParameter("@Updated_at", m.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarMarca", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String DeleteMarca(Entity.Marca m)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_trademark", m.Code_trademark));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EliminarMarca", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable ListarMarca()
        {
            return M.Listado("ListarMarca", null);
        }
        public String ActualizarMarca(Entity.Marca m)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_trademark", m.Code_trademark));
                lst.Add(new ClsParameter("@Trademark_name", m.Trademark_name));
                lst.Add(new ClsParameter("@Description", m.Description));
                lst.Add(new ClsParameter("@Updated_at", m.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarMarca", ref lst);
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
