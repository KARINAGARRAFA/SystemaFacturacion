using DataAccess.Connection;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.login
{
    public class BusinessCompanyUser
    {
        ClsManejador M = new ClsManejador();
        public String RegistrarUserCompany(Entity.CompanyUser U)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            string pas = Encrypt.GetSHA1(Convert.ToString(U.Password));
            try
            {
                lst.Add(new ClsParameter("@username", U.Username));
                lst.Add(new ClsParameter("@password", pas));
                lst.Add(new ClsParameter("@state", U.State));
                lst.Add(new ClsParameter("@ruc_company", U.Ruc_company));
                lst.Add(new ClsParameter("@created_at", U.created_at));
                lst.Add(new ClsParameter("@updated_at", U.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarUsuarioCompania", ref lst);
                return Mensaje = lst[6].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String ActualizarUserCompany(Entity.CompanyUser U)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            string pas = Encrypt.GetSHA1(Convert.ToString(U.Password));
            try
            {
                lst.Add(new ClsParameter("@username", U.Username));
                lst.Add(new ClsParameter("@password", pas));
                lst.Add(new ClsParameter("@state", U.State));
                lst.Add(new ClsParameter("@ruc_company", U.Ruc_company));
                lst.Add(new ClsParameter("@updated_at", U.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarUsuarioCompania", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        public String DeleteUserCompany(Entity.CompanyUser cu)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@username", cu.Username));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EliminarUserCompany", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        public String IniciarSesion(Entity.User_Login U)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            string pas = Encrypt.GetSHA1(Convert.ToString(U.Password));
            try
            {
                lst.Add(new ClsParameter("@Usuario", U.User));
                lst.Add(new ClsParameter("@Password", pas));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("IniciarSesion4", ref lst);
                return Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DevolverDatosSesion(String objUser, String objPassword)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            try
            {
                lst.Add(new ClsParameter("@Usuario", objUser));
                lst.Add(new ClsParameter("@Contraseña", objPassword));
                return M.Listado("DevolverDatosSesion", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarUserCompany()
        {
            return M.Listado("ListarUserCompany", null);
        }
    }
}
