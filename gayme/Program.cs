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
            Window GameWindow = new Window();

            GameWindow.Start();
        }
    }
}