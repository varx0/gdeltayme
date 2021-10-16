using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace gayme
{
    public class Program
    {   
        public static void Main(string[] args)
        {   
            // Window Properties
            GameWindowSettings GWS = GameWindowSettings.Default;
            NativeWindowSettings NWS = NativeWindowSettings.Default;

            GWS.IsMultiThreaded = false;
            GWS.RenderFrequency = 60;
            GWS.UpdateFrequency = 60;

            NWS.APIVersion = Version.Parse(input: "4.1.0");
            NWS.Size = new Vector2i(x: 1280, y: 720);
            NWS.Title = "Fuck you Jeff Bezos!";

            GameWindow Window = new GameWindow(GWS, NWS);

            // Update Frame
            int i = 0;

            Window.UpdateFrame += (FrameEventArgs args) =>
            {
                Console.WriteLine($"{i++}");
            };

            Window.CenterWindow();
            Window.Run();
        }
    }
}