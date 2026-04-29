using Avalonia;
using System;
using DotNetEnv;

namespace WalutyGUI;

class Program
{

    public static void Main(string[] args)
    {
        try
        {
            Env.Load();
        }
        catch { }
        
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
#if DEBUG
            .WithDeveloperTools()
#endif
            .WithInterFont()
            .LogToTrace();
}
