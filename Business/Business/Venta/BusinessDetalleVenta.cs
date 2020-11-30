using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using DataAccess.Entity;
using DataAccess.Connection;

namespace Business.Business.Venta
{
    public class BusinessDetalleVenta
    {
        #region Inicializar

        private ClsManejador M = new ClsManejador();
        #endregion

        #region CRUD
        public String RegistrarDetalleVenta(Entity.DetalleVenta dv)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@Code_sales", dv.Code_sales));
                lst.Add(new ClsParameter("@Code_product", dv.Code_product));
                lst.Add(new ClsParameter("@Cantidad", dv.Cantidad));
                lst.Add(new ClsParameter("@Precio", dv.Precio));
                lst.Add(new ClsParameter("@Code_unit", dv.Code_unit));
                lst.Add(new ClsParameter("@Base_imponible", dv.Base_imponible));
                lst.Add(new ClsParameter("@Igv", dv.Igv));
                lst.Add(new ClsParameter("@importe", dv.Importe));
                lst.Add(new ClsParameter("@Created_at", dv.created_at));
                lst.Add(new ClsParameter("@Updated_at", dv.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("RegistrarDetalleVenta", ref lst);
                Mensaje = lst[10].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        public DataTable ListarDetalleVenta(String code)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", code));
            return M.Listado("ListarDetalleVenta", lst);
        }
        #endregion

        // NO USADO 
        public String GenerarIdDetalleVenta()
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            int objIdVenta;
            try
            {
                lst.Add(new ClsParameter("@CodeDetalleVenta", "", SqlDbType.Int, ParameterDirection.Output, 4));
                M.EjecutarSP("GenerarIdDetalleVenta", ref lst);
                objIdVenta = Convert.ToInt32(lst[0].Valor.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToString(objIdVenta);
        }
    }
}
