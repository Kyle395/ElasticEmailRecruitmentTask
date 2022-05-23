using System;


namespace ElasticRecruitmentTask
{
    class Program
    {
        private static bool menu()
        {
            MenuElements menuElements = new MenuElements();
            menuElements.DisplayMainMenu();
            
            switch (Console.ReadLine())
            {
                case "1":
                    menuElements.DisplayTask();
                    break;
                case "2":
                    menuElements.DisplayTask(true);
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
