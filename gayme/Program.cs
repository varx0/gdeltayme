using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;


namespace gayme
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
                GameWindowSettings GWS = GameWindowSettings.Default;
                NativeWindowSettings NWS = NativeWindowSettings.Default;

                GameWindow Window = new GameWindow(GWS, NWS);

                Window.Run();
        }
    }
}

    

