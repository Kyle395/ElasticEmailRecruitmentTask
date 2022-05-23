using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElasticEmail.Api;
using ElasticEmail.Client;
using ElasticEmail.Model;


namespace ElasticRecruitmentTask
{
    class Program
    {
        static bool menu()
        {
            MenuElements menuElements = new MenuElements();
            menuElements.displayMainMenu();
            
            switch (Console.ReadLine())
            {
                case "1":
                    menuElements.displayFirstTask();
                    break;
                case "2":
                    menuElements.displaySecondTask();
                    break;
                case "3":
                    return false;
                default: break;
            }
            return true;
        }
        [STAThread]
        static void Main()
        {
             bool showMenu = true;
             while (showMenu)
             {
                 showMenu = menu();
             }
        }
    }
}
