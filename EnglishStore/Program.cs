using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnglishStore.AppForms;
using EnglishStore.Models;

namespace EnglishStore
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static EnglishStoreDB context = new EnglishStoreDB();
        [STAThread]
        static void Main()
        {
            if (!context.Database.Exists())
            {
                MessageBox.Show("Не удается установить соединение с базой данных");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AutorizationForm());
        }
    }
}
