using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class CompanyUser : EntityGeneric
    {
        private String m_username;
        private String m_password;
        private String m_state;
        private String m_ruc_company;

        public String Username
        {
            get { return m_username; }
            set { m_username = value; }
        }
        public String Password
        {
            get { return m_password; }
            set { m_password = value; }
        }
        public String State
        {
            get { return m_state; }
            set { m_state = value; }
        }
        public String Ruc_company
        {
            get { return m_ruc_company; }
            set { m_ruc_company = value; }
        }
    }
}
