using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using DataAccess.Connection;
using DataAccess.Entity;
using System.Data;
using System.Net;
using System.IO;
using Business.Entity;
using Newtonsoft.Json;

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

        public String RegistrarClienteRenic(List<string> cl)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Ruc_client", cl[0]));
                lst.Add(new ClsParameter("@Business_name", cl[1]));
                lst.Add(new ClsParameter("@Brand", cl[3]));
                lst.Add(new ClsParameter("@Address", cl[7]));
                lst.Add(new ClsParameter("@Email", cl[12]));
                lst.Add(new ClsParameter("@Telephone", ""));
                lst.Add(new ClsParameter("@Status", cl[6]));
                lst.Add(new ClsParameter("@Condition", cl[2]));
                lst.Add(new ClsParameter("@Created_at", DateTime.Today));
                lst.Add(new ClsParameter("@Updated_at", DateTime.Today));
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

        public DataTable BuscarCliente(String objDatos)
        {
            DataTable dt = new DataTable();
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@Datos", objDatos));
            return dt = M.Listado("FiltrarDatosCliente", lst);
        }
        public List<string> BuscarClienteAPIReniec(String ruc)
        {
            List<string> C = new List<string>();

            //String[] C= new String[14];
            string url = @"https://procontbusiness.com/sunat/sunat.php?ruc=" + ruc;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                JsonGeneric cliente = JsonConvert.DeserializeObject<JsonGeneric>(json);

                //C[0] = cliente.result.ruc;
                C.Add(cliente.result.ruc);
                C.Add(cliente.result.razon_social);
                C.Add(cliente.result.condicion);
                C.Add(cliente.result.nombre_comercial);
                C.Add(cliente.result.tipo);
                C.Add(cliente.result.fecha_inscripcion);
                C.Add(cliente.result.estado);
                C.Add(cliente.result.direccion);
                C.Add(cliente.result.sistema_emision);
                C.Add(cliente.result.actividad_exterior);
                C.Add(cliente.result.sistema_contabilidad);
                C.Add(cliente.result.oficio);
                C.Add(cliente.result.emision_electronica);
                C.Add(cliente.result.ple);
            }
            return C;
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
        public String ActualizarDireccionCliente(Entity.Cliente cl)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Ruc_client", cl.Ruc_client));
                lst.Add(new ClsParameter("@Address", cl.Address));
                lst.Add(new ClsParameter("@Updated_at", cl.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarDireccoinCliente", ref lst);
                Mensaje = lst[3].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
