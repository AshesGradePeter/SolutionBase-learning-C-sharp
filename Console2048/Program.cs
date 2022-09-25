using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Console2048";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WindowHeight = 20;
            Console.WindowWidth = 40;
            GameCore core = new GameCore();
            core.FillInRandomNumber();
            core.FillInRandomNumber();
            DrawMap(core.Map);
            while (true)
            {
                core.GameOver();
                if (core.isGameOver == false)
                {
                    CinKey(core);
                    if (core.isChange == true)//如果地图发生了变化就产生新的随机数，否则不产生
                    {
                        core.FillInRandomNumber();
                        DrawMap(core.Map);
                    }
                }
                else
                {
                    Console.WriteLine("游戏结束！");
                    break;
                }
            }
            Console.ReadLine();
        }
        private static void DrawMap(int[,] map)
        {
            Console.Clear();
            Console.WriteLine("游戏规则：普通2048的游戏规则");
            Console.WriteLine("操作方法：输入WSAD控制上下左右操作，"+ "\r\n" + "然后按回车，输错了删了重新按。" + "\r\n");
            Console.WriteLine("---------------------------------");
            for (int line = 0; line < 4; line++)
            {
                Console.Write("|");
                for (int row = 0; row < 4; row++)
                {
                    Console.Write("   ");
                    Console.Write(map[line,row] + "   |");
                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
            }
        }
        private static void CinKey(GameCore core)
        {
            Console.WriteLine();
            Console.WriteLine("请输入方向(W ↑ S ↓ A ← D →)：");
            switch (Console.ReadLine())
            {
                case "W":
                    core.EnumerateMove(MoveDirection.Up);
                    break;
                case "w":
                    core.EnumerateMove(MoveDirection.Up);
                    break;
                case "S":
                    core.EnumerateMove(MoveDirection.Down);
                    break;
                case "s":
                    core.EnumerateMove(MoveDirection.Down);
                    break;
                case "A":
                    core.EnumerateMove(MoveDirection.Left);
                    break;
                case "a":
                    core.EnumerateMove(MoveDirection.Left);
                    break;
                case "D":
                    core.EnumerateMove(MoveDirection.Right);
                    break;
                case "d":
                    core.EnumerateMove(MoveDirection.Right);
                    break;
                default:                    
                    DrawMap(core.Map);
                    Console.WriteLine("输入方向错误！");
                    CinKey(core);
                    break;
            }
        }
    }
}
