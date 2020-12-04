using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            pbLoading.Load("loading.gif");
            pbLoading.Location = new Point(this.Width/2-pbLoading.Width/2, this.Height / 2 - pbLoading.Height / 2);
        }
    }
}
