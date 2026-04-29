using Avalonia;
using System;

namespace Lab3_Avalonia;

class Program
{
    // Initialization code. Don't use any Avalonia, xaml, etc. before this line.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace(); // USUNIĘTO .WithDeveloperTools()
}