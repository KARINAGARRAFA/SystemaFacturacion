using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class DetalleVenta : EntityGeneric
    {
        private String m_code;
        private String m_code_sales;
        private String m_code_product;
        private int m_cantidad;
        private Decimal m_precio;
        private String m_code_unit;
        private Decimal m_base_imponible;
        private Decimal m_igv;

        public String Code
        {
            get { return m_code; }
            set { m_code = value; }
        }
        public String Code_sales
        {
            get { return m_code_sales; }
            set { m_code_sales = value; }
        }
        public String Code_product
        {
            get { return m_code_product; }
            set { m_code_product = value; }
        }
        public int Cantidad
        {
            get { return m_cantidad; }
            set { m_cantidad = value; }
        }
        public Decimal Precio
        {
            get { return m_precio; }
            set { m_precio = value; }
        }
        public String Code_unit
        {
            get { return m_code_unit; }
            set { m_code_unit = value; }
        }
        public Decimal Base_imponible
        {
            get { return m_base_imponible; }
            set { m_base_imponible = value; }
        }
        public Decimal Igv
        {
            get { return m_igv; }
            set { m_igv = value; }
        }
    }
}
