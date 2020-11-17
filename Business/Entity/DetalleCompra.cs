using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class DetalleCompra : EntityGeneric
    {
        private String m_code;
        private String m_code_purchages;
        private String m_code_product;
        private String m_cantidad;
        private String m_precio;
        private String m_code_unit;
        private String m_base_imponible;
        private String m_igv;

        public String Code
        {
            get { return m_code; }
            set { m_code = value; }
        }
        public String Code_purchages
        {
            get { return m_code_purchages; }
            set { m_code_purchages = value; }
        }
        public String Code_product
        {
            get { return m_code_product; }
            set { m_code_product = value; }
        }
        public String Cantidad
        {
            get { return m_cantidad; }
            set { m_cantidad = value; }
        }
        public String Precio
        {
            get { return m_precio; }
            set { m_precio = value; }
        }
        public String Code_unit
        {
            get { return m_code_unit; }
            set { m_code_unit = value; }
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
    }
}
