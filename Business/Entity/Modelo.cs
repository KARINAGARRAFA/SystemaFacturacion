using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class Modelo : EntityGeneric
    {
        private String m_code_model;
        private String m_model_name;
        private String m_description;

        public String Code_model
        {
            get { return m_code_model; }
            set { m_code_model = value; }
        }
        public String Model_name
        {
            get { return m_model_name; }
            set { m_model_name = value; }
        }
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
    }
}
