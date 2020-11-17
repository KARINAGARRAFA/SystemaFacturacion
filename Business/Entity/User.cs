using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Generic;

namespace Business.Entity
{
    public class User : EntityGeneric
    {
        private String m_ruc;
        private String m_business_name;
        private String m_brand;
        private String m_cod_sector;
        private String m_address;
        private String m_email;
        private String m_telephone;
        private String m_status;
        private String m_condition;

        public String Code_ruc
        {
            get { return m_ruc; }
            set { m_ruc = value; }
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
        public String Cod_sector
        {
            get { return m_cod_sector; }
            set { m_cod_sector = value; }
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
