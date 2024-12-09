using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWarProject
{
    public class MainMenuScreen
    {
        // Options
        List<string> currentOptions = new List<string>();

        List<string> defaultOptions = new List<string>
        {
            "Play",
            "Quit"
        };

        int selectedOption = 0;

        /// <summary>
        /// Start drawing the menu
        /// </summary>
        public void StartMenu()
        {
            // Load Main Menu
            currentOptions = defaultOptions;

            RedrawMenu();
        }

        /// <summary>
        /// Redraws the menu in the console.
        /// </summary>
        /// <param name="key">The key entered</param>
        public void RedrawMenu()
        {
            Console.SetCursorPosition(0, 0);

            if (currentOptions == defaultOptions)
            {
                string title = "Game Of War";
                ConsoleColor currentColor = ConsoleColor.Red;

                for (int i = 0; i < title.Length; i++)
                {
                    if (char.IsWhiteSpace(title[i]))
                        currentColor = currentColor == ConsoleColor.Red ? ConsoleColor.White : Console.ForegroundColor = ConsoleColor.Red;

                    Console.ForegroundColor = currentColor;
                    Console.Write(title[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("===============");
            }
            else
            {
                /*Console.WriteLine("\r\n  ___ ___                       .__                    _____                 \r\n /   |   \\_____    ____    ____ |__| ____    ____     /     \\ _____    ____  \r\n/    ~    \\__  \\  /    \\  / ___\\|  |/    \\  / ___\\   /  \\ /  \\\\__  \\  /    \\ \r\n\\    Y    // __ \\|   |  \\/ /_/  >  |   |  \\/ /_/  > /    Y    \\/ __ \\|   |  \\\r\n \\___|_  /(____  /___|  /\\___  /|__|___|  /\\___  /  \\____|__  (____  /___|  /\r\n       \\/      \\/     \\//_____/         \\//_____/           \\/     \\/     \\/ \r\n");
                Console.WriteLine("Deo - Team Leader, Programmer");
                Console.WriteLine("Alex - Programmer");
                Console.WriteLine("Stefcho - Presentation");
                Console.WriteLine("Kosio - Presenter");
                Console.WriteLine("~~~ for SoftUni Project ~~~");
                Console.WriteLine("===============");*/
            }

            for (int i = 0; i < currentOptions.Count; i++)
            {
                string opt = currentOptions[i];

                if (selectedOption == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(opt);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("----------");
            }

            WaitForKey();
        }

        public void WaitForKey()
        {
            var key = Console.ReadKey(true);

            // When buttons pressed
            if (key.Key == ConsoleKey.Enter)
            {
                switch (selectedOption)
                {
                    case 0:
                        // Play
                        PlayGame();
                        return;
                    case 1:
                        // Quit
                        Environment.Exit(0);
                        return;
                    default:
                        RedrawMenu();
                        break;
                }
            }

            if (key.Key == ConsoleKey.UpArrow)
            {
                if (selectedOption > 0)
                    selectedOption--;
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (selectedOption < currentOptions.Count - 1)
                    selectedOption++;

            }
            RedrawMenu();
        }

        public void PlayGame()
        {
            Console.Clear();

            GameManager gameManager = new GameManager();
            gameManager.StartGame();
        }
    }
}
