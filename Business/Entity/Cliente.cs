using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Generic;
namespace Business.Entity
{
    public class Cliente : EntityGeneric
    {
        private String m_ruc_client;
        private String m_business_name;
        private String m_brand;
        private String m_address;
        private String m_email;
        private String m_telephone;
        private String m_status;
        private String m_condition;

        public String Ruc_client
        {
            get { return m_ruc_client; }
            set { m_ruc_client = value; }
        }
        public String Business_name
        {
            get { return m_business_name; }
            set { m_business_name = value; }
        }
        public String Brand
        {
            get { return m_brand; }
            set { m_brand = value; }
        }
        public String Address
        {
            get { return m_address; }
            set { m_address = value; }
        }
        public String Email
        {
            get { return m_email; }
            set { m_email = value; }
        }
        public String Telephone
        {
            get { return m_telephone; }
            set { m_telephone = value; }
        }
        public String Status
        {
            get { return m_status; }
            set { m_status = value; }
        }
        public String Condition
        {
            get { return m_condition; }
            set { m_condition = value; }
        }
    }
}
