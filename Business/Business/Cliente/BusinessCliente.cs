using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using DataAccess.Connection;
using DataAccess.Entity;
using System.Data;

namespace Business.Business.Cliente
{
    public class BusinessCliente
    {
        private ClsManejador M = new ClsManejador();
        public String RegistrarCliente(Entity.Cliente cl)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Ruc_client", cl.Ruc_client));
                lst.Add(new ClsParameter("@Business_name", cl.Business_name));
                lst.Add(new ClsParameter("@Brand", cl.Brand));
                lst.Add(new ClsParameter("@Address", cl.Address));
                lst.Add(new ClsParameter("@Email", cl.Email));
                lst.Add(new ClsParameter("@Telephone", cl.Telephone));
                lst.Add(new ClsParameter("@Status", cl.Status));
                lst.Add(new ClsParameter("@Condition", cl.Condition));
                lst.Add(new ClsParameter("@Created_at", cl.created_at));
                lst.Add(new ClsParameter("@Updated_at", cl.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));

                M.EjecutarSP("RegistrarCliente", ref lst);
                Mensaje = lst[10].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String DeleteCliente(Entity.Cliente cl)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Ruc_client", cl.Ruc_client));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EliminarCliente", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable ListarCliente()
        {
            return M.Listado("ListarCliente", null);
        }
        public String ActualizarCliente(Entity.Cliente cl)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Ruc_client", cl.Ruc_client));
                lst.Add(new ClsParameter("@Business_name", cl.Business_name));
                lst.Add(new ClsParameter("@Brand", cl.Brand));
                lst.Add(new ClsParameter("@Address", cl.Address));
                lst.Add(new ClsParameter("@Email", cl.Email));
                lst.Add(new ClsParameter("@Telephone", cl.Telephone));
                lst.Add(new ClsParameter("@Status", cl.Status));
                lst.Add(new ClsParameter("@Condition", cl.Condition));
                lst.Add(new ClsParameter("@Updated_at", cl.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarCliente", ref lst);
                Mensaje = lst[9].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
