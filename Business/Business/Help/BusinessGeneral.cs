using DataAccess.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Help
{
    public class BusinessGeneral
    {
        #region Inicializar

        private ClsManejador M = new ClsManejador();
        #endregion


        // TABLA : VOUCHER TIPO
        public DataTable ListarTipoDocumento()
        {
            return M.Listado("sfe_voucherType_list", null);
        }
    }
}
