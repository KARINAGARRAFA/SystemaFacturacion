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

namespace Business.Business.User
{
    public class BusinessUser
    {
        private ClsManejador M = new ClsManejador();
        public String RegistrarUsuario(Entity.User U)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Code_ruc", U.Code_ruc));
                lst.Add(new ClsParameter("@Business_name", U.Business_name));
                lst.Add(new ClsParameter("@Brand", U.Brand));
                lst.Add(new ClsParameter("@Cod_sector", U.Cod_sector));
                lst.Add(new ClsParameter("@Address", U.Address));
                lst.Add(new ClsParameter("@Email", U.Email));
                lst.Add(new ClsParameter("@Telephone", U.Telephone));
                lst.Add(new ClsParameter("@Status", U.Status));
                lst.Add(new ClsParameter("@Condition", U.Condition));
                lst.Add(new ClsParameter("@Created_at", U.created_at));
                lst.Add(new ClsParameter("@Updated_at", U.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarUsuario", ref lst);
                Mensaje = lst[11].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String DeleteUsuario(Entity.User U)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_ruc", U.Code_ruc));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EliminarUsuario", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable ListarUsuario()
        {
            return M.Listado("ListarUsuario", null);
        }
        public String ActualizarUsuario(Entity.User U)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_ruc", U.Code_ruc));
                lst.Add(new ClsParameter("@Business_name", U.Business_name));
                lst.Add(new ClsParameter("@Brand", U.Brand));
                lst.Add(new ClsParameter("@Cod_sector", U.Cod_sector));
                lst.Add(new ClsParameter("@Address", U.Address));
                lst.Add(new ClsParameter("@Email", U.Email));
                lst.Add(new ClsParameter("@Telephone", U.Telephone));
                lst.Add(new ClsParameter("@Status", U.Status));
                lst.Add(new ClsParameter("@Condition", U.Condition));
                lst.Add(new ClsParameter("@Updated_at", U.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarUsuario", ref lst);
                Mensaje = lst[10].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
