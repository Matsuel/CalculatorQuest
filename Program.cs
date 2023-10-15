using Avalonia;
using System;
namespace CalculatorQuest;
class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);
    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}

//using System.Diagnostics;
//namespace CalculatorQuest
//{
//    class Program
//    {
//        static void Main(string[] str)
//        {
//            Calc c = new Calc();
//            Debug.WriteLine(c.Operator("18+7"));
//            Debug.WriteLine(c.Operator("100%3"));
//            Debug.WriteLine(c.Operator("73/0"));
//            Debug.WriteLine(c.Operator(""));
//            Debug.WriteLine(c.Operator("18+32/5%3.14"));
//        }
//    }
//}
