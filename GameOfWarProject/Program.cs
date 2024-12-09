using GameOfWarProject;

public class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;

        // Open Main Menu
        MainMenuScreen screen = new MainMenuScreen();
        screen.StartMenu();
    }
}
