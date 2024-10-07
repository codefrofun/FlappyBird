using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlappyBird
{
    internal class Program
    {
        static int ScreenSizeX = 25;
        static int ScreenSizeY = 20;

        int Score;
        static int FlappyPositionY = 0;
        const int FlappyPositionX = 5;

        int FrameCount = 0;
        static void Main(string[] args)
        {
            Console.SetWindowSize(ScreenSizeX, ScreenSizeY);
            Console.SetBufferSize(ScreenSizeX, ScreenSizeY);
            Console.CursorVisible = false;

            FlappyPositionY = ScreenSizeY / 2;
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(5, FlappyPositionY);
                Console.Write("O");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    if (keyPressed.Key == ConsoleKey.Spacebar)
                    {
                        FlappyPositionY -= 2;
                    }
                    else
                    {
                        FlappyPositionY += 1;
                    }
                }
                System.Threading.Thread.Sleep(100);
            }
        }

        public void DrawGame()
        {
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.Write(" ");
        }
        /*
                    Console.SetCursorPostion();
                    {
                        while (true)
                        {
                            HandleInput();
                            MoveFlappyGravity();
                            MovePipes();
                            CheckCollision();
                            DrawGame();
                            // Wait for next frame
                            Thread.Sleep(100);
                            Frame Count goes up
                            }
                        }
                    }

                        public class HandleInput();
                        {
                            Check if we have key available
                            if Key is Spacebar
                            Set last frame space bar pressed = 0
                        }
                        MoveFlappyGravity 
                        {
                        if(ConsoleKey.Spacebar < 2;)
                        { 
                            FLappyPositionY ++;
                        }
                        else
                        {
                            FlappyPositionY goes down
                        }


                        public class MovePipes
                        {
                            for (int i = 0; i < pipes.Length; i++)
                            {
                                pipes[i] = GetPipe();
                            }
                                for each pipe, write ' ' on their space. (Use if smaller than gap start bigger than gap end)
                                for each pipe move pipe x - 1
                                for each pipe write '|' on their space(Use if smaller than gap start bigger than gap end);
                                {PipePosX, PipeGapStart, PipeGapEnd};
                        }
        */

    }
}
