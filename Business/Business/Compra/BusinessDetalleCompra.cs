using DataAccess.Connection;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Compra
{
    public class BusinessDetalleCompra
    {
        #region Inicializar

        private ClsManejador M = new ClsManejador();
        #endregion

        #region CRUD
        public String RegistrarDetalleCompra(Entity.DetalleCompra dc)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParameter("@code_purchages", dc.Code_purchages));
                lst.Add(new ClsParameter("@code_product", dc.Code_product));
                lst.Add(new ClsParameter("@Cantidad", dc.Cantidad));
                lst.Add(new ClsParameter("@Precio",  dc.Precio));
                lst.Add(new ClsParameter("@Code_unit", dc.Code_unit));
                lst.Add(new ClsParameter("@Base_imponible", dc.Base_imponible));
                lst.Add(new ClsParameter("@Igv", dc.Igv));
                lst.Add(new ClsParameter("@importe", dc.Importe));
                lst.Add(new ClsParameter("@Created_at", dc.created_at));
                lst.Add(new ClsParameter("@Updated_at", dc.updated_at));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("RegistrarDetalleCompra", ref lst);
                Mensaje = lst[10].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        //falta 
        public DataTable ListarDetalleVentaCln(String code)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@Code", code));
            return M.Listado("ListarDetalleVentaCln", lst);
        }
        public DataTable ListarDetalleVenta(String code)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@Code", code));
            return M.Listado("ListarDetalleVenta", lst);
        }
        #endregion
    }
}
