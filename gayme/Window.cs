using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace gayme
{
    public class Window
    {
        public void Start()
        {
            // Properties
            GameWindowSettings GWS = GameWindowSettings.Default;
            NativeWindowSettings NWS = NativeWindowSettings.Default;

            GWS.IsMultiThreaded = false;
            GWS.RenderFrequency = 60;
            GWS.UpdateFrequency = 60;

            NWS.APIVersion = Version.Parse(input: "4.1.0");
            NWS.Size = new Vector2i(1280, 720);
            NWS.Title = "Fuck you Jeff Bezos!";

            GameWindow Window = new GameWindow(GWS, NWS);

            // Update frames
            int i = 0;

            Window.UpdateFrame += (FrameEventArgs args) =>
            {
                Console.WriteLine($"{ i++ }");
            };

            Window.CenterWindow();
            Window.Run();
        }
    }
}
