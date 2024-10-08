using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlappyBird
{
    internal class Program
    {
        static Random random = new Random();
        static int gapSize = 5;
        static int ScreenSizeX = 25;
        static int ScreenSizeY = 20;
        static int framesLeftForNewPipe = 20;
        static List<Pipe> pipes = new List<Pipe>();
        static int flappyPositionY = ScreenSizeY / 2;
        static int flappyPlacementX = 5;
        static int gravity = 1;

        static void Main(string[] args)
        {
            Console.SetWindowSize(ScreenSizeX, ScreenSizeY);
            Console.SetBufferSize(ScreenSizeX, ScreenSizeY);
            Console.CursorVisible = false;

            while (true)
            {
                HandleInput();
                MoveFlappyGravity();
                MakeNewPipe();
                MovePipes();
                CheckCollision();
                DrawGame();
                framesLeftForNewPipe += 1;
                Task.Delay(100).Wait(); // Adjusted delay for better responsiveness
            }
        }

        static void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                if (consoleKey.Key == ConsoleKey.Spacebar)
                {
                    flappyPositionY -= 2; // Jump
                }
            }
        }

        static void MoveFlappyGravity()
        {
            flappyPositionY += gravity; // Simulate gravity
            if (flappyPositionY >= ScreenSizeY - 1) // Prevent going off the screen
            {
                flappyPositionY = ScreenSizeY - 1;
            }
        }

        static void MovePipes()
        {
            for (int i = pipes.Count - 1; i >= 0; i--)
            {
                var pipe = pipes[i];
                pipe.positionX -= 1;
                if (pipe.positionX < 0)
                {
                    pipes.RemoveAt(i); // Remove pipe if it reaches the edge of the screen
                }
            }
        }

        static void MakeNewPipe()
        {
            if (framesLeftForNewPipe % 5 == 0)
            {
                int gapPoint = random.Next(0 + gapSize, ScreenSizeY - gapSize);
                Pipe newPipe = new Pipe(ScreenSizeX, gapPoint);
                pipes.Add(newPipe);
            }
        }

        static void CheckCollision()
        {
            foreach (var pipe in pipes)
            {
                bool isInPipeXRange = flappyPlacementX == pipe.positionX;
                bool isInPipeYRange = flappyPositionY < pipe.gapPoint - ((gapSize - 1) / 2) || flappyPositionY > pipe.gapPoint + ((gapSize - 1) / 2);

                if (isInPipeXRange && isInPipeYRange)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game Over!");
                    Console.WriteLine("Press any key to quit");
                    Console.ReadKey();
                    Environment.Exit(0); // Exit the game
                }
            }
        }

        static void DrawGame()
        {
            Console.Clear(); // Reset for next frame
            Console.SetCursorPosition(flappyPlacementX, flappyPositionY);
            Console.Write("O");

            foreach (var pipe in pipes)
            {
                for (int i = 0; i < ScreenSizeY - 1; i++)
                {
                    if (i < pipe.gapPoint - ((gapSize - 1) / 2) || i > pipe.gapPoint + ((gapSize - 1) / 2))
                    {
                        Console.SetCursorPosition(pipe.positionX, i);
                        Console.Write("|");
                    }
                }

            }
        }

        class Pipe
        {
            public int positionX, gapPoint;
            public Pipe(int posX, int gapP) { positionX = posX; gapPoint = gapP; }
        }
    }
}