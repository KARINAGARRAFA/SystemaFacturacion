using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class UnidadMedida : EntityGeneric
    {
        private String m_code_unit;
        private String m_unit_name;
        private String m_description;

        public String Code_unit
        {
            get { return m_code_unit; }
            set { m_code_unit = value; }
        }
        public String Unit_name
        {
            get { return m_unit_name; }
            set { m_unit_name = value; }
        }
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

    }
}
