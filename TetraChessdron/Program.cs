// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace TetraChessdron
{
    class TetraChessdron
    {
        private static List<List<List<CubeCell>>> xYZCube = MakeCube();
        private static bool thePlayersTurnBool = true;

        static void Main(string[] args)
        {
            bool theGameIsOngoing = true;

            Console.WriteLine("Hello, World!");
            WriteTetrahedronBoardOntoCube();
            SetupTeams();
            PrintBoardToConsole();
            while (theGameIsOngoing == true)
            {
                if (thePlayersTurnBool == true)
                {
                    Console.WriteLine("Player one's turn");
                }
                else
                {
                    Console.WriteLine("Player two's turn");
                }
                CheckCheck();
                MoveAPiece();
                thePlayersTurnBool = !thePlayersTurnBool;
            }
        }
        private static void CheckCheck()
        {
            for (int xSelectionInt = 1; xSelectionInt < 9; xSelectionInt++)
            {
                for (int ySelectionInt = 1; ySelectionInt < 9; ySelectionInt++)
                {
                    for (int zSelectionInt = 1; zSelectionInt < 9; zSelectionInt++)
                    {
                        if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() != null)
                        {
                            if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() != "   ")
                            {
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " R ")
                                {
                                    List<string> pieceList = new List<string>
                                    {
                                       " R "," KN"," B "," Q "," K "," P "," r "," kn"," b "," q "," p "
                                    };
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                                        new List<int> {1,1,0},
                                        new List<int> {1,0,1},
                                        new List<int> {0,1,1},
                                        new List<int> {-1,1,0},
                                        new List<int> {-1,0,1},
                                        new List<int> {0,-1,1},
                                        new List<int> {1,-1,0},
                                        new List<int> {1,0,-1},
                                        new List<int> {0,1,-1},
                                        new List<int> {-1,-1,0},
                                        new List<int> {-1,0,-1},
                                        new List<int> {0,-1,-1}
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                        for (int index = 1; index < 8; index++)
                                        {
                                            int x = (moveVector[0] * index) + xSelectionInt;
                                            int y = (moveVector[1] * index) + ySelectionInt;
                                            int z = (moveVector[2] * index) + zSelectionInt;
                                            if (x < 9)
                                            {
                                                if (x > 0)
                                                {
                                                    if (y < 9)
                                                    {
                                                        if (y > 0)
                                                        {
                                                            if (z < 9)
                                                            {
                                                                if (z > 0)
                                                                {
                                                                    if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                                    {
                                                                        break;
                                                                    }

                                                                    if (xYZCube[x][y][z].GetCellContents() == " k ")
                                                                    {
                                                                        xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                        xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                        PrintBoardToConsole();
                                                                        Console.WriteLine("player 2's king is in check");
                                                                        if (thePlayersTurnBool == true)
                                                                        {
                                                                            Console.WriteLine("Player one's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player two's turn");
                                                                        }
                                                                        return;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " B ")
                                {
                                    List<string> pieceList = new List<string>
                                    {
                                       " R "," KN"," B "," Q "," K "," P "," r "," kn"," b "," q "," p "
                                    };
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                                         new List<int> {2,1,1},
                                         new List<int> {1,2,1},
                                         new List<int> {1,1,2},
                                         new List<int> {2,1,-1},
                                         new List<int> {1,2,-1},
                                         new List<int> {1,1,-2},
                                         new List<int> {2,-1,1},
                                         new List<int> {1,-2,1},
                                         new List<int> {1,-1,2},
                                         new List<int> {-2,1,1},
                                         new List<int> {-1,2,1},
                                         new List<int> {-1,1,2},
                                         new List<int> {2,-1,-1},
                                         new List<int> {1,-2,-1},
                                         new List<int> {1,-1,-2},
                                         new List<int> {-2,1,-1},
                                         new List<int> {-1,2,-1},
                                         new List<int> {-1,1,-2},
                                         new List<int> {-2,-1,1},
                                         new List<int> {-1,-2,1},
                                         new List<int> {-1,-1,2},
                                         new List<int> {-2,-1,-1},
                                         new List<int> {-1,-2,-1},
                                         new List<int> {-1,-1,-2}
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                        for (int index = 1; index < 8; index++)
                                        {
                                            int x = (moveVector[0] * index) + xSelectionInt;
                                            int y = (moveVector[1] * index) + ySelectionInt;
                                            int z = (moveVector[2] * index) + zSelectionInt;
                                            if (x < 9)
                                            {
                                                if (x > 0)
                                                {
                                                    if (y < 9)
                                                    {
                                                        if (y > 0)
                                                        {
                                                            if (z < 9)
                                                            {
                                                                if (z > 0)
                                                                {
                                                                    if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                                    {
                                                                        break;
                                                                    }

                                                                    if (xYZCube[x][y][z].GetCellContents() == " k ")
                                                                    {
                                                                        xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                        xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                        PrintBoardToConsole();
                                                                        Console.WriteLine("player 2's king is in check");
                                                                        if (thePlayersTurnBool == true)
                                                                        {
                                                                            Console.WriteLine("Player one's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player two's turn");
                                                                        }
                                                                        return;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " Q ")
                                {
                                    List<string> pieceList = new List<string>
                                    {
                                       " R "," KN"," B "," Q "," K "," P "," r "," kn"," b "," q "," p "
                                    };
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                                        new List<int> {1,1,0},
                                        new List<int> {1,0,1},
                                        new List<int> {0,1,1},
                                        new List<int> {-1,1,0},
                                        new List<int> {-1,0,1},
                                        new List<int> {0,-1,1},
                                        new List<int> {1,-1,0},
                                        new List<int> {1,0,-1},
                                        new List<int> {0,1,-1},
                                        new List<int> {-1,-1,0},
                                        new List<int> {-1,0,-1},
                                        new List<int> {0,-1,-1},
                                        new List<int> {2,1,1},
                                        new List<int> {1,2,1},
                                        new List<int> {1,1,2},
                                        new List<int> {2,1,-1},
                                        new List<int> {1,2,-1},
                                        new List<int> {1,1,-2},
                                        new List<int> {2,-1,1},
                                        new List<int> {1,-2,1},
                                        new List<int> {1,-1,2},
                                        new List<int> {-2,1,1},
                                        new List<int> {-1,2,1},
                                        new List<int> {-1,1,2},
                                        new List<int> {2,-1,-1},
                                        new List<int> {1,-2,-1},
                                        new List<int> {1,-1,-2},
                                        new List<int> {-2,1,-1},
                                        new List<int> {-1,2,-1},
                                        new List<int> {-1,1,-2},
                                        new List<int> {-2,-1,1},
                                        new List<int> {-1,-2,1},
                                        new List<int> {-1,-1,2},
                                        new List<int> {-2,-1,-1},
                                        new List<int> {-1,-2,-1},
                                        new List<int> {-1,-1,-2}
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                        for (int index = 1; index < 8; index++)
                                        {
                                            int x = (moveVector[0] * index) + xSelectionInt;
                                            int y = (moveVector[1] * index) + ySelectionInt;
                                            int z = (moveVector[2] * index) + zSelectionInt;
                                            if (x < 9)
                                            {
                                                if (x > 0)
                                                {
                                                    if (y < 9)
                                                    {
                                                        if (y > 0)
                                                        {
                                                            if (z < 9)
                                                            {
                                                                if (z > 0)
                                                                {
                                                                    if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                                    {
                                                                        break;
                                                                    }

                                                                    if (xYZCube[x][y][z].GetCellContents() == " k ")
                                                                    {
                                                                        xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                        xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                        PrintBoardToConsole();
                                                                        Console.WriteLine("player 2's king is in check");
                                                                        if (thePlayersTurnBool == true)
                                                                        {
                                                                            Console.WriteLine("Player one's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player two's turn");
                                                                        }
                                                                        return;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " KN")
                                {
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                    new List<int> {1,2,3},
                    new List<int> {2,1,3},
                    new List<int> {2,3,1},
                    new List<int> {3,2,1},
                    new List<int> {3,1,2},
                    new List<int> {1,3,2},
                    new List<int> {1,2,-3},
                    new List<int> {2,1,-3},
                    new List<int> {2,3,-1},
                    new List<int> {3,2,-1},
                    new List<int> {3,1,-2},
                    new List<int> {1,3,-2},
                    new List<int> {1,-2,3},
                    new List<int> {2,-1,3},
                    new List<int> {2,-3,1},
                    new List<int> {3,-2,1},
                    new List<int> {3,-1,2},
                    new List<int> {1,-3,2},
                    new List<int> {-1,2,3},
                    new List<int> {-2,1,3},
                    new List<int> {-2,3,1},
                    new List<int> {-3,2,1},
                    new List<int> {-3,1,2},
                    new List<int> {-1,3,2},
                    new List<int> {1,-2,-3},
                    new List<int> {2,-1,-3},
                    new List<int> {2,-3,-1},
                    new List<int> {3,-2,-1},
                    new List<int> {3,-1,-2},
                    new List<int> {1,-3,-2},
                    new List<int> {-1,2,-3},
                    new List<int> {-2,1,-3},
                    new List<int> {-2,3,-1},
                    new List<int> {-3,2,-1},
                    new List<int> {-3,1,-2},
                    new List<int> {-1,3,-2},
                    new List<int> {-1,-2,3},
                    new List<int> {-2,-1,3},
                    new List<int> {-2,-3,1},
                    new List<int> {-3,-2,1},
                    new List<int> {-3,-1,2},
                    new List<int> {-1,-3,2},
                    new List<int> {-1,-2,-3},
                    new List<int> {-2,-1,-3},
                    new List<int> {-2,-3,-1},
                    new List<int> {-3,-2,-1},
                    new List<int> {-3,-1,-2},
                    new List<int> {-1,-3,-2},
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                            int x = moveVector[0] + xSelectionInt;
                                            int y = moveVector[1] + ySelectionInt;
                                            int z = moveVector[2] + zSelectionInt;
                                            if (x < 9)
                                            {
                                                if (x > 0)
                                                {
                                                    if (y < 9)
                                                    {
                                                        if (y > 0)
                                                        {
                                                            if (z < 9)
                                                            {
                                                                if (z > 0)
                                                                {
                                                                    if (xYZCube[x][y][z].GetCellContents() == " k ")
                                                                    {
                                                                        xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                        xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                        PrintBoardToConsole();
                                                                        Console.WriteLine("player 2's king is in check");
                                                                        if (thePlayersTurnBool == true)
                                                                        {
                                                                            Console.WriteLine("Player one's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player two's turn");
                                                                        }
                                                                        return;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                    }
                                }
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " P ")
                                {
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                                        new List<int> {2,1,1},
                                        new List<int> {1,2,1},
                                        new List<int> {1,1,2},
                                        new List<int> {2,1,-1},
                                        new List<int> {1,2,-1},
                                        new List<int> {1,1,-2},
                                        new List<int> {2,-1,1},
                                        new List<int> {1,-2,1},
                                        new List<int> {1,-1,2},
                                        new List<int> {2,-1,-1},
                                        new List<int> {1,-2,-1},
                                        new List<int> {1,-1,-2}
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                        int x = moveVector[0] + xSelectionInt;
                                        int y = moveVector[1] + ySelectionInt;
                                        int z = moveVector[2] + zSelectionInt;
                                        if (x < 9)
                                        {
                                            if (x > 0)
                                            {
                                                if (y < 9)
                                                {
                                                    if (y > 0)
                                                    {
                                                        if (z < 9)
                                                        {
                                                            if (z > 0)
                                                            {
                                                                if (xYZCube[x][y][z].GetCellContents() == " k ")
                                                                {
                                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                    xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                    PrintBoardToConsole();
                                                                    Console.WriteLine("player 2's king is in check");
                                                                    if (thePlayersTurnBool == true)
                                                                    {
                                                                        Console.WriteLine("Player one's turn");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Player two's turn");
                                                                    }
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " r ")
                                {
                                    List<string> pieceList = new List<string>
                                    {
                                       " R "," KN"," B "," Q "," k "," P "," r "," kn"," b "," q "," p "
                                    };
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                                        new List<int> {1,1,0},
                                        new List<int> {1,0,1},
                                        new List<int> {0,1,1},
                                        new List<int> {-1,1,0},
                                        new List<int> {-1,0,1},
                                        new List<int> {0,-1,1},
                                        new List<int> {1,-1,0},
                                        new List<int> {1,0,-1},
                                        new List<int> {0,1,-1},
                                        new List<int> {-1,-1,0},
                                        new List<int> {-1,0,-1},
                                        new List<int> {0,-1,-1}
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                        for (int index = 1; index < 8; index++)
                                        {
                                            int x = (moveVector[0] * index) + xSelectionInt;
                                            int y = (moveVector[1] * index) + ySelectionInt;
                                            int z = (moveVector[2] * index) + zSelectionInt;
                                            if (x < 9)
                                            {
                                                if (x > 0)
                                                {
                                                    if (y < 9)
                                                    {
                                                        if (y > 0)
                                                        {
                                                            if (z < 9)
                                                            {
                                                                if (z > 0)
                                                                {
                                                                    if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                                    {
                                                                        break;
                                                                    }

                                                                    if (xYZCube[x][y][z].GetCellContents() == " K ")
                                                                    {
                                                                        xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                        xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                        PrintBoardToConsole();
                                                                        Console.WriteLine("player 1's king is in check");
                                                                        if (thePlayersTurnBool == true)
                                                                        {
                                                                            Console.WriteLine("Player one's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player two's turn");
                                                                        }
                                                                        return;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " b ")
                                {
                                    List<string> pieceList = new List<string>
                                    {
                                       " R "," KN"," B "," Q "," k "," P "," r "," kn"," b "," q "," p "
                                    };
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                                         new List<int> {2,1,1},
                                         new List<int> {1,2,1},
                                         new List<int> {1,1,2},
                                         new List<int> {2,1,-1},
                                         new List<int> {1,2,-1},
                                         new List<int> {1,1,-2},
                                         new List<int> {2,-1,1},
                                         new List<int> {1,-2,1},
                                         new List<int> {1,-1,2},
                                         new List<int> {-2,1,1},
                                         new List<int> {-1,2,1},
                                         new List<int> {-1,1,2},
                                         new List<int> {2,-1,-1},
                                         new List<int> {1,-2,-1},
                                         new List<int> {1,-1,-2},
                                         new List<int> {-2,1,-1},
                                         new List<int> {-1,2,-1},
                                         new List<int> {-1,1,-2},
                                         new List<int> {-2,-1,1},
                                         new List<int> {-1,-2,1},
                                         new List<int> {-1,-1,2},
                                         new List<int> {-2,-1,-1},
                                         new List<int> {-1,-2,-1},
                                         new List<int> {-1,-1,-2}
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                        for (int index = 1; index < 8; index++)
                                        {
                                            int x = (moveVector[0] * index) + xSelectionInt;
                                            int y = (moveVector[1] * index) + ySelectionInt;
                                            int z = (moveVector[2] * index) + zSelectionInt;
                                            if (x < 9)
                                            {
                                                if (x > 0)
                                                {
                                                    if (y < 9)
                                                    {
                                                        if (y > 0)
                                                        {
                                                            if (z < 9)
                                                            {
                                                                if (z > 0)
                                                                {
                                                                    if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                                    {
                                                                        break;
                                                                    }

                                                                    if (xYZCube[x][y][z].GetCellContents() == " K ")
                                                                    {
                                                                        xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                        xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                        PrintBoardToConsole();
                                                                        Console.WriteLine("player 1's king is in check");
                                                                        if (thePlayersTurnBool == true)
                                                                        {
                                                                            Console.WriteLine("Player one's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player two's turn");
                                                                        }
                                                                        return;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " q ")
                                {
                                    List<string> pieceList = new List<string>
                                    {
                                       " R "," KN"," B "," Q "," k "," P "," r "," kn"," b "," q "," p "
                                    };
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                                        new List<int> {1,1,0},
                                        new List<int> {1,0,1},
                                        new List<int> {0,1,1},
                                        new List<int> {-1,1,0},
                                        new List<int> {-1,0,1},
                                        new List<int> {0,-1,1},
                                        new List<int> {1,-1,0},
                                        new List<int> {1,0,-1},
                                        new List<int> {0,1,-1},
                                        new List<int> {-1,-1,0},
                                        new List<int> {-1,0,-1},
                                        new List<int> {0,-1,-1},
                                        new List<int> {2,1,1},
                                        new List<int> {1,2,1},
                                        new List<int> {1,1,2},
                                        new List<int> {2,1,-1},
                                        new List<int> {1,2,-1},
                                        new List<int> {1,1,-2},
                                        new List<int> {2,-1,1},
                                        new List<int> {1,-2,1},
                                        new List<int> {1,-1,2},
                                        new List<int> {-2,1,1},
                                        new List<int> {-1,2,1},
                                        new List<int> {-1,1,2},
                                        new List<int> {2,-1,-1},
                                        new List<int> {1,-2,-1},
                                        new List<int> {1,-1,-2},
                                        new List<int> {-2,1,-1},
                                        new List<int> {-1,2,-1},
                                        new List<int> {-1,1,-2},
                                        new List<int> {-2,-1,1},
                                        new List<int> {-1,-2,1},
                                        new List<int> {-1,-1,2},
                                        new List<int> {-2,-1,-1},
                                        new List<int> {-1,-2,-1},
                                        new List<int> {-1,-1,-2}
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                        for (int index = 1; index < 8; index++)
                                        {
                                            int x = (moveVector[0] * index) + xSelectionInt;
                                            int y = (moveVector[1] * index) + ySelectionInt;
                                            int z = (moveVector[2] * index) + zSelectionInt;
                                            if (x < 9)
                                            {
                                                if (x > 0)
                                                {
                                                    if (y < 9)
                                                    {
                                                        if (y > 0)
                                                        {
                                                            if (z < 9)
                                                            {
                                                                if (z > 0)
                                                                {
                                                                    if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                                    {
                                                                        break;
                                                                    }

                                                                    if (xYZCube[x][y][z].GetCellContents() == " K ")
                                                                    {
                                                                        xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                        xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                        PrintBoardToConsole();
                                                                        Console.WriteLine("player 1's king is in check");
                                                                        if (thePlayersTurnBool == true)
                                                                        {
                                                                            Console.WriteLine("Player one's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player two's turn");
                                                                        }
                                                                        return;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " kn")
                                {
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                                        new List<int> {1,2,3},
                                        new List<int> {2,1,3},
                                        new List<int> {2,3,1},
                                        new List<int> {3,2,1},
                                        new List<int> {3,1,2},
                                        new List<int> {1,3,2},
                                        new List<int> {1,2,-3},
                                        new List<int> {2,1,-3},
                                        new List<int> {2,3,-1},
                                        new List<int> {3,2,-1},
                                        new List<int> {3,1,-2},
                                        new List<int> {1,3,-2},
                                        new List<int> {1,-2,3},
                                        new List<int> {2,-1,3},
                                        new List<int> {2,-3,1},
                                        new List<int> {3,-2,1},
                                        new List<int> {3,-1,2},
                                        new List<int> {1,-3,2},
                                        new List<int> {-1,2,3},
                                        new List<int> {-2,1,3},
                                        new List<int> {-2,3,1},
                                        new List<int> {-3,2,1},
                                        new List<int> {-3,1,2},
                                        new List<int> {-1,3,2},
                                        new List<int> {1,-2,-3},
                                        new List<int> {2,-1,-3},
                                        new List<int> {2,-3,-1},
                                        new List<int> {3,-2,-1},
                                        new List<int> {3,-1,-2},
                                        new List<int> {1,-3,-2},
                                        new List<int> {-1,2,-3},
                                        new List<int> {-2,1,-3},
                                        new List<int> {-2,3,-1},
                                        new List<int> {-3,2,-1},
                                        new List<int> {-3,1,-2},
                                        new List<int> {-1,3,-2},
                                        new List<int> {-1,-2,3},
                                        new List<int> {-2,-1,3},
                                        new List<int> {-2,-3,1},
                                        new List<int> {-3,-2,1},
                                        new List<int> {-3,-1,2},
                                        new List<int> {-1,-3,2},
                                        new List<int> {-1,-2,-3},
                                        new List<int> {-2,-1,-3},
                                        new List<int> {-2,-3,-1},
                                        new List<int> {-3,-2,-1},
                                        new List<int> {-3,-1,-2},
                                        new List<int> {-1,-3,-2},
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                        int x = moveVector[0] + xSelectionInt;
                                        int y = moveVector[1] + ySelectionInt;
                                        int z = moveVector[2] + zSelectionInt;
                                        if (x < 9)
                                        {
                                            if (x > 0)
                                            {
                                                if (y < 9)
                                                {
                                                    if (y > 0)
                                                    {
                                                        if (z < 9)
                                                        {
                                                            if (z > 0)
                                                            {
                                                                if (xYZCube[x][y][z].GetCellContents() == " K ")
                                                                {
                                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                    xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                    PrintBoardToConsole();
                                                                    Console.WriteLine("player 1's king is in check");
                                                                    if (thePlayersTurnBool == true)
                                                                    {
                                                                        Console.WriteLine("Player one's turn");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Player two's turn");
                                                                    }
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " p ")
                                {
                                    List<List<int>> Moveset = new List<List<int>>
                                    {
                                        new List<int> {-2,1,1},
                                        new List<int> {-1,2,1},
                                        new List<int> {-1,1,2},
                                        new List<int> {-2,1,-1},
                                        new List<int> {-1,2,-1},
                                        new List<int> {-1,1,-2},
                                        new List<int> {-2,-1,1},
                                        new List<int> {-1,-2,1},
                                        new List<int> {-1,-1,2},
                                        new List<int> {-2,-1,-1},
                                        new List<int> {-1,-2,-1},
                                        new List<int> {-1,-1,-2}
                                    };

                                    foreach (List<int> moveVector in Moveset)
                                    {
                                        int x = moveVector[0] + xSelectionInt;
                                        int y = moveVector[1] + ySelectionInt;
                                        int z = moveVector[2] + zSelectionInt;
                                        if (x < 9)
                                        {
                                            if (x > 0)
                                            {
                                                if (y < 9)
                                                {
                                                    if (y > 0)
                                                    {
                                                        if (z < 9)
                                                        {
                                                            if (z > 0)
                                                            {
                                                                if (xYZCube[x][y][z].GetCellContents() == " K ")
                                                                {
                                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                    xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                    PrintBoardToConsole();
                                                                    Console.WriteLine("player 1's king is in check");
                                                                    if (thePlayersTurnBool == true)
                                                                    {
                                                                        Console.WriteLine("Player one's turn");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Player two's turn");
                                                                    }
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private static void MoveAPiece()
        {
            Console.WriteLine("select a location to move from:");
            string xSelectionString = Console.ReadLine();
            int xSelectionInt = int.Parse(xSelectionString);
            string ySelectionString = Console.ReadLine();
            int ySelectionInt = int.Parse(ySelectionString);
            string zSelectionString = Console.ReadLine();
            int zSelectionInt = int.Parse(zSelectionString);

            string copySelectedPieceString = xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents();

            if (copySelectedPieceString == "   ")
            {
                PrintBoardToConsole();
                Console.WriteLine("there is no piece here");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }
            if (copySelectedPieceString == null)
            {
                PrintBoardToConsole();
                Console.WriteLine("there is no board here");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }

            xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkBlue);
            HighlightLegalMoves(copySelectedPieceString, xSelectionInt, ySelectionInt, zSelectionInt);
            PrintBoardToConsole();

            Console.WriteLine("select a destination:");
            string xDestinationString = Console.ReadLine();
            int xDestinationInt = int.Parse(xDestinationString);
            string yDestinationString = Console.ReadLine();
            int yDestinationInt = int.Parse(yDestinationString);
            string zDestinationString = Console.ReadLine();
            int zDestinationInt = int.Parse(zDestinationString);

            string copyOfDestinationPieceString = xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].GetCellContents();

            xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellContentsToEmpty();
            xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(copySelectedPieceString);
            if (xDestinationInt == xSelectionInt)
            {
                if (yDestinationInt == ySelectionInt)
                {
                    if (zDestinationInt == zSelectionInt)
                    {
                        thePlayersTurnBool = !thePlayersTurnBool;
                    }
                }
            }
            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    for (int z = 1; z < 9; z++)
                    {
                        xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                    }
                }
            }
            CheckForPawnPromotion(copySelectedPieceString,xDestinationInt, yDestinationInt, zDestinationInt);
            PrintBoardToConsole();
        }
        private static void CheckForPawnPromotion(string copySelectedPieceString, int xDestinationInt, int yDestinationInt, int zDestinationInt)
        {
            if (copySelectedPieceString == " P ")
            {
                if (xDestinationInt == 8)
                {
                    PrintBoardToConsole();
                    Console.WriteLine("Choose a promotion for this pawn:");
                    Console.WriteLine(" r , kn , b , q ");
                    string promotionChoice = Console.ReadLine();
                    if (promotionChoice == "r")
                    {

                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" R ");
                    }
                    if (promotionChoice == "kn")
                    {

                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" KN");
                    }
                    if (promotionChoice == "b")
                    {

                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" B ");
                    }
                    if (promotionChoice == "q")
                    {

                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" Q ");
                    }

                }
            }
            if (copySelectedPieceString == " p ")
            {
                if (xDestinationInt == 1)
                {
                    PrintBoardToConsole();
                    Console.WriteLine("Choose a promotion for this pawn:");
                    Console.WriteLine(" r , kn , b , q ");
                    string promotionChoice = Console.ReadLine();
                    if (promotionChoice == "r")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" r ");
                    }
                    if (promotionChoice == "kn")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" kn");
                    }
                    if (promotionChoice == "b")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" b ");
                    }
                    if (promotionChoice == "q")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" q ");
                    }

                }
            }
        }
        private static void HighlightLegalMoves(string copySelectedPieceString, int xSelectionInt, int ySelectionInt, int zSelectionInt)
        {
            List<string> pieceList = new List<string>
            {
               " R "," KN"," B "," Q "," K "," P "," r "," kn"," b "," q "," k "," p "
            };

            if (copySelectedPieceString == " R ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {1,1,0},
                    new List<int> {1,0,1},
                    new List<int> {0,1,1},
                    new List<int> {-1,1,0},
                    new List<int> {-1,0,1},
                    new List<int> {0,-1,1},
                    new List<int> {1,-1,0},
                    new List<int> {1,0,-1},
                    new List<int> {0,1,-1},
                    new List<int> {-1,-1,0},
                    new List<int> {-1,0,-1},
                    new List<int> {0,-1,-1}
                };
                foreach (List<int> moveVector in Moveset)
                {
                    for (int index = 1; index < 8; index++)
                    {
                        int x = (moveVector[0] * index) + xSelectionInt;
                        int y = (moveVector[1] * index) + ySelectionInt;
                        int z = (moveVector[2] * index) + zSelectionInt;
                        if (x < 9)
                        {
                            if (x > 0)
                            {
                                if (y < 9)
                                {
                                    if (y > 0)
                                    {
                                        if (z < 9)
                                        {
                                            if (z > 0)
                                            {
                                                if (xYZCube[x][y][z].GetCellContents() == "   ")
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (copySelectedPieceString == " r ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {1,1,0},
                    new List<int> {1,0,1},
                    new List<int> {0,1,1},
                    new List<int> {-1,1,0},
                    new List<int> {-1,0,1},
                    new List<int> {0,-1,1},
                    new List<int> {1,-1,0},
                    new List<int> {1,0,-1},
                    new List<int> {0,1,-1},
                    new List<int> {-1,-1,0},
                    new List<int> {-1,0,-1},
                    new List<int> {0,-1,-1}
                };
                foreach (List<int> moveVector in Moveset)
                {
                    for (int index = 1; index < 8; index++)
                    {
                        int x = (moveVector[0] * index) + xSelectionInt;
                        int y = (moveVector[1] * index) + ySelectionInt;
                        int z = (moveVector[2] * index) + zSelectionInt;
                        if (x < 9)
                        {
                            if (x > 0)
                            {
                                if (y < 9)
                                {
                                    if (y > 0)
                                    {
                                        if (z < 9)
                                        {
                                            if (z > 0)
                                            {
                                                if (xYZCube[x][y][z].GetCellContents() == "   ")
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (copySelectedPieceString == " B ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {2,1,1},
                    new List<int> {1,2,1},
                    new List<int> {1,1,2},
                    new List<int> {2,1,-1},
                    new List<int> {1,2,-1},
                    new List<int> {1,1,-2},
                    new List<int> {2,-1,1},
                    new List<int> {1,-2,1},
                    new List<int> {1,-1,2},
                    new List<int> {-2,1,1},
                    new List<int> {-1,2,1},
                    new List<int> {-1,1,2},
                    new List<int> {2,-1,-1},
                    new List<int> {1,-2,-1},
                    new List<int> {1,-1,-2},
                    new List<int> {-2,1,-1},
                    new List<int> {-1,2,-1},
                    new List<int> {-1,1,-2},
                    new List<int> {-2,-1,1},
                    new List<int> {-1,-2,1},
                    new List<int> {-1,-1,2},
                    new List<int> {-2,-1,-1},
                    new List<int> {-1,-2,-1},
                    new List<int> {-1,-1,-2}
                };
                foreach (List<int> moveVector in Moveset)
                {
                    for (int index = 1; index < 8; index++)
                    {
                        int x = (moveVector[0] * index) + xSelectionInt;
                        int y = (moveVector[1] * index) + ySelectionInt;
                        int z = (moveVector[2] * index) + zSelectionInt;
                        if (x < 9)
                        {
                            if (x > 0)
                            {
                                if (y < 9)
                                {
                                    if (y > 0)
                                    {
                                        if (z < 9)
                                        {
                                            if (z > 0)
                                            {
                                                if (xYZCube[x][y][z].GetCellContents() == "   ")
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (copySelectedPieceString == " b ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {2,1,1},
                    new List<int> {1,2,1},
                    new List<int> {1,1,2},
                    new List<int> {2,1,-1},
                    new List<int> {1,2,-1},
                    new List<int> {1,1,-2},
                    new List<int> {2,-1,1},
                    new List<int> {1,-2,1},
                    new List<int> {1,-1,2},
                    new List<int> {-2,1,1},
                    new List<int> {-1,2,1},
                    new List<int> {-1,1,2},
                    new List<int> {2,-1,-1},
                    new List<int> {1,-2,-1},
                    new List<int> {1,-1,-2},
                    new List<int> {-2,1,-1},
                    new List<int> {-1,2,-1},
                    new List<int> {-1,1,-2},
                    new List<int> {-2,-1,1},
                    new List<int> {-1,-2,1},
                    new List<int> {-1,-1,2},
                    new List<int> {-2,-1,-1},
                    new List<int> {-1,-2,-1},
                    new List<int> {-1,-1,-2}
                };
                foreach (List<int> moveVector in Moveset)
                {
                    for (int index = 1; index < 8; index++)
                    {
                        int x = (moveVector[0] * index) + xSelectionInt;
                        int y = (moveVector[1] * index) + ySelectionInt;
                        int z = (moveVector[2] * index) + zSelectionInt;
                        if (x < 9)
                        {
                            if (x > 0)
                            {
                                if (y < 9)
                                {
                                    if (y > 0)
                                    {
                                        if (z < 9)
                                        {
                                            if (z > 0)
                                            {
                                                if (xYZCube[x][y][z].GetCellContents() == "   ")
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (copySelectedPieceString == " Q ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {1,1,0},
                    new List<int> {1,0,1},
                    new List<int> {0,1,1},
                    new List<int> {-1,1,0},
                    new List<int> {-1,0,1},
                    new List<int> {0,-1,1},
                    new List<int> {1,-1,0},
                    new List<int> {1,0,-1},
                    new List<int> {0,1,-1},
                    new List<int> {-1,-1,0},
                    new List<int> {-1,0,-1},
                    new List<int> {0,-1,-1},
                    new List<int> {2,1,1},
                    new List<int> {1,2,1},
                    new List<int> {1,1,2},
                    new List<int> {2,1,-1},
                    new List<int> {1,2,-1},
                    new List<int> {1,1,-2},
                    new List<int> {2,-1,1},
                    new List<int> {1,-2,1},
                    new List<int> {1,-1,2},
                    new List<int> {-2,1,1},
                    new List<int> {-1,2,1},
                    new List<int> {-1,1,2},
                    new List<int> {2,-1,-1},
                    new List<int> {1,-2,-1},
                    new List<int> {1,-1,-2},
                    new List<int> {-2,1,-1},
                    new List<int> {-1,2,-1},
                    new List<int> {-1,1,-2},
                    new List<int> {-2,-1,1},
                    new List<int> {-1,-2,1},
                    new List<int> {-1,-1,2},
                    new List<int> {-2,-1,-1},
                    new List<int> {-1,-2,-1},
                    new List<int> {-1,-1,-2}
                };
                foreach (List<int> moveVector in Moveset)
                {
                    for (int index = 1; index < 8; index++)
                    {
                        int x = (moveVector[0] * index) + xSelectionInt;
                        int y = (moveVector[1] * index) + ySelectionInt;
                        int z = (moveVector[2] * index) + zSelectionInt;
                        if (x < 9)
                        {
                            if (x > 0)
                            {
                                if (y < 9)
                                {
                                    if (y > 0)
                                    {
                                        if (z < 9)
                                        {
                                            if (z > 0)
                                            {
                                                if (xYZCube[x][y][z].GetCellContents() == "   ")
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (copySelectedPieceString == " q ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {1,1,0},
                    new List<int> {1,0,1},
                    new List<int> {0,1,1},
                    new List<int> {-1,1,0},
                    new List<int> {-1,0,1},
                    new List<int> {0,-1,1},
                    new List<int> {1,-1,0},
                    new List<int> {1,0,-1},
                    new List<int> {0,1,-1},
                    new List<int> {-1,-1,0},
                    new List<int> {-1,0,-1},
                    new List<int> {0,-1,-1},
                    new List<int> {2,1,1},
                    new List<int> {1,2,1},
                    new List<int> {1,1,2},
                    new List<int> {2,1,-1},
                    new List<int> {1,2,-1},
                    new List<int> {1,1,-2},
                    new List<int> {2,-1,1},
                    new List<int> {1,-2,1},
                    new List<int> {1,-1,2},
                    new List<int> {-2,1,1},
                    new List<int> {-1,2,1},
                    new List<int> {-1,1,2},
                    new List<int> {2,-1,-1},
                    new List<int> {1,-2,-1},
                    new List<int> {1,-1,-2},
                    new List<int> {-2,1,-1},
                    new List<int> {-1,2,-1},
                    new List<int> {-1,1,-2},
                    new List<int> {-2,-1,1},
                    new List<int> {-1,-2,1},
                    new List<int> {-1,-1,2},
                    new List<int> {-2,-1,-1},
                    new List<int> {-1,-2,-1},
                    new List<int> {-1,-1,-2}
                };
                foreach (List<int> moveVector in Moveset)
                {
                    for (int index = 1; index < 8; index++)
                    {
                        int x = (moveVector[0] * index) + xSelectionInt;
                        int y = (moveVector[1] * index) + ySelectionInt;
                        int z = (moveVector[2] * index) + zSelectionInt;
                        if (x < 9)
                        {
                            if (x > 0)
                            {
                                if (y < 9)
                                {
                                    if (y > 0)
                                    {
                                        if (z < 9)
                                        {
                                            if (z > 0)
                                            {
                                                if (xYZCube[x][y][z].GetCellContents() == "   ")
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (copySelectedPieceString == " K ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {1,1,0},
                    new List<int> {1,0,1},
                    new List<int> {0,1,1},
                    new List<int> {-1,1,0},
                    new List<int> {-1,0,1},
                    new List<int> {0,-1,1},
                    new List<int> {1,-1,0},
                    new List<int> {1,0,-1},
                    new List<int> {0,1,-1},
                    new List<int> {-1,-1,0},
                    new List<int> {-1,0,-1},
                    new List<int> {0,-1,-1},
                    new List<int> {2,1,1},
                    new List<int> {1,2,1},
                    new List<int> {1,1,2},
                    new List<int> {2,1,-1},
                    new List<int> {1,2,-1},
                    new List<int> {1,1,-2},
                    new List<int> {2,-1,1},
                    new List<int> {1,-2,1},
                    new List<int> {1,-1,2},
                    new List<int> {-2,1,1},
                    new List<int> {-1,2,1},
                    new List<int> {-1,1,2},
                    new List<int> {2,-1,-1},
                    new List<int> {1,-2,-1},
                    new List<int> {1,-1,-2},
                    new List<int> {-2,1,-1},
                    new List<int> {-1,2,-1},
                    new List<int> {-1,1,-2},
                    new List<int> {-2,-1,1},
                    new List<int> {-1,-2,1},
                    new List<int> {-1,-1,2},
                    new List<int> {-2,-1,-1},
                    new List<int> {-1,-2,-1},
                    new List<int> {-1,-1,-2}
                };
                foreach (List<int> moveVector in Moveset)
                {
                        int x = moveVector[0] + xSelectionInt;
                        int y = moveVector[1] + ySelectionInt;
                        int z = moveVector[2] + zSelectionInt;
                        if (x < 9)
                        {
                            if (x > 0)
                            {
                                if (y < 9)
                                {
                                    if (y > 0)
                                    {
                                        if (z < 9)
                                        {
                                            if (z > 0)
                                            {
                                                if (xYZCube[x][y][z].GetCellContents() == "   ")
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    
                }
            }
            if (copySelectedPieceString == " k ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {1,1,0},
                    new List<int> {1,0,1},
                    new List<int> {0,1,1},
                    new List<int> {-1,1,0},
                    new List<int> {-1,0,1},
                    new List<int> {0,-1,1},
                    new List<int> {1,-1,0},
                    new List<int> {1,0,-1},
                    new List<int> {0,1,-1},
                    new List<int> {-1,-1,0},
                    new List<int> {-1,0,-1},
                    new List<int> {0,-1,-1},
                    new List<int> {2,1,1},
                    new List<int> {1,2,1},
                    new List<int> {1,1,2},
                    new List<int> {2,1,-1},
                    new List<int> {1,2,-1},
                    new List<int> {1,1,-2},
                    new List<int> {2,-1,1},
                    new List<int> {1,-2,1},
                    new List<int> {1,-1,2},
                    new List<int> {-2,1,1},
                    new List<int> {-1,2,1},
                    new List<int> {-1,1,2},
                    new List<int> {2,-1,-1},
                    new List<int> {1,-2,-1},
                    new List<int> {1,-1,-2},
                    new List<int> {-2,1,-1},
                    new List<int> {-1,2,-1},
                    new List<int> {-1,1,-2},
                    new List<int> {-2,-1,1},
                    new List<int> {-1,-2,1},
                    new List<int> {-1,-1,2},
                    new List<int> {-2,-1,-1},
                    new List<int> {-1,-2,-1},
                    new List<int> {-1,-1,-2}
                };
                foreach (List<int> moveVector in Moveset)
                {
                    int x = moveVector[0] + xSelectionInt;
                    int y = moveVector[1] + ySelectionInt;
                    int z = moveVector[2] + zSelectionInt;
                    if (x < 9)
                    {
                        if (x > 0)
                        {
                            if (y < 9)
                            {
                                if (y > 0)
                                {
                                    if (z < 9)
                                    {
                                        if (z > 0)
                                        {
                                            if (xYZCube[x][y][z].GetCellContents() == "   ")
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                            }
                                            else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                            }
                                            else if (xYZCube[x][y][z].GetCellContents() == null)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            if (copySelectedPieceString == " KN")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {1,2,3},
                    new List<int> {2,1,3},
                    new List<int> {2,3,1},
                    new List<int> {3,2,1},
                    new List<int> {3,1,2},
                    new List<int> {1,3,2},
                    new List<int> {1,2,-3},
                    new List<int> {2,1,-3},
                    new List<int> {2,3,-1},
                    new List<int> {3,2,-1},
                    new List<int> {3,1,-2},
                    new List<int> {1,3,-2},
                    new List<int> {1,-2,3},
                    new List<int> {2,-1,3},
                    new List<int> {2,-3,1},
                    new List<int> {3,-2,1},
                    new List<int> {3,-1,2},
                    new List<int> {1,-3,2},
                    new List<int> {-1,2,3},
                    new List<int> {-2,1,3},
                    new List<int> {-2,3,1},
                    new List<int> {-3,2,1},
                    new List<int> {-3,1,2},
                    new List<int> {-1,3,2},
                    new List<int> {1,-2,-3},
                    new List<int> {2,-1,-3},
                    new List<int> {2,-3,-1},
                    new List<int> {3,-2,-1},
                    new List<int> {3,-1,-2},
                    new List<int> {1,-3,-2},
                    new List<int> {-1,2,-3},
                    new List<int> {-2,1,-3},
                    new List<int> {-2,3,-1},
                    new List<int> {-3,2,-1},
                    new List<int> {-3,1,-2},
                    new List<int> {-1,3,-2},
                    new List<int> {-1,-2,3},
                    new List<int> {-2,-1,3},
                    new List<int> {-2,-3,1},
                    new List<int> {-3,-2,1},
                    new List<int> {-3,-1,2},
                    new List<int> {-1,-3,2},
                    new List<int> {-1,-2,-3},
                    new List<int> {-2,-1,-3},
                    new List<int> {-2,-3,-1},
                    new List<int> {-3,-2,-1},
                    new List<int> {-3,-1,-2},
                    new List<int> {-1,-3,-2},
                };
                foreach (List<int> moveVector in Moveset)
                {
                        int x = moveVector[0] + xSelectionInt;
                        int y = moveVector[1] + ySelectionInt;
                        int z = moveVector[2] + zSelectionInt;
                        if (x < 9)
                        {
                            if (x > 0)
                            {
                                if (y < 9)
                                {
                                    if (y > 0)
                                    {
                                        if (z < 9)
                                        {
                                            if (z > 0)
                                            {
                                                if (xYZCube[x][y][z].GetCellContents() == "   ")
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                }
            }
            if (copySelectedPieceString == " kn")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {1,2,3},
                    new List<int> {2,1,3},
                    new List<int> {2,3,1},
                    new List<int> {3,2,1},
                    new List<int> {3,1,2},
                    new List<int> {1,3,2},
                    new List<int> {1,2,-3},
                    new List<int> {2,1,-3},
                    new List<int> {2,3,-1},
                    new List<int> {3,2,-1},
                    new List<int> {3,1,-2},
                    new List<int> {1,3,-2},
                    new List<int> {1,-2,3},
                    new List<int> {2,-1,3},
                    new List<int> {2,-3,1},
                    new List<int> {3,-2,1},
                    new List<int> {3,-1,2},
                    new List<int> {1,-3,2},
                    new List<int> {-1,2,3},
                    new List<int> {-2,1,3},
                    new List<int> {-2,3,1},
                    new List<int> {-3,2,1},
                    new List<int> {-3,1,2},
                    new List<int> {-1,3,2},
                    new List<int> {1,-2,-3},
                    new List<int> {2,-1,-3},
                    new List<int> {2,-3,-1},
                    new List<int> {3,-2,-1},
                    new List<int> {3,-1,-2},
                    new List<int> {1,-3,-2},
                    new List<int> {-1,2,-3},
                    new List<int> {-2,1,-3},
                    new List<int> {-2,3,-1},
                    new List<int> {-3,2,-1},
                    new List<int> {-3,1,-2},
                    new List<int> {-1,3,-2},
                    new List<int> {-1,-2,3},
                    new List<int> {-2,-1,3},
                    new List<int> {-2,-3,1},
                    new List<int> {-3,-2,1},
                    new List<int> {-3,-1,2},
                    new List<int> {-1,-3,2},
                    new List<int> {-1,-2,-3},
                    new List<int> {-2,-1,-3},
                    new List<int> {-2,-3,-1},
                    new List<int> {-3,-2,-1},
                    new List<int> {-3,-1,-2},
                    new List<int> {-1,-3,-2},
                };
                foreach (List<int> moveVector in Moveset)
                {
                    int x = moveVector[0] + xSelectionInt;
                    int y = moveVector[1] + ySelectionInt;
                    int z = moveVector[2] + zSelectionInt;
                    if (x < 9)
                    {
                        if (x > 0)
                        {
                            if (y < 9)
                            {
                                if (y > 0)
                                {
                                    if (z < 9)
                                    {
                                        if (z > 0)
                                        {
                                            if (xYZCube[x][y][z].GetCellContents() == "   ")
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                            }
                                            else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                            }
                                            else if (xYZCube[x][y][z].GetCellContents() == null)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (copySelectedPieceString == " P ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {1,1,0},
                    new List<int> {1,0,1},
                    new List<int> {1,-1,0},
                    new List<int> {1,0,-1}
                };
                List<List<int>> Attackset = new List<List<int>>
                {
                    new List<int> {2,1,1},
                    new List<int> {1,2,1},
                    new List<int> {1,1,2},
                    new List<int> {2,1,-1},
                    new List<int> {1,2,-1},
                    new List<int> {1,1,-2},
                    new List<int> {2,-1,1},
                    new List<int> {1,-2,1},
                    new List<int> {1,-1,2},
                    new List<int> {2,-1,-1},
                    new List<int> {1,-2,-1},
                    new List<int> {1,-1,-2}
                };
                foreach (List<int> moveVector in Moveset)
                {
                    int x = moveVector[0] + xSelectionInt;
                    int y = moveVector[1] + ySelectionInt;
                    int z = moveVector[2] + zSelectionInt;
                    if (x < 9)
                    {
                        if (x > 0)
                        {
                            if (y < 9)
                            {
                                if (y > 0)
                                {
                                    if (z < 9)
                                    {
                                        if (z > 0)
                                        {
                                            if (xYZCube[x][y][z].GetCellContents() == "   ")
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                foreach (List<int> moveVector in Moveset)
                {
                    int x = (moveVector[0]*2) + xSelectionInt;
                    int y = (moveVector[1]*2) + ySelectionInt;
                    int z = (moveVector[2]*2) + zSelectionInt;
                    if (x < 9)
                    {
                        if (x > 0)
                        {
                            if (y < 9)
                            {
                                if (y > 0)
                                {
                                    if (z < 9)
                                    {
                                        if (z > 0)
                                        {
                                            if (xYZCube[x][y][z].GetCellContents() == "   ")
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGreen);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                foreach (List<int> moveVector in Attackset)
                {
                    int x = moveVector[0] + xSelectionInt;
                    int y = moveVector[1] + ySelectionInt;
                    int z = moveVector[2] + zSelectionInt;
                    if (x < 9)
                    {
                        if (x > 0)
                        {
                            if (y < 9)
                            {
                                if (y > 0)
                                {
                                    if (z < 9)
                                    {
                                        if (z > 0)
                                        {
                                            if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            if (copySelectedPieceString == " p ")
            {
                List<List<int>> Moveset = new List<List<int>>
                {
                    new List<int> {-1,1,0},
                    new List<int> {-1,0,1},
                    new List<int> {-1,-1,0},
                    new List<int> {-1,0,-1}
                };
                List<List<int>> Attackset = new List<List<int>>
                {
                    new List<int> {-2,1,1},
                    new List<int> {-1,2,1},
                    new List<int> {-1,1,2},
                    new List<int> {-2,1,-1},
                    new List<int> {-1,2,-1},
                    new List<int> {-1,1,-2},
                    new List<int> {-2,-1,1},
                    new List<int> {-1,-2,1},
                    new List<int> {-1,-1,2},
                    new List<int> {-2,-1,-1},
                    new List<int> {-1,-2,-1},
                    new List<int> {-1,-1,-2}
                };
                foreach (List<int> moveVector in Moveset)
                {
                    int x = moveVector[0] + xSelectionInt;
                    int y = moveVector[1] + ySelectionInt;
                    int z = moveVector[2] + zSelectionInt;
                    if (x < 9)
                    {
                        if (x > 0)
                        {
                            if (y < 9)
                            {
                                if (y > 0)
                                {
                                    if (z < 9)
                                    {
                                        if (z > 0)
                                        {
                                            if (xYZCube[x][y][z].GetCellContents() == "   ")
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                foreach (List<int> moveVector in Moveset)
                {
                    int x = (moveVector[0] * 2) + xSelectionInt;
                    int y = (moveVector[1] * 2) + ySelectionInt;
                    int z = (moveVector[2] * 2) + zSelectionInt;
                    if (x < 9)
                    {
                        if (x > 0)
                        {
                            if (y < 9)
                            {
                                if (y > 0)
                                {
                                    if (z < 9)
                                    {
                                        if (z > 0)
                                        {
                                            if (xYZCube[x][y][z].GetCellContents() == "   ")
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGreen);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                foreach (List<int> moveVector in Attackset)
                {
                    int x = moveVector[0] + xSelectionInt;
                    int y = moveVector[1] + ySelectionInt;
                    int z = moveVector[2] + zSelectionInt;
                    if (x < 9)
                    {
                        if (x > 0)
                        {
                            if (y < 9)
                            {
                                if (y > 0)
                                {
                                    if (z < 9)
                                    {
                                        if (z > 0)
                                        {
                                            if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
        private static void SetupTeams()
        {
            //team 1
            xYZCube[1][1][1].SetCellContents(" R ");
            xYZCube[1][2][2].SetCellContents(" KN");
            xYZCube[1][3][3].SetCellContents(" B ");
            xYZCube[1][4][4].SetCellContents(" Q ");
            xYZCube[1][5][5].SetCellContents(" K ");
            xYZCube[1][6][6].SetCellContents(" B ");
            xYZCube[1][7][7].SetCellContents(" KN");
            xYZCube[1][8][8].SetCellContents(" R ");
            xYZCube[2][1][2].SetCellContents(" P ");
            xYZCube[2][2][1].SetCellContents(" P ");
            xYZCube[2][2][3].SetCellContents(" P ");
            xYZCube[2][3][2].SetCellContents(" P ");
            xYZCube[2][3][4].SetCellContents(" P ");
            xYZCube[2][4][3].SetCellContents(" P ");
            xYZCube[2][4][5].SetCellContents(" P ");
            xYZCube[2][5][4].SetCellContents(" P ");
            xYZCube[2][5][6].SetCellContents(" P ");
            xYZCube[2][6][5].SetCellContents(" P ");
            xYZCube[2][6][7].SetCellContents(" P ");
            xYZCube[2][7][6].SetCellContents(" P ");
            xYZCube[2][7][8].SetCellContents(" P ");
            xYZCube[2][8][7].SetCellContents(" P ");
            //team 2
            xYZCube[8][1][8].SetCellContents(" r ");
            xYZCube[8][2][7].SetCellContents(" kn");
            xYZCube[8][3][6].SetCellContents(" b ");
            xYZCube[8][4][5].SetCellContents(" q ");
            xYZCube[8][5][4].SetCellContents(" k ");
            xYZCube[8][6][3].SetCellContents(" b ");
            xYZCube[8][7][2].SetCellContents(" kn");
            xYZCube[8][8][1].SetCellContents(" r ");
            xYZCube[7][1][7].SetCellContents(" p ");
            xYZCube[7][2][6].SetCellContents(" p ");
            xYZCube[7][2][8].SetCellContents(" p ");
            xYZCube[7][3][5].SetCellContents(" p ");
            xYZCube[7][3][7].SetCellContents(" p ");
            xYZCube[7][4][4].SetCellContents(" p ");
            xYZCube[7][4][6].SetCellContents(" p ");
            xYZCube[7][5][3].SetCellContents(" p ");
            xYZCube[7][5][5].SetCellContents(" p ");
            xYZCube[7][6][2].SetCellContents(" p ");
            xYZCube[7][6][4].SetCellContents(" p ");
            xYZCube[7][7][1].SetCellContents(" p ");
            xYZCube[7][7][3].SetCellContents(" p ");
            xYZCube[7][8][2].SetCellContents(" p ");
        }
        private static List<List<List<CubeCell>>> WriteTetrahedronBoardOntoCube()
        {
            List<List<List<CubeCell>>> tetrahedronInACube = new List<List<List<CubeCell>>>();

            for (var x = 1; x < 9; x++)
            {
                for (var y = 1; y < 9; y++)
                {
                    for (var z = 1; z < 9; z++)
                    {
                        if (x > 8 | y > 8 | z > 8)
                        {
                            break;
                        }
                        if (x + y + z > 17)
                        {
                            break;
                        }
                        xYZCube[x][y][z].SetCellContentsToEmpty();
                    }
                }
            }

            return tetrahedronInACube;
        }
        private static List<List<List<CubeCell>>> MakeCube()
        {
            List<List<List<CubeCell>>> cube = new List<List<List<CubeCell>>>();

            for (var index = 0; index < 9; index++)
            {
                cube.Add(MakePlaneOfCube());
            }

            return cube;
        }
        private static List<List<CubeCell>> MakePlaneOfCube()
        {
            List<List<CubeCell>> plane = new List<List<CubeCell>>();

            for (var index = 0; index < 9; index++)
            {
                plane.Add(MakeRowOfCube());
            }

            return plane;
        }
        private static List<CubeCell> MakeRowOfCube()
        {
            List<CubeCell> row = new List<CubeCell>();

            for (var index = 0; index < 9; index++)
            {
                CubeCell newCell = new CubeCell();
                row.Add(newCell);
            }

            return row;
        }
        class CubeCell
        {
            string? cellContents;
            ConsoleColor colorBlack = ConsoleColor.Black;
            ConsoleColor currentColor;
            public void SetCellColor(ConsoleColor setCellColor)
            {
                currentColor = setCellColor;
            }
            public ConsoleColor GetCellColor()
            {
                return currentColor;
            }
            public ConsoleColor SetDefaultCellColor()
            {
                return colorBlack;
            }
            public void SetCellContents(string cellContentUpdate)
            {
                cellContents = cellContentUpdate;
            }
            public string SetCellContentsToEmpty()
            {
                cellContents = "   ";
                return cellContents;
            }
            public string GetCellContents()
            {
                return cellContents;
            }
        }
        private static void PrintBoardToConsole()
        {
            List<List<int>> row1 = new List<List<int>>
            {
            new List<int> { 1, 8, 8 },
            new List<int> { 2, 8, 7 },
            new List<int> { 3, 8, 6 },
            new List<int> { 4, 8, 5 },
            new List<int> { 5, 8, 4 },
            new List<int> { 6, 8, 3 },
            new List<int> { 7, 8, 2 },
            new List<int> { 8, 8, 1 }
            };

            List<List<int>> row2 = new List<List<int>>
            {
            new List<int> { 2, 7, 6 },
            new List<int> { 3, 7, 5 },
            new List<int> { 4, 7, 4 },
            new List<int> { 5, 7, 3 },
            new List<int> { 6, 7, 2 },
            new List<int> { 7, 7, 1 },
            new List<int> { 8, 7, 2 }
            };

            List<List<int>> row3 = new List<List<int>>
            {
            new List<int> { 1, 7, 7 },
            new List<int> { 2, 7, 8 },
            new List<int> { 3, 7, 7 },
            new List<int> { 4, 7, 6 },
            new List<int> { 5, 7, 5 },
            new List<int> { 6, 7, 4 },
            new List<int> { 7, 7, 3 }
            };

            List<List<int>> row4 = new List<List<int>>
            {
            new List<int> { 3, 6, 4 },
            new List<int> { 4, 6, 3 },
            new List<int> { 5, 6, 2 },
            new List<int> { 6, 6, 1 },
            new List<int> { 7, 6, 2 },
            new List<int> { 8, 6, 3 }
            };

            List<List<int>> row5 = new List<List<int>>
            {
           new List<int> { 2, 6, 5 },
           new List<int> { 3, 6, 6 },
           new List<int> { 4, 6, 5 },
           new List<int> { 5, 6, 4 },
           new List<int> { 6, 6, 3 },
           new List<int> { 7, 6, 4 }
            };

            List<List<int>> row6 = new List<List<int>>
            {
            new List<int> { 1, 6, 6 },
            new List<int> { 2, 6, 7 },
            new List<int> { 3, 6, 8 },
            new List<int> { 4, 6, 7 },
            new List<int> { 5, 6, 6 },
            new List<int> { 6, 6, 5 }
            };

            List<List<int>> row7 = new List<List<int>>
            {
            new List<int> {4 , 5, 2 },
            new List<int> {5 , 5, 1 },
            new List<int> {6 , 5, 2 },
            new List<int> {7 , 5, 3 },
            new List<int> {8 , 5, 4 }
            };

            List<List<int>> row8 = new List<List<int>>
            {
            new List<int> {3 , 5, 3 },
            new List<int> {4 , 5, 4 },
            new List<int> {5 , 5, 3 },
            new List<int> {6 , 5, 4 },
            new List<int> {7 , 5, 5 }
            };

            List<List<int>> row9 = new List<List<int>>
            {
            new List<int> { 2,5,4 },
            new List<int> { 3,5,5 },
            new List<int> { 4,5,6 },
            new List<int> { 5,5,5 },
            new List<int> { 6,5,6 }
            };

            List<List<int>> row10 = new List<List<int>>
            {
            new List<int> {1 ,5, 5},
            new List<int> {2 ,5, 6},
            new List<int> {3 ,5, 7},
            new List<int> {4 ,5, 8},
            new List<int> {5 ,5, 7}
            };

            List<List<int>> row11 = new List<List<int>>
            {
            new List<int> { 4,4,1 },
            new List<int> { 5,4,2 },
            new List<int> { 6,4,3 },
            new List<int> { 7,4,4 },
            new List<int> { 8,4,5 }
            };

            List<List<int>> row12 = new List<List<int>>
            {
            new List<int> { 3,4,2 },
            new List<int> { 4,4,3 },
            new List<int> { 5,4,4 },
            new List<int> { 6,4,5 },
            new List<int> { 7,4,6 }
            };

            List<List<int>> row13 = new List<List<int>>
            {
            new List<int> { 2,4,3 },
            new List<int> { 3,4,4 },
            new List<int> { 4,4,5 },
            new List<int> { 5,4,6 },
            new List<int> { 6,4,7 }
            };

            List<List<int>> row14 = new List<List<int>>
            {
            new List<int> { 1,4, 4},
            new List<int> { 2,4, 5},
            new List<int> { 3,4, 6},
            new List<int> { 4,4, 7},
            new List<int> { 5,4, 8}
            };

            List<List<int>> row15 = new List<List<int>>
            {
            new List<int> { 3,3,1 },
            new List<int> { 4,3,2 },
            new List<int> { 5,3,3 },
            new List<int> { 6,3,4 },
            new List<int> { 7,3,5 },
            new List<int> { 8,3,6 }
            };

            List<List<int>> row16 = new List<List<int>>
            {
            new List<int> { 2,3,2 },
            new List<int> { 3,3,3 },
            new List<int> { 4,3,4 },
            new List<int> { 5,3,5 },
            new List<int> { 6,3,6 },
            new List<int> { 7,3,7 }
            };

            List<List<int>> row17 = new List<List<int>>
            {
            new List<int> { 1,3,3 },
            new List<int> { 2,3,4 },
            new List<int> { 3,3,5 },
            new List<int> { 4,3,6 },
            new List<int> { 5,3,7 },
            new List<int> { 6,3,8 }
            };

            List<List<int>> row18 = new List<List<int>>
            {
            new List<int> { 2,2,1 },
            new List<int> { 3,2,2 },
            new List<int> { 4,2,3 },
            new List<int> { 5,2,4 },
            new List<int> { 6,2,5 },
            new List<int> { 7,2,6 },
            new List<int> { 8,2,7 }
            };

            List<List<int>> row19 = new List<List<int>>
            {
            new List<int> { 1,2,2 },
            new List<int> { 2,2,3 },
            new List<int> { 3,2,4 },
            new List<int> { 4,2,5 },
            new List<int> { 5,2,6 },
            new List<int> { 6,2,7 },
            new List<int> { 7,2,8 }
            };

            List<List<int>> row20 = new List<List<int>>
            {
            new List<int> { 1,1,1 },
            new List<int> { 2,1,2 },
            new List<int> { 3,1,3 },
            new List<int> { 4,1,4 },
            new List<int> { 5,1,5 },
            new List<int> { 6,1,6 },
            new List<int> { 7,1,7 },
            new List<int> { 8,1,8 }
            };


            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("|---|---|---|---|---|---|---|---|");

            foreach (List<int> xyz in row1)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|188|287|386|485|584|683|782|881|");

            Console.Write("    ");
            foreach (List<int> xyz in row2)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|---|276|375|474|573|672|771|872|");

            foreach (List<int> xyz in row3)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|177|278|377|476|575|674|773|---|");


            Console.Write("        ");
            foreach (List<int> xyz in row4)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("    |---|364|463|562|661|762|863|");


            Console.Write("    ");
            foreach (List<int> xyz in row5)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|---|265|366|465|564|663|764|");

            foreach (List<int> xyz in row6)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|166|267|368|467|566|665|---|---|");


            Console.Write("            ");
            foreach (List<int> xyz in row7)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("        |---|452|551|652|753|854|");


            Console.Write("        ");
            foreach (List<int> xyz in row8)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("    |---|353|454|553|654|755|");


            Console.Write("    ");
            foreach (List<int> xyz in row9)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|---|254|355|456|555|656|");

            foreach (List<int> xyz in row10)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|155|256|357|458|557|---|---|---|");


            Console.Write("            ");
            foreach (List<int> xyz in row11)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("        |---|441|542|643|744|845|");


            Console.Write("        ");
            foreach (List<int> xyz in row12)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("    |---|342|443|544|645|746|");


            Console.Write("    ");
            foreach (List<int> xyz in row13)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|---|243|344|445|546|647|");

            foreach (List<int> xyz in row14)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|144|245|346|447|548|---|---|---|");


            Console.Write("        ");
            foreach (List<int> xyz in row15)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("    |---|331|432|533|634|735|836|");


            Console.Write("    ");
            foreach (List<int> xyz in row16)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|---|232|333|434|535|636|737|");

            foreach (List<int> xyz in row17)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|133|234|335|436|537|638|---|---|");


            Console.Write("    ");
            foreach (List<int> xyz in row18)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|---|221|322|423|524|625|726|827|");

            foreach (List<int> xyz in row19)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|122|223|324|425|526|627|728|---|");

            foreach (List<int> xyz in row20)
            {
                int x = xyz[0];
                int y = xyz[1];
                int z = xyz[2];
                Console.Write("|");
                Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                Console.Write(xYZCube[x][y][z].GetCellContents());
                Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
            }
            Console.WriteLine("|");
            Console.WriteLine("|111|212|313|414|515|616|717|818|");
            Console.WriteLine("");
        }
    }
}
