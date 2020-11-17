using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using DataAccess.Connection;
using DataAccess.Entity;
using System.Data;

namespace Business.Business.UnidadMedida
{
    public class BusinessUnidadMedida
    {
        private ClsManejador M = new ClsManejador();
        public String RegistrarUnidadMedida(Entity.UnidadMedida um)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Code_unit", um.Code_unit));
                lst.Add(new ClsParameter("@Unit_name", um.Unit_name));
                lst.Add(new ClsParameter("@Description", um.Description));
                lst.Add(new ClsParameter("@Created_at", um.created_at));
                lst.Add(new ClsParameter("@Updated_at", um.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarUMedida", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String DeleteUnidadMedida(Entity.UnidadMedida um)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_unit", um.Code_unit));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EliminarUMedida", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable ListarUnidaMedida()
        {
            return M.Listado("ListarUMedida", null);
        }
        public String ActualizarUnidadMedida(Entity.UnidadMedida um)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_unit", um.Code_unit));
                lst.Add(new ClsParameter("@Unit_name", um.Unit_name));
                lst.Add(new ClsParameter("@Description", um.Description));
                lst.Add(new ClsParameter("@Updated_at", um.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarUMedida", ref lst);
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
