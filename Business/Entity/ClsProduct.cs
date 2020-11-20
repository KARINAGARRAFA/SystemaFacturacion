using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using DataAccess.Connection;

using System.Data;
using System.Data.SqlClient;
using DataAccess.Entity;
using Business.Generic;

namespace Business.Entity
{
    public class ClsProduct : EntityGeneric
    {


        private String m_code_product;
        private String m_product_name;
        private String m_code_trademark;
        private String m_code_category;
        private String m_description;

  

        public String Code_product
        {
            get { return m_code_product; }
            set { m_code_product = value; }
        }
        public String Product_name
        {
            get { return m_product_name; }
            set { m_product_name = value; }
        }
        public String Code_trademark
        {
            get { return m_code_trademark; }
            set { m_code_trademark = value; }
        }
        public String Code_category
        {
            get { return m_code_category; }
            set { m_code_category = value; }
        }
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
    }
}
