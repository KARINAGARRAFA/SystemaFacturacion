using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Generic;

namespace Business.Entity
{
    public class CompanyProduct : EntityGeneric
    {
        private String m_code_product;
        private String m_name_product;
        private String m_code_brand;
        private String m_code_category;
        private Decimal m_precio;
        private String m_unidad_medida;
        private String m_ruc_empresa;

        public String Code_product
        {
            get { return m_code_product; }
            set { m_code_product = value; }
        }
        public String Product_name
        {
            get { return m_name_product; }
            set { m_name_product = value; }
        }
        public String Code_brand
        {
            get { return m_code_brand; }
            set { m_code_brand = value; }
        }
        public String Code_category
        {
            get { return m_code_category; }
            set { m_code_category = value; }
        }
        public Decimal Precio
        {
            get { return m_precio; }
            set { m_precio = value; }
        }
        public String Unidad_medida
        {
            get { return m_unidad_medida; }
            set { m_unidad_medida = value; }
        }
        public String Ruc_empresa
        {
            get { return m_ruc_empresa; }
            set { m_ruc_empresa = value; }
        }
    }
}
