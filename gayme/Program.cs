using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace gayme
{
    public static class Program
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
            NWS.Size = new Vector2i(1280, 720);
            NWS.Title = "Fuck you Jeff Bezos!";

            GameWindow Window = new GameWindow(GWS, NWS);

            // Update Frame
            Window.UpdateFrame += (FrameEventArgs args) =>
            {

            };

            Window.CenterWindow();

            ShaderProgram SP = new ShaderProgram() { id = 0 };

            Window.Load += () =>
            {
                ShaderProgram SP = LoadShaderProgram("../../../../VertexShader.glsl", "../../../../FragmentShader.glsl");
            };

            Window.RenderFrame += (FrameEventArgs args) =>
            {
                GL.UseProgram(SP.id);

                GL.Clear(ClearBufferMask.ColorBufferBit);

                Window.SwapBuffers();
            };
            Window.Run();
        }
        private static Shader LoadShader(string ShaderLocation, ShaderType type)
        {
            int ShaderID = GL.CreateShader(type);
            string InfoLog = GL.GetShaderInfoLog(ShaderID);

            GL.ShaderSource(ShaderID, File.ReadAllText(ShaderLocation));
            GL.CompileShader(ShaderID);

            if (!string.IsNullOrEmpty(InfoLog))
            {
                throw new Exception(InfoLog);
            }
            return new Shader() { id = ShaderID };
        }

        private static ShaderProgram LoadShaderProgram(string VertexShaderLocation, string FragmentShaderLocation)
        {
            int ShaderProgramID = GL.CreateProgram();

            Shader VShader = LoadShader(VertexShaderLocation, ShaderType.VertexShader);         // Vertex Shader
            Shader FShader = LoadShader(FragmentShaderLocation, ShaderType.FragmentShader);     // Fragment Shader

            GL.AttachShader(ShaderProgramID, VShader.id);
            GL.AttachShader(ShaderProgramID, FShader.id);
            GL.LinkProgram(ShaderProgramID);
            GL.DetachShader(ShaderProgramID, VShader.id);
            GL.DetachShader(ShaderProgramID, FShader.id);
            GL.DeleteShader(VShader.id);
            GL.DeleteShader(FShader.id);

            string InfoLog = GL.GetProgramInfoLog(ShaderProgramID);

            if (!string.IsNullOrEmpty(InfoLog))
            {
                throw new Exception(InfoLog);
            }
            return new ShaderProgram() { id = ShaderProgramID };
        }

        public struct Shader
        {
            public int id;
        }

        public struct ShaderProgram
        {
            public int id;
        }
    }
}