﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class Compra : EntityGeneric
    {
        private String m_code_purchages;
        private String m_numero;
        private String m_fecha_emision;
        private String m_fecha_pago;
        private String m_cdp_tipo;
        private String m_cdp_serie;
        private String m_cdp_numero;
        private String m_proveedor_tipo;
        private String m_proveedor_numero;
        private String m_base_imponible;
        private String m_igv;
        private String m_no_gravada;
        private String m_descuento;
        private String m_importe_total;
        private String m_dolares;
        private String m_tipo_cambio;
        private String m_perceppcion;
        private String m_detraccion_id;
        private String m_constancia_detraccion_numero;
        private String m_constancia_detraccion_fecha_pago;
        private String m_constancia_detraccion_monto;
        private String m_monto_referencial;
        private String m_nota_credito_referencia_fecha;
        private String m_nota_credito_referencia_tipo;
        private String m_nota_credito_referencia_serie;
        private String m_nota_credito_referencia_numero;
        private String m_observacion;
        private String m_company_ruc;


        public String Code_purchages
        {
            get { return m_code_purchages; }
            set { m_code_purchages = value; }
        }
        public String Numero
        {
            get { return m_numero; }
            set { m_numero = value; }
        }
        public String Fecha_emision
        {
            get { return m_fecha_emision; }
            set { m_fecha_emision = value; }
        }
        public String Fecha_pago
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
        public String Cdp_numero
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
        public String Base_imponible
        {
            get { return m_base_imponible; }
            set { m_base_imponible = value; }
        }
        public String Igv
        {
            get { return m_igv; }
            set { m_igv = value; }
        }
        public String No_gravada
        {
            get { return m_no_gravada; }
            set { m_no_gravada = value; }
        }
        public String Descuento
        {
            get { return m_descuento; }
            set { m_descuento = value; }
        }
        public String Importe_total
        {
            get { return m_importe_total; }
            set { m_importe_total = value; }
        }
        public String Dolares
        {
            get { return m_dolares; }
            set { m_dolares = value; }
        }
        public String Tipo_cambio
        {
            get { return m_tipo_cambio; }
            set { m_tipo_cambio = value; }
        }
        public String Perceppcion
        {
            get { return m_perceppcion; }
            set { m_perceppcion = value; }
        }
        public String Detraccion_id
        {
            get { return m_detraccion_id; }
            set { m_detraccion_id = value; }
        }
        public String Constancia_detraccion_numero
        {
            get { return m_constancia_detraccion_numero; }
            set { m_constancia_detraccion_numero = value; }
        }
        public String Constancia_detraccion_fecha_pago
        {
            get { return m_constancia_detraccion_fecha_pago; }
            set { m_constancia_detraccion_fecha_pago = value; }
        }
        public String Constancia_detraccion_monto
        {
            get { return m_constancia_detraccion_monto; }
            set { m_constancia_detraccion_monto = value; }
        }
        public String Monto_referencial
        {
            get { return m_monto_referencial; }
            set { m_monto_referencial = value; }
        }
        public String Nota_credito_referencia_fecha
        {
            get { return m_nota_credito_referencia_fecha; }
            set { m_nota_credito_referencia_fecha = value; }
        }
        public String Nota_credito_referencia_tipo
        {
            get { return m_nota_credito_referencia_tipo; }
            set { m_nota_credito_referencia_tipo = value; }
        }
        public String Nota_credito_referencia_serie
        {
            get { return m_nota_credito_referencia_serie; }
            set { m_nota_credito_referencia_serie = value; }
        }
        public String Nota_credito_referencia_numero
        {
            get { return m_nota_credito_referencia_numero; }
            set { m_nota_credito_referencia_numero = value; }
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
    }
}
