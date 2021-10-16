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

            GWS.IsMultiThreaded = false;
            GWS.RenderFrequency = 60;
            GWS.UpdateFrequency = 60;

            NWS.APIVersion = Version.Parse(input: "4.1.0");
            NWS.Size = new Vector2i(x: 1280, y: 720);
            NWS.Title = "Fuck you Jeff Bezos!";

            GameWindow Window = new GameWindow(GWS, NWS);

            Window.Run();
        }
    }
}
