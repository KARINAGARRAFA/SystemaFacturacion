using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class Venta : EntityGeneric
    {
        private String m_code;
        private int m_numero;
        private DateTime m_fecha_emision;
        private DateTime m_fecha_pago;
        private String m_cdp_tipo;
        private String m_cdp_serie;
        private int m_cdp_numero;
        private String m_proveedor_tipo;
        private String m_proveedor_numero;
        private Decimal m_valor_exportacion;
        private Decimal m_base_imponible;
        private Decimal m_importe_total_exonerada;
        private Decimal m_importe_total_inafecta;
        private Decimal m_igv;
        private Decimal m_importe_total;
        private Decimal m_dolares;
        private Decimal m_igv_retencion;
        private int m_detraccion_id;
        private String m_constancia_detraccion_numero;
        private DateTime m_constancia_detraccion_fecha_pago;
        private Decimal m_constancia_detraccion_monto;
        private Decimal m_constancia_detraccion_referencia_monto;
        private String m_observacion;
        private String m_company_ruc;
        private String m_tipo_moneda;


        public String Code
        {
            get { return m_code; }
            set { m_code = value; }
        }
        public int Numero
        {
            get { return m_numero; }
            set { m_numero = value; }
        }
        public DateTime Fecha_emision
        {
            get { return m_fecha_emision; }
            set { m_fecha_emision = value; }
        }
        public DateTime Fecha_pago
        {
            get { return m_fecha_pago; }
            set { m_fecha_pago = value; }
        }
        public String Cdp_tipo
        {
            get { return m_cdp_tipo; }
            set { m_cdp_tipo = value; }
        }
        public String Cdp_serie
        {
            get { return m_cdp_serie; }
            set { m_cdp_serie = value; }
        }
        public int Cdp_numero
        {
            get { return m_cdp_numero; }
            set { m_cdp_numero = value; }
        }
        public String Proveedor_tipo
        {
            get { return m_proveedor_tipo; }
            set { m_proveedor_tipo = value; }
        }
        public String Proveedor_numero
        {
            get { return m_proveedor_numero; }
            set { m_proveedor_numero = value; }
        }
        public Decimal Valor_exportacion
        {
            get { return m_valor_exportacion; }
            set { m_valor_exportacion = value; }
        }
        public Decimal Base_imponible
        {
            get { return m_base_imponible; }
            set { m_base_imponible = value; }
        }
        public Decimal Importe_total_exonerada
        {
            get { return m_importe_total_exonerada; }
            set { m_importe_total_exonerada = value; }
        }
        public Decimal Importe_total_inafecta
        {
            get { return m_importe_total_inafecta; }
            set { m_importe_total_inafecta = value; }
        }
        public Decimal Igv
        {
            get { return m_igv; }
            set { m_igv = value; }
        }
        public decimal Importe_total
        {
            get { return m_importe_total; }
            set { m_importe_total = value; }
        }
        public Decimal Dolares
        {
            get { return m_dolares; }
            set { m_dolares = value; }
        }
        public Decimal Igv_retencion
        {
            get { return m_igv_retencion; }
            set { m_igv_retencion = value; }
        }
        public int Detraccion_id
        {
            get { return m_detraccion_id; }
            set { m_detraccion_id = value; }
        }
        public String Constancia_detraccion_numero
        {
            get { return m_constancia_detraccion_numero; }
            set { m_constancia_detraccion_numero = value; }
        }
        public DateTime Constancia_detraccion_fecha_pago
        {
            get { return m_constancia_detraccion_fecha_pago; }
            set { m_constancia_detraccion_fecha_pago = value; }
        }
        public Decimal Constancia_detraccion_monto
        {
            get { return m_constancia_detraccion_monto; }
            set { m_constancia_detraccion_monto = value; }
        }
        public Decimal Constancia_detraccion_referencia_monto
        {
            get { return m_constancia_detraccion_referencia_monto; }
            set { m_constancia_detraccion_referencia_monto = value; }
        }
        public String Observacion
        {
            get { return m_observacion; }
            set { m_observacion = value; }
        }
        public String Company_ruc
        {
            get { return m_company_ruc; }
            set { m_company_ruc = value; }
        }
        public String Tipo_moneda
        {
            get { return m_tipo_moneda; }
            set { m_tipo_moneda = value; }
        }
    }
}
