using DataAccess.Connection;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Producto
{
    public class BusimessCompanyProduct
    {

        #region Inicializar

        private ClsManejador M = new ClsManejador();
        #endregion


        #region CRUD
        public String RegistrarCompanyProduct(Entity.CompanyProduct p)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@code_product", p.Code_product));
                lst.Add(new ClsParameter("@name_product", p.Product_name));
                lst.Add(new ClsParameter("@code_brand", p.Code_brand));
                lst.Add(new ClsParameter("@Code_category", p.Code_category));
                lst.Add(new ClsParameter("@precio", p.Precio));
                lst.Add(new ClsParameter("@unidad_medida", p.Unidad_medida));
                lst.Add(new ClsParameter("@ruc_empresa", p.Ruc_empresa));
                lst.Add(new ClsParameter("@created_at", p.created_at));
                lst.Add(new ClsParameter("@updated_at", p.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarCompanyProducts", ref lst);
                Mensaje = lst[9].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String DeleteCompanyProduct(Entity.CompanyProduct p)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@Code_product", p.Code_product));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("EliminarCompanyProducts", ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        public String ActualizarCompanyProduct(Entity.CompanyProduct p)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@code_product", p.Code_product));
                lst.Add(new ClsParameter("@name_product", p.Product_name));
                lst.Add(new ClsParameter("@code_brand", p.Code_brand));
                lst.Add(new ClsParameter("@Code_category", p.Code_category));
                lst.Add(new ClsParameter("@precio", p.Precio));
                lst.Add(new ClsParameter("@unidad_medida", p.Unidad_medida));
                lst.Add(new ClsParameter("@ruc_empresa", p.Ruc_empresa));
                lst.Add(new ClsParameter("@updated_at", p.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarCompanyProducts", ref lst);
                Mensaje = lst[8].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable BuscarCompanyProduct_codigo(String objDatos)
        {
            DataTable dt = new DataTable();
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@Datos", objDatos));
            return dt = M.Listado("BuscarCompanyProducts_codigo", lst);
        }
        public DataTable BuscarCompanyProduct(String objDatos)
        {
            DataTable dt = new DataTable();
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@Datos", objDatos));
            return dt = M.Listado("BuscarCompanyProducts", lst);
        }

        #endregion

        public DataTable Listado(String ruc)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", ruc));
            return M.Listado("ListarCompanyProducts", lst);
        }
    }
}
