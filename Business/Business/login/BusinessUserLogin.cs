using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Connection;
using DataAccess.Entity;
using System.Data;


namespace Business.Business.login
{
    public class BusinessUserLogin
    {
        ClsManejador M = new ClsManejador();
        public String RegistrarUsuarioLogin(Entity.User_Login U)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@IdEmpleado", U.IdEmpleado));
                lst.Add(new ClsParameter("@Usuario", U.User));
                lst.Add(new ClsParameter("@Contraseña", U.Password));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarUsuario", ref lst);
                return Mensaje = lst[3].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String IniciarSesion(Entity.User_Login U)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Usuario", U.User));
                lst.Add(new ClsParameter("@Password", U.Password));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("IniciarSesion", ref lst);
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
    }
}
