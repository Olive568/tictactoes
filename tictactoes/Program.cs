using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace tictactoes
{
    internal class Program
    {
        static int gamepla = 0;
        static int comwin = 0;
        static int playwin = 0;
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int[,] board = new int[3, 3];
            ini(board);
            game(board);
        }
        static int[,] ini(int[,] board) 
        {
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++) 
                {
                    board[x, y] = 0;
                }
            }
            return board;
        }
        static int[,] game(int[,] board)
        {
            int turn = 0;
            bool cont = true;
            while(cont) 
            {
                display(board);
                if (gamepla == 0 || gamepla % 2 == 0 )
                {
                        if (turn == 0 || turn % 2 == 0)
                        {
                            Console.WriteLine("your turn. pick an X and Y coordinate <0-2,0-2>");
                            string choice = Console.ReadLine();
                            string[] cho = choice.Split('-');
                            int x = int.Parse(cho[0]);
                            int y = int.Parse(cho[1]);
                            board[x, y] = 1;
                        }
                        else if (turn == 1 || turn % 2 == 1)
                        {
                            Logic(board);
                        }
                }
                else if(gamepla == 1 || gamepla % 2 == 1)
                {
                    if (turn == 1 || turn % 2 == 1)
                    {
                        Console.WriteLine("your turn. pick an X and Y coordinate <0-2,0-2>");
                        string choice = Console.ReadLine();
                        string[] cho = choice.Split('-');
                        int x = int.Parse(cho[0]);
                        int y = int.Parse(cho[1]);
                        board[x, y] = 1;
                    }
                    else if (turn == 0 || turn % 2 == 0)
                    {
                        Logic(board);
                    }
                }
                int check = checking(board, cont);
                else if (check == 0)
                {
                    cont = false;
                    Console.WriteLine("Computer Wins!");
                    comwin++;
                }
                else if (check == 1)
                {
                    cont = false;
                    Console.WriteLine("Player Wins!");
                    playwin++;
                }
            }
        }
        static int[,] display(int[,] board) 
        {
            for(int x = 0;x < 2;x++)
            {
                for(int y = 0;y < 2;y++)
                {
                    Console.Write(board[x,y]+ "\t");
                }
                Console.WriteLine();
            }
            return board;
        }
        static int[,] Logic(int[,] board) 
        {
            if (board[1, 1] == 0)
            {
                board[1, 1] = -1;
            }
            else
            {
                for (int x = 0; x < 2;x++)
                {
                    int wina = 0;
                    int winb = 0;
                    int a = 0;
                    int b = 0;
                    for (int y = 0; y < 2;y++)
                    {
                        if (board[x,y] == -1)
                        {
                            wina = x;
                            winb = y;
                        }
                        else if (board[x,y] == 1)
                        {
                            a = x;
                            b = y;
                        }
                        else if (board[x,y] == 0)
                        {
                            if(x == wina || y == winb)
                            {
                                board[x,y] = -1;
                            }
                            else if (x == a || y == b)
                            {
                                board[x, y] = -1;
                            }
                        }
                    }
                }
            }
            return board;
        }
        static int checking(int[,] board, bool cont) 
        {
            //check horizontal
            for (int x = 0; x < 2;x++) 
            {
                if(board[x,0] + board[x,1] + board[x,2] == 3)
                {
                    return 1;
                }
                else if (board[x, 0] + board[x, 1] + board[x, 2] == -3)
                {
                    return 0;
                }
            }
            //check vertical
            for (int y = 0; y < 2;y++) 
            {
                if (board[0,y] + board[1,y] + board[2,y] == 3)
                {
                    return 1;
                }
                else if (board[0, y] + board[1, y] + board[2, y] == -3)
                {
                    return 0;
                }
            }
            //check slant
            if (board[0,0] + board[1,1] + board[2,2] == 3 || board[0,2] + board[1,1] + board[0,2] == 3)
                return 1;
            else if (board[0, 0] + board[1, 1] + board[2, 2] == -3 || board[0, 2] + board[1, 1] + board[0, 2] == -3)
                return 0;
            return -1;
        }
    }
}
