using GameOfWarProject;

public class Program
{
    public static GlobalSettings GlobalSettings { get; private set; }

    public static void Main(string[] args)
    {
        GlobalSettings = new GlobalSettings();

        Console.CursorVisible = false;

        // Open Main Menu
        MainMenuScreen screen = new MainMenuScreen();
        screen.StartMenu();
    }
}
