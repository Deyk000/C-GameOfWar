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
            "Options",
            "Made by",
            "Quit"
        };

        List<string> optionsMainOptions = new List<string>
        {
            "Background",
            "Foreground",
            "Back"
        };
        List<string> optionsColorOptions = new List<string>
        {
            "Blue",
            "Yellow",
            "Cyan",
            "Magenta",
            "White",
            "Black",
            "Back"
        };
        List<string> creditsOptions = new List<string>
        {
            "Back"
        };

        int selectedOption = 0;
        bool foregroundColorOptions = false;

        /// <summary>
        /// Start drawing the menu
        /// </summary>
        public void StartMenu()
        {
            // Load Main Menu
            currentOptions = defaultOptions;

            RedrawMenu(false);
        }

        /// <summary>
        /// Redraws the menu in the console.
        /// </summary>
        /// <param name="key">The key entered</param>
        public void RedrawMenu(bool isForOptions)
        {
            if (isForOptions) Console.SetCursorPosition(0, 0); else Console.Clear();

            if (!isForOptions)
            {
                Console.BackgroundColor = Program.GlobalSettings.defaultBackColor;
                // Clear the console to apply the background color to the entire screen
                Console.Clear();
            }

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
                Console.ForegroundColor = Program.GlobalSettings.defaultForeColor;
                Console.WriteLine();
                Console.WriteLine("===============");
            }
            else if (currentOptions == optionsMainOptions || currentOptions == optionsColorOptions)
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
                Console.ForegroundColor = Program.GlobalSettings.defaultForeColor;
                Console.WriteLine();
                Console.WriteLine("===============");
                Console.WriteLine($"Choose which color to {(currentOptions == optionsColorOptions ? "use" : "change")}:");
                Console.WriteLine("----------");
            }
            else if (currentOptions == creditsOptions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ________  ________  _____ ______   _______           ________  ________      ___       __   ________  ________     \r\n|\\   ____\\|\\   __  \\|\\   _ \\  _   \\|\\  ___ \\         |\\   __  \\|\\  _____\\    |\\  \\     |\\  \\|\\   __  \\|\\   __  \\    \r\n\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\\\\\__\\ \\  \\ \\   __/|        \\ \\  \\|\\  \\ \\  \\__/     \\ \\  \\    \\ \\  \\ \\  \\|\\  \\ \\  \\|\\  \\   \r\n \\ \\  \\  __\\ \\   __  \\ \\  \\\\|__| \\  \\ \\  \\_|/__       \\ \\  \\\\\\  \\ \\   __\\     \\ \\  \\  __\\ \\  \\ \\   __  \\ \\   _  _\\  \r\n  \\ \\  \\|\\  \\ \\  \\ \\  \\ \\  \\    \\ \\  \\ \\  \\_|\\ \\       \\ \\  \\\\\\  \\ \\  \\_|      \\ \\  \\|\\__\\_\\  \\ \\  \\ \\  \\ \\  \\\\  \\| \r\n   \\ \\_______\\ \\__\\ \\__\\ \\__\\    \\ \\__\\ \\_______\\       \\ \\_______\\ \\__\\        \\ \\____________\\ \\__\\ \\__\\ \\__\\\\ _\\ \r\n    \\|_______|\\|__|\\|__|\\|__|     \\|__|\\|_______|        \\|_______|\\|__|         \\|____________|\\|__|\\|__|\\|__|\\|__|\r\n                                                                                                                    \r\n");
                Console.ForegroundColor = Program.GlobalSettings.defaultForeColor;

                Console.WriteLine("Deo - Team Leader, Programmer");
                Console.WriteLine("Alex - Programmer");
                Console.WriteLine("Stefcho - Presentation");
                Console.WriteLine("Kosio - Documentation");
                Console.WriteLine("Viki - Presenter");
                Console.WriteLine("~~~ for SoftUni Project ~~~");
                Console.WriteLine("===============");
            }

            for (int i = 0; i < currentOptions.Count; i++)
            {
                string opt = currentOptions[i];

                if (selectedOption == i)
                {
                    if (currentOptions == optionsColorOptions)
                    {
                        if (opt != "Back" && opt != "Black")
                        {
                            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), opt);
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }

                if (currentOptions != optionsColorOptions)
                {
                    Console.WriteLine(opt);
                }
                else
                {
                    Console.Write(opt);
                    Console.BackgroundColor = Program.GlobalSettings.defaultBackColor;
                    Console.ForegroundColor = Program.GlobalSettings.defaultForeColor;
                    if (foregroundColorOptions)
                        Console.WriteLine(Program.GlobalSettings.defaultForeColor.ToString() == opt ? " - Current" : "          ");
                    else
                        Console.WriteLine(Program.GlobalSettings.defaultBackColor.ToString() == opt ? " - Current" : "          ");
                }

                Console.BackgroundColor = Program.GlobalSettings.defaultBackColor;
                Console.ForegroundColor = Program.GlobalSettings.defaultForeColor;

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
                if (currentOptions != optionsColorOptions)
                {
                    switch (selectedOption)
                    {
                        case 0:
                            if (currentOptions == defaultOptions)
                            {
                                // Play
                                PlayGame();
                                return;
                            }
                            else if (currentOptions == creditsOptions)
                            {
                                // Back
                                selectedOption = 0;
                                currentOptions = defaultOptions;
                                Console.Clear();
                                RedrawMenu(false);
                                return;
                            }
                            else if (currentOptions == optionsMainOptions)
                            {
                                // Background Color
                                selectedOption = 0;
                                foregroundColorOptions = false;
                                currentOptions = optionsColorOptions;
                                Console.Clear();
                                RedrawMenu(false);
                                return;
                            }
                            else
                            {
                                // Back
                                selectedOption = 0;
                                currentOptions = defaultOptions;
                                Console.Clear();
                                RedrawMenu(false);
                                return;
                            }
                        case 1:
                            if (currentOptions == defaultOptions)
                            {
                                // Options
                                selectedOption = 0;
                                currentOptions = optionsMainOptions;
                                Console.Clear();
                                RedrawMenu(false);
                                return;
                            }
                            else if (currentOptions == optionsMainOptions)
                            {
                                // Foreground Color
                                selectedOption = 0;
                                foregroundColorOptions = true;
                                currentOptions = optionsColorOptions;
                                Console.Clear();
                                RedrawMenu(false);
                                return;
                            }
                            else
                            {
                                // Back
                                selectedOption = 0;
                                currentOptions = defaultOptions;
                                Console.Clear();
                                RedrawMenu(false);
                                return;
                            }
                        case 2:
                            if (currentOptions == defaultOptions)
                            {
                                // Credits
                                selectedOption = 0;
                                currentOptions = creditsOptions;
                                RedrawMenu(false);
                                return;
                            }
                            else if (currentOptions == optionsMainOptions)
                            {
                                // Back
                                selectedOption = 0;
                                currentOptions = defaultOptions;
                                Console.Clear();
                                RedrawMenu(false);
                                return;
                            }
                            else
                            {
                                // Back
                                currentOptions = defaultOptions;
                                Console.Clear();
                                RedrawMenu(false);
                                return;
                            }
                        case 3:
                            // Quit
                            Environment.Exit(0);
                            return;
                        case 6:
                            // Back
                            selectedOption = 0;
                            currentOptions = defaultOptions;
                            Console.Clear();
                            RedrawMenu(false);
                            return;
                        default:
                            RedrawMenu(false);
                            return;
                    }
                }
                else
                {
                    /*
                    "Blue",
                    "Yellow",
                    "Cyan",
                    "Magenta",
                    "White",
                    "Black"*/
                    switch (optionsColorOptions[selectedOption])
                    {
                        case "Blue":
                            SetColor(ConsoleColor.Blue);
                            RedrawMenu(false);
                            return;
                        case "Yellow":
                            SetColor(ConsoleColor.Yellow);
                            RedrawMenu(false);
                            return;
                        case "Cyan":
                            SetColor(ConsoleColor.Cyan);
                            RedrawMenu(false);
                            return;
                        case "Magenta":
                            SetColor(ConsoleColor.Magenta);
                            RedrawMenu(false);
                            return;
                        case "White":
                            SetColor(ConsoleColor.White);
                            RedrawMenu(false);
                            return;
                        case "Black":
                            SetColor(ConsoleColor.Black);
                            RedrawMenu(false);
                            return;
                        case "Back":
                            selectedOption = 0;
                            currentOptions = defaultOptions;
                            Console.Clear();
                            RedrawMenu(false);
                            return;
                        default:
                            RedrawMenu(false);
                            return;
                    }
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
            RedrawMenu(true);
        }

        public void SetColor(ConsoleColor color)
        {
            if (foregroundColorOptions)
            {
                Program.GlobalSettings.defaultForeColor = color;

                if (color == ConsoleColor.Black && Program.GlobalSettings.defaultBackColor == ConsoleColor.Black)
                {
                    Program.GlobalSettings.defaultBackColor = ConsoleColor.White;
                }

                if (color == ConsoleColor.White && Program.GlobalSettings.defaultBackColor == ConsoleColor.White)
                {
                    Program.GlobalSettings.defaultBackColor = ConsoleColor.Black;
                }
            }
            else
            {
                Program.GlobalSettings.defaultBackColor = color;

                if (color == ConsoleColor.Black && Program.GlobalSettings.defaultForeColor == ConsoleColor.Black)
                {
                    Program.GlobalSettings.defaultForeColor = ConsoleColor.White;
                }

                if (color == ConsoleColor.White && Program.GlobalSettings.defaultForeColor == ConsoleColor.White)
                {
                    Program.GlobalSettings.defaultForeColor = ConsoleColor.Black;
                }
            }
        }

        public void PlayGame()
        {
            Console.Clear();

            GameManager gameManager = new GameManager();
            gameManager.StartGame();
        }
    }
}
