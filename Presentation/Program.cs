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
        public static int Even_sesion;
        public static int Even_listar_producto;
        public static int Even_listar_Cliente;

        //datoslogin
        public static string ruc_login;
        public static String state;
        public static String ruc_empresa;

        //Datos del Producto Compania
        public static string code_product;
        public static String name_product;
        public static String Code_brand;
        public static String Code_category;
        public static Decimal precio;
        public static String unidad_medida;
        public static String ruc_Pcompany;
        public static int Even_seleccionar_producto;

        //Datos del Cliente
        public static String Ruc_cliente="";
        public static String Business_name="";
        public static String Brand;
        public static String Address="";
        public static String Email;
        public static String Telephone;
        public static String Status;
        public static String Condition;
        public static bool foco;



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.FormLogin());
        }
    }
}
