using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using DataAccess.Connection;

using System.Data;
using System.Data.SqlClient;
using DataAccess.Entity;
using Business.Generic;

namespace Business.Entity
{
    public class ClsProduct : EntityGeneric
    {


        private String m_code_product;
        private String m_product_name;
        private String m_code_trademark;
        private String m_code_category;
        private String m_description;

  

        public String Code_product
        {
            get { return m_code_product; }
            set { m_code_product = value; }
        }
        public String Product_name
        {
            get { return m_product_name; }
            set { m_product_name = value; }
        }
        public String Code_trademark
        {
            get { return m_code_trademark; }
            set { m_code_trademark = value; }
        }
        public String Code_category
        {
            get { return m_code_category; }
            set { m_code_category = value; }
        }
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        /*
        public DataTable BuscarCliente(String objDatos)
        {
            DataTable dt = new DataTable();
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@Datos", objDatos));
            return dt = M.Listado("FiltrarDatosCliente", lst);
        }

        public String RegistrarProducto()
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Code_product", m_code_product));
                lst.Add(new ClsParameter("@Product_name", m_product_name));
                lst.Add(new ClsParameter("@Code_trademark", m_code_trademark));
                lst.Add(new ClsParameter("@Code_category", m_code_category));
                lst.Add(new ClsParameter("@Description", m_description));
                lst.Add(new ClsParameter("@Created_at", created_at));
                lst.Add(new ClsParameter("@Updated_at", updated_at));
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

        public DataTable Listado()
        {
            return M.Listado("Listarproducto", null);
        }



        
        

        public String ActualizarCliente()
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@DNI", m_Dni));
                lst.Add(new ClsParameter("@Apellidos", m_Apellidos));
                lst.Add(new ClsParameter("@Nombres", m_Nombres));
                lst.Add(new ClsParameter("@Direccion", m_Direccion));
                lst.Add(new ClsParameter("@Telefono", m_Telefono));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarCliente", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        */
    }
}
