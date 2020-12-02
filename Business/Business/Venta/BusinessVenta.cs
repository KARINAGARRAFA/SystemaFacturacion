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
    public class BusinessVenta
    {
        #region Inicializar

        private ClsManejador M = new ClsManejador();
        #endregion

        #region CRUD
        public String RegistrarVenta(Entity.Venta v)
        {
            String Mensaje = "";
            List<ClsParameter> lst = new List<ClsParameter>();
            try
            {
                lst.Add(new ClsParameter("@Code", v.Code));
                lst.Add(new ClsParameter("@Numero", v.Numero));
                lst.Add(new ClsParameter("@Fecha_emision", v.Fecha_emision));
                lst.Add(new ClsParameter("@Fecha_pago", v.Fecha_pago));
                lst.Add(new ClsParameter("@Cdp_tipo", v.Cdp_tipo));
                lst.Add(new ClsParameter("@Cdp_serie", v.Cdp_serie));
                lst.Add(new ClsParameter("@Cdp_numero", v.Cdp_numero));
                lst.Add(new ClsParameter("@Proveedor_tipo", v.Proveedor_tipo));
                lst.Add(new ClsParameter("@Proveedor_numero", v.Proveedor_numero));
                lst.Add(new ClsParameter("@Valor_exportacion", v.Valor_exportacion));
                lst.Add(new ClsParameter("@Base_imponible", v.Base_imponible));
                lst.Add(new ClsParameter("@Importe_total_exonerada", v.Importe_total_exonerada));
                lst.Add(new ClsParameter("@Importe_total_inafecta", v.Importe_total_inafecta));
                lst.Add(new ClsParameter("@Igv", v.Igv));
                lst.Add(new ClsParameter("@Importe_total", v.Importe_total));
                lst.Add(new ClsParameter("@Dolares", v.Dolares));
                lst.Add(new ClsParameter("@Igv_retencion", v.Igv_retencion));
                lst.Add(new ClsParameter("@Detraccion_id", v.Detraccion_id));
                lst.Add(new ClsParameter("@Constancia_detraccion_numero", v.Constancia_detraccion_numero));
                lst.Add(new ClsParameter("@Constancia_detraccion_fecha_pago", v.Constancia_detraccion_fecha_pago));
                lst.Add(new ClsParameter("@Constancia_detraccion_monto", v.Constancia_detraccion_monto));
                lst.Add(new ClsParameter("@Constancia_detraccion_referencia_monto", v.Constancia_detraccion_referencia_monto));
                lst.Add(new ClsParameter("@Observacion", v.Observacion));
                lst.Add(new ClsParameter("@created_at", v.created_at));
                lst.Add(new ClsParameter("@updated_at", v.updated_at));
                lst.Add(new ClsParameter("@Company_ruc", v.Company_ruc));
                lst.Add(new ClsParameter("@Tipo_moneda", v.Tipo_moneda));
                lst.Add(new ClsParameter("@estado", v.Estado));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("RegistrarVenta", ref lst);
                return Mensaje = lst[28].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BuscarVenta(String ruc,String objDatos)
        {
            DataTable dt = new DataTable();
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", ruc));
            lst.Add(new ClsParameter("@Datos", objDatos));
            return dt = M.Listado("BuscarVenta", lst);
        }
        public DataTable BuscarVenta1(String ruc, String objDatos)
        {
            DataTable dt = new DataTable();
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", ruc));
            lst.Add(new ClsParameter("@Datos", objDatos));
            return dt = M.Listado("BuscarVenta1", lst);
        }

        public DataTable BuscarVentaXfecha(String ruc, DateTime FI, DateTime FF)
        {
            DataTable dt = new DataTable();
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", ruc));
            lst.Add(new ClsParameter("@FechaInicio", FI));
            lst.Add(new ClsParameter("@fechaFin", FF));
            return dt = M.Listado("BuscarVentaFecha", lst);
        }
        public DataTable BuscarVentaXfecha1(String ruc, DateTime FI, DateTime FF)
        {
            DataTable dt = new DataTable();
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", ruc));
            lst.Add(new ClsParameter("@FechaInicio", FI));
            lst.Add(new ClsParameter("@fechaFin", FF));
            return dt = M.Listado("BuscarVentaFecha1", lst);
        }




        #endregion

        #region HELP
        public String NumeroComprobante(String serieDocumento)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String NroCorrelativo = "";
            try
            {
                lst.Add(new ClsParameter("@serie", serieDocumento));
                lst.Add(new ClsParameter("@NroCorrelativo", "", SqlDbType.VarChar, ParameterDirection.Output, 7));
                M.EjecutarSP("consecutive_number", ref lst);
                NroCorrelativo = Convert.ToString(lst[1].Valor.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToString(NroCorrelativo);
        }
        public String ActualizarNumeroCorrelativo(string serie, int numero)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Mensaje = "";

            try
            {
                lst.Add(new ClsParameter("@serie", serie));
                lst.Add(new ClsParameter("@numero", numero));
                lst.Add(new ClsParameter("@Updated_at", DateTime.Now));
                lst.Add(new ClsParameter("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("Update_sfe_consecutive_number", ref lst);
                Mensaje = lst[3].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        public String GenerarIdVentas(string ruc, string cdp_tipo, string cdp_serie, int cdp_numero)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String idVentas = "";
            try
            {
                lst.Add(new ClsParameter("@Ruc", ruc));
                lst.Add(new ClsParameter("@Cdp_tipo", cdp_tipo));
                lst.Add(new ClsParameter("@Cdp_serie", cdp_serie));
                lst.Add(new ClsParameter("@Cdp_numero", cdp_numero));
                lst.Add(new ClsParameter("@CodeVenta", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("GenerarIdVentas", ref lst);

                idVentas = lst[4].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return idVentas;
        }
                
        #endregion

        public DataTable ListarVenta(String ruc)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", ruc));
            return M.Listado("ListarVentas", lst);
        }
        public DataTable ListarVenta1(String ruc)
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            lst.Add(new ClsParameter("@ruc", ruc));
            return M.Listado("ListarVentas1", lst);
        }
        // NO USADO
        public String GenerarSerieDocumento()
        {
            List<ClsParameter> lst = new List<ClsParameter>();
            String Serie = "";
            try
            {
                lst.Add(new ClsParameter("@Serie", "", SqlDbType.VarChar, ParameterDirection.Output, 5));
                M.EjecutarSP("[Serie Documento]", ref lst);
                Serie = Convert.ToString(lst[0].Valor.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToString(Serie);
        }
    }
}
