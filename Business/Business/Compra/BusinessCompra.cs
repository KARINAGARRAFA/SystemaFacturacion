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
     public class BusinessCompra
    {
        #region Inicializar

        private ClsManejador M = new ClsManejador();
        #endregion
        #region CRUD
        public String RegistrarCompra(Entity.Compra c)
        {
            String Mensaje = "";
            List<ClsParameter> lst = new List<ClsParameter>();
            try
            {
                lst.Add(new ClsParameter("@code_purchages", c.Code_purchages));
                lst.Add(new ClsParameter("@Numero", c.Numero));
                lst.Add(new ClsParameter("@Fecha_emision", c.Fecha_emision));
                lst.Add(new ClsParameter("@Fecha_pago", c.Fecha_pago));
                lst.Add(new ClsParameter("@Cdp_tipo", c.Cdp_tipo));
                lst.Add(new ClsParameter("@Cdp_serie", c.Cdp_serie));
                lst.Add(new ClsParameter("@Cdp_numero", c.Cdp_numero));
                lst.Add(new ClsParameter("@Proveedor_tipo", c.Proveedor_tipo));
                lst.Add(new ClsParameter("@Proveedor_numero", c.Proveedor_numero));
                lst.Add(new ClsParameter("@Base_imponible", c.Base_imponible));
                lst.Add(new ClsParameter("@Igv", c.Igv));
                lst.Add(new ClsParameter("@no_gravada", c.No_gravada));
                lst.Add(new ClsParameter("@descuento", c.Descuento));
                lst.Add(new ClsParameter("@Importe_total", c.Importe_total));
                lst.Add(new ClsParameter("@Dolares", c.Dolares));
                lst.Add(new ClsParameter("@percepcion", c.Perceppcion));
                lst.Add(new ClsParameter("@Detraccion_id", c.Detraccion_id));
                lst.Add(new ClsParameter("@Constancia_detraccion_numero", c.Constancia_detraccion_numero));
                lst.Add(new ClsParameter("@Constancia_detraccion_fecha_pago", c.Constancia_detraccion_fecha_pago));
                lst.Add(new ClsParameter("@Constancia_detraccion_monto", c.Constancia_detraccion_monto));
                lst.Add(new ClsParameter("@monto_referencial", c.Monto_referencial));
                lst.Add(new ClsParameter("@nota_credito_referencia_fecha", c.Nota_credito_referencia_fecha));
                lst.Add(new ClsParameter("@nota_credito_referencia_tipo", c.Nota_credito_referencia_tipo));
                lst.Add(new ClsParameter("@nota_credito_referencia_serie", c.Nota_credito_referencia_serie));
                lst.Add(new ClsParameter("@nota_credito_referencia_numero", c.Nota_credito_referencia_numero));
                lst.Add(new ClsParameter("@Observacion", c.Observacion));
                lst.Add(new ClsParameter("@created_at", c.created_at));
                lst.Add(new ClsParameter("@updated_at", c.updated_at));
                lst.Add(new ClsParameter("@Company_ruc", c.Company_ruc));
                lst.Add(new ClsParameter("@Tipo_moneda", c.Tipo_moneda));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("RegistrarCompra", ref lst);
                return Mensaje = lst[30].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BuscarCompra(String ruc, String objDatos)
        {
            DataTable dt = new DataTable();
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", ruc));
            lst.Add(new ClsParameter("@Datos", objDatos));
            return dt = M.Listado("BuscarCompra", lst);
        }

        #endregion

        #region HELP
        
        public String GenerarIdCompra(string ruc, string cdp_tipo, string cdp_serie, int cdp_numero)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String idVentas = "";
            try
            {
                lst.Add(new ClsParameter("@Ruc", ruc));
                lst.Add(new ClsParameter("@Cdp_tipo", cdp_tipo));
                lst.Add(new ClsParameter("@Cdp_serie", cdp_serie));
                lst.Add(new ClsParameter("@Cdp_numero", cdp_numero));
                lst.Add(new ClsParameter("@CodeCompra", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("GenerarIdCompra", ref lst);

                idVentas = lst[4].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return idVentas;
        }

        #endregion

        public DataTable ListarCompras(String ruc)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", ruc));
            return M.Listado("ListarCompras", lst);
        }
    }
}
