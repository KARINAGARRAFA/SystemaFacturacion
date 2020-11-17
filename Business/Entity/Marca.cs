using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class Marca : EntityGeneric
    {
        private String m_code_trademark;
        private String m_trademark_name;
        private String m_description;

        public String Code_trademark
        {
            get { return m_code_trademark; }
            set { m_code_trademark = value; }
        }
        public String Trademark_name
        {
            get { return m_trademark_name; }
            set { m_trademark_name = value; }
        }
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
    }
}
