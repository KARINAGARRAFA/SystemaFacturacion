using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// 
        /// </summary>
        public static int Evento;

        //Datos del Producto
        public static string code_product;
        public static String Product_name;
        public static String Code_trademark;
        public static String Code_category;
        public static String Description;


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.FormLogin());
        }
    }
}
