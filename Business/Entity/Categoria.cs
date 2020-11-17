using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class Categoria : EntityGeneric
    {
        private String m_code_category;
        private String m_category_name;
        private String m_description;

        public String Code_category
        {
            get { return m_code_category; }
            set { m_code_category = value; }
        }
        public String Category_name
        {
            get { return m_category_name; }
            set { m_category_name = value; }
        }
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
    }
}
