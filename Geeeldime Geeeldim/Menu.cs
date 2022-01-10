using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geeeldime_Geeeldim
{
    class Menu
    {
        public int selectedIndex;
        public string[] options;
        public string prompt;

        public Menu(string prompt, string[] options)
        {
            this.prompt = prompt;
            this.options = options;
            selectedIndex = 0;
        }
        public void DisplayOptions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.ResetColor();
            for (int i = 0; i < options.Length; i++)
            {
                string currentOption = options[i];
                string prefix;

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"{currentOption}");
                Console.ResetColor();
            }
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }
        public void MainMenu()
        {
            string prompt = @"
   _____   .__   .__                     .___       .__     .__                      .__                           
  /  _  \  |  |  |__|_____________     __| _/ ____  |  |__  |  |__     ___________   |  |    ____    ____    ____  
 /  /_\  \ |  |  |  |\___   /\__  \   / __ |_/ __ \ |  |  \ |  |  \   /  ___/\__  \  |  |   /  _ \  /  _ \  /    \ 
/    |    \|  |__|  | /    /  / __ \_/ /_/ |\  ___/ |   Y  \|   Y  \  \___ \  / __ \_|  |__(  <_> )(  <_> )|   |  \
\____|__  /|____/|__|/_____ \(____  /\____ | \___  >|___|  /|___|  / /____  >(____  /|____/ \____/  \____/ |___|  /
        \/                 \/     \/      \/     \/      \/      \/       \/      \/                            \/ 
";
            string[] options = { @"
                                                     B R A N D S", @"
                                                     M O D E L S", @"
                                                       C A R S" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
        }
        public void BrandMenu()
        {
            string prompt = @"
                                            __________                             .___       
                                            \______   \_______ _____     ____    __| _/ ______
                                             |    |  _/\_  __ \\__  \   /    \  / __ | /  ___/
                                             |    |   \ |  | \/ / __ \_|   |  \/ /_/ | \___ \ 
                                             |______  / |__|   (____  /|___|  /\____ |/____  >
                                                    \/              \/      \/      \/     \/
                                    ";
                string[] options = { @"
                                                     A D D   B R A N D", @"
                                                    E D I T   B R A N D", @"
                                                  R E M O V E   B R A N D", @"
                                                L I S T   O F   B R A N D S", @"
                                                     " };



            Menu brandMenu = new Menu(prompt, options);
            int selectedIndex = brandMenu.Run();
        }
        public void ModelMenu()
        {
            string prompt = @"
                                               _____               .___       .__           
                                              /     \    ____    __| _/ ____  |  |    ______
                                             /  \ /  \  /  _ \  / __ |_/ __ \ |  |   /  ___/
                                            /    Y    \(  <_> )/ /_/ |\  ___/ |  |__ \___ \ 
                                            \____|__  / \____/ \____ | \___  >|____//____  >
                                                    \/              \/     \/            \/ 
";
            string[] options = { @"
                                                     A D D   M O D E L", @"
                                                    E D I T   M O D E L", @"
                                                  R E M O V E   M O D E L", @"
                                                L I S T   O F   M O D E L S", @"
                                                     " };
            Menu modelMenu = new Menu(prompt, options);
            int selectedIndex = modelMenu.Run();
        }
        public void CarMenu()
        {
            string prompt = @"




                                                 _________                        
                                                 \_   ___ \ _____  _______  ______
                                                 /    \  \/ \__  \ \_  __ \/  ___/
                                                 \     \____ / __ \_|  | \/\___ \ 
                                                  \______  /(____  /|__|  /____  >
                                                         \/      \/            \/
";
            string[] options = { @"
                                                     A D D   C A R", @"
                                                    E D I T   C A R", @"
                                                  R E M O V E   C A R", @"
                                                L I S T   O F   C A R S", @"
                                                     " };
            Menu carMenu = new Menu(prompt, options);
            int selectedIndex = carMenu.Run();
        }
    }
    
}
