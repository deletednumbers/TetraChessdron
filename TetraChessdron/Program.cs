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
        private static List<List<List<CubeCell>>> previousXYZCube = MakeCube();

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
                    Console.WriteLine("Player 1's turn");
                }
                else
                {
                    Console.WriteLine("Player 2's turn");
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
                                                                            Console.WriteLine("Player 1's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player 2's turn");
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
                                                                            Console.WriteLine("Player 1's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player 2's turn");
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
                                                                            Console.WriteLine("Player 1's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player 2's turn");
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
                                                                            Console.WriteLine("Player 1's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player 2's turn");
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
                                                                        Console.WriteLine("Player 1's turn");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Player 2's turn");
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
                                                                            Console.WriteLine("Player 1's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player 2's turn");
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
                                                                            Console.WriteLine("Player 1's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player 2's turn");
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
                                                                            Console.WriteLine("Player 1's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player 2's turn");
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
                                                                        Console.WriteLine("Player 1's turn");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Player 2's turn");
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
                                                                        Console.WriteLine("Player 1's turn");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Player 2's turn");
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
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " K ")
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

                                                                    if (xYZCube[x][y][z].GetCellContents() == " k ")
                                                                    {
                                                                        xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                        xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                        PrintBoardToConsole();
                                                                        Console.WriteLine("player 2's king is in check");
                                                                        if (thePlayersTurnBool == true)
                                                                        {
                                                                            Console.WriteLine("Player 1's turn");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Player 2's turn");
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
                                if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " k ")
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

                                                                if (xYZCube[x][y][z].GetCellContents() == " K ")
                                                                {
                                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                                    xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellColor(ConsoleColor.DarkGreen);
                                                                    PrintBoardToConsole();
                                                                    Console.WriteLine("player 1's king is in check");
                                                                    if (thePlayersTurnBool == true)
                                                                    {
                                                                        Console.WriteLine("Player 1's turn");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Player 2's turn");
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
        private static bool SelfCheckCheck( bool thePlayersTurnBool)
        {
            bool selfCheckBool = false;
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
                                if (thePlayersTurnBool == false)
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
                                                                            selfCheckBool = true;
                                                                            return selfCheckBool;
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
                                                                            selfCheckBool = true;
                                                                            return selfCheckBool;
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
                                                                            selfCheckBool = true;
                                                                            return selfCheckBool;
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
                                                                        selfCheckBool = true;
                                                                        return selfCheckBool;
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
                                                                            selfCheckBool = true;
                                                                            return selfCheckBool;
                                                                        
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " K ")
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
                                                                    if (xYZCube[x][y][z].GetCellContents() == " k ")
                                                                    {
                                                                        selfCheckBool = true;
                                                                        return selfCheckBool;
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

                                if (thePlayersTurnBool == true)
                                {
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
                                                                            selfCheckBool = true;
                                                                            return selfCheckBool;
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
                                                                            selfCheckBool = true;
                                                                            return selfCheckBool;
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
                                                                            selfCheckBool = true;
                                                                            return selfCheckBool;
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
                                                                        selfCheckBool = true;
                                                                        return selfCheckBool;
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
                                                                        selfCheckBool = true;
                                                                        return selfCheckBool;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " k ")
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
                                                                    if (xYZCube[x][y][z].GetCellContents() == " K ")
                                                                    {
                                                                        selfCheckBool = true;
                                                                        return selfCheckBool;
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
            return selfCheckBool;
        }
        private static void MoveAPiece()
        {
            Console.WriteLine("select a location to move from:");
            string selectionString = Console.ReadLine();
            int anIntVariableForParseTesting;
            bool doesTheSelectionStringParseToInt = int.TryParse(selectionString, out anIntVariableForParseTesting);

            if (doesTheSelectionStringParseToInt == false)
            {
                PrintBoardToConsole();
                Console.WriteLine("type selection coordinates like this example '111', numbers only");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }
            if (selectionString.Length != 3)
            {
                PrintBoardToConsole();
                Console.WriteLine("type selection coordinates like this example '111'");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }

            List<string> selectionStringList = new List<string>();

            foreach (char singleCharacter in selectionString)
            {
                selectionStringList.Add(singleCharacter.ToString());
            }

            string xSelectionString = selectionStringList[0];
            int xSelectionInt = int.Parse(xSelectionString);
            string ySelectionString = selectionStringList[1];
            int ySelectionInt = int.Parse(ySelectionString);
            string zSelectionString = selectionStringList[2];
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
            string destinationString = Console.ReadLine();
            List<string> destinationStringList = new List<string>(); 
            bool doesTheDestinationStringParseToInt = int.TryParse(destinationString, out anIntVariableForParseTesting);

            if (doesTheDestinationStringParseToInt == false)
            {
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
                PrintBoardToConsole();
                Console.WriteLine("type destination coordinates like this example '111', numbers only");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }
            if (destinationString.Length != 3)
            {
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
                PrintBoardToConsole();
                Console.WriteLine("type destination coordinates like this example '111'");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }

            foreach (char letter in destinationString)
            {
                destinationStringList.Add(letter.ToString());
            }

            string xDestinationString = destinationStringList[0];
            int xDestinationInt = int.Parse(xDestinationString);
            string yDestinationString = destinationStringList[1];
            int yDestinationInt = int.Parse(yDestinationString);
            string zDestinationString = destinationStringList[2];
            int zDestinationInt = int.Parse(zDestinationString);

            string copyofDestinationPieceString = xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].GetCellContents();

            if (copyofDestinationPieceString == null)
            {
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
                PrintBoardToConsole();
                Console.WriteLine("there is no board here");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }

            if (thePlayersTurnBool == true)
            {
                List<string> pieceList = new List<string>
                {
                   " r "," kn"," b "," q "," k "," p "
                };

                if (pieceList.Contains(copySelectedPieceString) == true)
                {
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
                    PrintBoardToConsole();
                    Console.WriteLine("cannot move other player's piece");
                    thePlayersTurnBool = !thePlayersTurnBool;
                    return;

                }
            }
            if (thePlayersTurnBool == false)
            {
                List<string> pieceList = new List<string>
                {
                   " r "," kn"," b "," q "," k "," p "
                };

                if (pieceList.Contains(copyofDestinationPieceString) == true)
                {
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
                    PrintBoardToConsole();
                    Console.WriteLine("cannot take own piece");
                    thePlayersTurnBool = !thePlayersTurnBool;
                    return;

                }
            }
            if (thePlayersTurnBool == false)
            {
                List<string> pieceList = new List<string>
                {
                   " R "," KN"," B "," Q "," K "," P "
                };

                if (pieceList.Contains(copySelectedPieceString) == true)
                {
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
                    PrintBoardToConsole();
                    Console.WriteLine("cannot move other player's piece");
                    thePlayersTurnBool = !thePlayersTurnBool;
                    return;

                }
            }
            if (xDestinationInt == xSelectionInt)
            {
                if (yDestinationInt == ySelectionInt)
                {
                    if (zDestinationInt == zSelectionInt)
                    {
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
                        PrintBoardToConsole();
                        thePlayersTurnBool = !thePlayersTurnBool;
                        return;
                    }
                }
            }

            if (thePlayersTurnBool == true)
            {
                List<string> pieceList = new List<string>
                {
                   " R "," KN"," B "," Q "," K "," P "
                };

                if (pieceList.Contains(copyofDestinationPieceString) == true)
                {
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
                    PrintBoardToConsole();
                    Console.WriteLine("cannot take own piece");
                    thePlayersTurnBool = !thePlayersTurnBool;
                    return;

                }
            }
            if (thePlayersTurnBool == false)
            {
                List<string> pieceList = new List<string>
                {
                   " r "," kn"," b "," q "," k "," p "
                };

                if (pieceList.Contains(copyofDestinationPieceString) == true)
                {
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
                    PrintBoardToConsole();
                    Console.WriteLine("cannot take own piece");
                    thePlayersTurnBool = !thePlayersTurnBool;
                    return;

                }
            }



            if (CheckForLegalPieceMoveset(copySelectedPieceString, xSelectionInt, ySelectionInt, zSelectionInt, xDestinationInt, yDestinationInt, zDestinationInt) == false)
            {
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

                PrintBoardToConsole();
                Console.WriteLine("not a legal move for this piece");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }


            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    for (int z = 0; z < 9; z++)
                    {
                        previousXYZCube[x][y][z].SetCellContents(xYZCube[x][y][z].GetCellContents());
                    }
                }
            }

            xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellContentsToEmpty();
            xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(copySelectedPieceString);

           if (SelfCheckCheck(thePlayersTurnBool) == true)
            {
                xYZCube = new List<List<List<CubeCell>>>(previousXYZCube);

                PrintBoardToConsole();
                Console.WriteLine("cannot make move, would endanger king");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    for (int z = 0; z < 9; z++)
                    {
                        xYZCube[x][y][z].SetCellColor(ConsoleColor.Black);
                    }
                }
            }

            CheckForPawnPromotion(copySelectedPieceString,xDestinationInt, yDestinationInt, zDestinationInt);
            PrintBoardToConsole();
        }
        private static bool CheckForLegalPieceMoveset(string copySelectedPieceString, int xSelectionInt, int ySelectionInt, int zSelectionInt, int xDestinationInt, int yDestinationInt, int zDestinationInt)
        {
            bool isALegalMove = false;
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
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }
                                                    
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }

                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
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
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }

                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
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
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }

                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
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
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }

                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
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
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
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
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                                else if (xYZCube[x][y][z].GetCellContents() == null)
                                                {
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
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (xYZCube[x][y][z].GetCellContents() == null)
                                            {
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
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (xYZCube[x][y][z].GetCellContents() == null)
                                            {
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
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
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
                if (xSelectionInt == 2)
                {
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
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
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
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
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
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
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
                if (xSelectionInt == 7)
                {

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
                                                    if (x == xDestinationInt)
                                                    {
                                                        if (y == yDestinationInt)
                                                        {
                                                            if (z == zDestinationInt)
                                                            {
                                                                isALegalMove = true;
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
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
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
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (xYZCube[x][y][z].GetCellContents() == null)
                                            {
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
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (pieceList.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                if (x == xDestinationInt)
                                                {
                                                    if (y == yDestinationInt)
                                                    {
                                                        if (z == zDestinationInt)
                                                        {
                                                            isALegalMove = true;
                                                        }
                                                    }
                                                }
                                            }
                                            else if (xYZCube[x][y][z].GetCellContents() == null)
                                            {
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

            return isALegalMove;
        }
        private static void CheckForPawnPromotion(string copySelectedPieceString, int xDestinationInt, int yDestinationInt, int zDestinationInt)
        {
            if (copySelectedPieceString == " P ")
            {
                if (xDestinationInt == 8)
                {
                    List<string> choices = new List<string> { "R", "KN", "B", "Q" };
                    string promotionChoice = "hmm";
                    bool thisChoice = false;
                    while (thisChoice == false)
                    {
                        PrintBoardToConsole();
                        Console.WriteLine("Choose a promotion for this pawn:");
                        Console.WriteLine(" R , KN , B , Q ");
                        promotionChoice = Console.ReadLine();
                        promotionChoice = promotionChoice.ToUpper();
                        thisChoice = choices.Contains(promotionChoice);
                    }
                    if (promotionChoice == "R")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" R ");
                    }
                    if (promotionChoice == "KN")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" KN");
                    }
                    if (promotionChoice == "B")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" B ");
                    }
                    if (promotionChoice == "Q")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" Q ");
                    }

                }
            }
            if (copySelectedPieceString == " p ")
            {
                if (xDestinationInt == 1)
                {
                    List<string> choices = new List<string> { "R", "KN", "B", "Q" };
                    string promotionChoice = "hmm";
                    bool thisChoice = false;
                    while (thisChoice == false)
                    {
                        PrintBoardToConsole();
                        Console.WriteLine("Choose a promotion for this pawn:");
                        Console.WriteLine(" r , kn , b , q ");
                        promotionChoice = Console.ReadLine();
                        promotionChoice = promotionChoice.ToUpper();
                        thisChoice = choices.Contains(promotionChoice);
                    }
                    if (promotionChoice == "R")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" r ");
                    }
                    if (promotionChoice == "KN")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" kn");
                    }
                    if (promotionChoice == "B")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" b ");
                    }
                    if (promotionChoice == "Q")
                    {
                        xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(" q ");
                    }

                }
            }
        }
        private static void HighlightLegalMoves(string copySelectedPieceString, int xSelectionInt, int ySelectionInt, int zSelectionInt)
        {
            List<string> pieceList1 = new List<string>
            {
               " R "," KN"," B "," Q "," K "," P "
            };
            List<string> pieceList2 = new List<string>
            {
               " r "," kn"," b "," q "," k "," p "
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
                                                else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
                                                    break;
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
                                                else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
                                                    break;
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
                                                else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
                                                    break;
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
                                                else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
                                                    break;
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
                                                else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
                                                    break;
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
                                                else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                    break;
                                                }
                                                else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
                                                    break;
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
                                                else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                }
                                                else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
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
                                            else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                            }
                                            else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
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
                                                else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                                }
                                                else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                                {
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
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
                                            else if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                            }
                                            else if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
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
                if (xSelectionInt == 2)
                {
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
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
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
                                            if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                            }
                                            if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
                                            }
                                            if (xYZCube[x][y][z].GetCellContents() == "   ")
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
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
                if (xSelectionInt == 7)
                {

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
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkMagenta);
                                                }
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
                                            if (pieceList1.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkRed);
                                            }
                                            if (pieceList2.Contains(xYZCube[x][y][z].GetCellContents()) == true)
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
                                            }
                                            if (xYZCube[x][y][z].GetCellContents() == "   ")
                                            {
                                                xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGray);
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
            //experimental pieces
            
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
        private static void WriteTetrahedronBoardOntoCube()
        {
            for (int tz = 0; tz < 8; tz++)
            {
                List<string> secondlineStringList = new List<string>();

                for (int ty = 0; ty < 8; ty++)
                {
                    List<string> lineStringList = new List<string>();

                    for (int tx = 0; tx < 8; tx++)
                    {
                        int cx = tx + tz + 1;
                        int cy = ty + tz + 1;
                        int cz = tx + ty + 1;

                        if (cx < 9 && cy < 9 && cz < 9 && cx + cy + cz < 18)
                        {
                            xYZCube[cx][cy][cz].SetCellContents("   ");
                            string entry = cx.ToString() + cy.ToString() + cz.ToString() + xYZCube[cx][cy][cz].GetCellContents();
                            lineStringList.Add(entry);
                        }
                    }

                    foreach(string entry in lineStringList)
                    {
                        Console.Write(entry);
                    }
                }
                Console.WriteLine();
            }
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
            
            Console.Clear();
            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    for (int z = 1; z < 9; z++)
                    {
                        if (xYZCube[x][y][z].GetCellContents() != null)
                        {
                            Console.BackgroundColor = xYZCube[x][y][z].GetCellColor();
                            Console.Write(xYZCube[x][y][z].GetCellContents());
                            Console.BackgroundColor = xYZCube[x][y][z].SetDefaultCellColor();
                            Console.Write("|");
                            string entryCoordinate = x.ToString() + y.ToString() + z.ToString() + "|";
                            Console.Write(entryCoordinate);
                        }
                        else
                        {
                            string entry = "    ";
                            string entryCoordinate = "    ";
                            Console.Write(entry);
                            Console.Write(entryCoordinate);

                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }


            /*
            List<List<int>> row1 = new List<List<int>>
            {
            new List<int> { 1, 8, 8 },new List<int> { 2, 8, 7 },new List<int> { 3, 8, 6 },new List<int> { 4, 8, 5 },new List<int> { 5, 8, 4 },new List<int> { 6, 8, 3 },new List<int> { 7, 8, 2 },new List<int> { 8, 8, 1 }
            };
            List<List<int>> row2 = new List<List<int>>
            {
            new List<int> { 2, 7, 8 },new List<int> { 3, 7, 7 },new List<int> { 4, 7, 6 },new List<int> { 5, 7, 5 },new List<int> { 6, 7, 4 },new List<int> { 7, 7, 3 },new List<int> { 8, 7, 2 }
            };
            List<List<int>> row3 = new List<List<int>>
            {
            new List<int> { 1, 7, 7 },new List<int> { 2, 7, 6 },new List<int> { 3, 7, 5 },new List<int> { 4, 7, 4 },new List<int> { 5, 7, 3 },new List<int> { 6, 7, 2 },new List<int> { 7, 7, 1 }
            };
            List<List<int>> row4 = new List<List<int>>
            {
            new List<int> { 3, 6, 8 },new List<int> { 4, 6, 7 },new List<int> { 5, 6, 6 },new List<int> { 6, 6, 5 },new List<int> { 7, 6, 4 },new List<int> { 8, 6, 3 }
            };
            List<List<int>> row5 = new List<List<int>>
            {
            new List<int> { 2, 6, 7 },new List<int> { 3, 6, 6 },new List<int> { 4, 6, 5 },new List<int> { 5, 6, 4 },new List<int> { 6, 6, 3 },new List<int> { 7, 6, 2 }
            };
            List<List<int>> row6 = new List<List<int>>
            {
            new List<int> { 1, 6, 6 },new List<int> { 2, 6, 5 },new List<int> { 3, 6, 4 },new List<int> { 4, 6, 3 },new List<int> { 5, 6, 2 },new List<int> { 6, 6, 1 }
            };
            List<List<int>> row7 = new List<List<int>>
            {
            new List<int> {4 , 5, 8 },new List<int> {5 , 5, 7 },new List<int> {6 , 5, 6 },new List<int> {7 , 5, 5 },new List<int> {8 , 5, 4 }
            };
            List<List<int>> row8 = new List<List<int>>
            {
            new List<int> {3 , 5, 7 },new List<int> {4 , 5, 6 },new List<int> {5 , 5, 5 },new List<int> {6 , 5, 4 },new List<int> {7 , 5, 3 }
            };
            List<List<int>> row9 = new List<List<int>>
            {
            new List<int> { 2,5,6 },new List<int> { 3,5,5 },new List<int> { 4,5,4 },new List<int> { 5,5,3 },new List<int> { 6,5,2 }
            };
            List<List<int>> row10 = new List<List<int>>
            {
            new List<int> {1 ,5, 5},new List<int> {2 ,5, 4},new List<int> {3 ,5, 3},new List<int> {4 ,5, 2},new List<int> {5 ,5, 1}
            };
            List<List<int>> row11 = new List<List<int>>
            {
            new List<int> { 4,4,7 },new List<int> { 5,4,8 },new List<int> { 6,4,7 },new List<int> { 7,4,6 },new List<int> { 8,4,5 }
            };
            List<List<int>> row12 = new List<List<int>>
            {
            new List<int> { 3,4,6 },new List<int> { 4,4,5 },new List<int> { 5,4,6 },new List<int> { 6,4,5 },new List<int> { 7,4,4 }
            };
            List<List<int>> row13 = new List<List<int>>
            {
            new List<int> { 2,4,5 },new List<int> { 3,4,4 },new List<int> { 4,4,3 },new List<int> { 5,4,4 },new List<int> { 6,4,3 }
            };
            List<List<int>> row14 = new List<List<int>>
            {
            new List<int> { 1,4, 4},new List<int> { 2,4, 3},new List<int> { 3,4, 2},new List<int> { 4,4, 1},new List<int> { 5,4, 2}
            };
            List<List<int>> row15 = new List<List<int>>
            {
            new List<int> { 3,3,5 },new List<int> { 4,3,6 },new List<int> { 5,3,7 },new List<int> { 6,3,8 },new List<int> { 7,3,7 },new List<int> { 8,3,6 }
            };
            List<List<int>> row16 = new List<List<int>>
            {
            new List<int> { 2,3,4 },new List<int> { 3,3,3 },new List<int> { 4,3,4 },new List<int> { 5,3,5 },new List<int> { 6,3,6 },new List<int> { 7,3,5 }
            };
            List<List<int>> row17 = new List<List<int>>
            {
            new List<int> { 1,3,3 },new List<int> { 2,3,2 },new List<int> { 3,3,1 },new List<int> { 4,3,2 },new List<int> { 5,3,3 },new List<int> { 6,3,4 }
            };
            List<List<int>> row18 = new List<List<int>>
            {
            new List<int> { 2,2,3 },new List<int> { 3,2,4 },new List<int> { 4,2,5 },new List<int> { 5,2,6 },new List<int> { 6,2,7 },new List<int> { 7,2,8 },new List<int> { 8,2,7 }
            };
            List<List<int>> row19 = new List<List<int>>
            {
            new List<int> { 1,2,2 },new List<int> { 2,2,1 },new List<int> { 3,2,2 },new List<int> { 4,2,3 },new List<int> { 5,2,4 },new List<int> { 6,2,5 },new List<int> { 7,2,6 }
            };
            List<List<int>> row20 = new List<List<int>>
            {
            new List<int> { 1,1,1 }, new List<int> { 2,1,2 }, new List<int> { 3,1,3 }, new List<int> { 4,1,4 }, new List<int> { 5,1,5 }, new List<int> { 6,1,6 }, new List<int> { 7,1,7 }, new List<int> { 8,1,8 }
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
            Console.WriteLine("");
            Console.WriteLine("    |---|---|---|---|---|---|---|");

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
            Console.WriteLine("|---|278|377|476|575|674|773|872|");

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
            Console.WriteLine("|177|276|375|474|573|672|771|");
            Console.WriteLine("");
            Console.WriteLine("        |---|---|---|---|---|---|");


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
            Console.WriteLine("    |---|368|467|566|665|764|863|");


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
            Console.WriteLine("|---|267|366|465|564|663|762|");

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
            Console.WriteLine("|166|265|364|463|562|661|");
            Console.WriteLine("");
            Console.WriteLine("            |---|---|---|---|---|");


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
            Console.WriteLine("        |---|458|557|656|755|854|");


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
            Console.WriteLine("    |---|357|456|555|654|753|");


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
            Console.WriteLine("|---|256|355|454|553|652|");

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
            Console.WriteLine("|155|254|353|452|551|");
            Console.WriteLine("");
            Console.WriteLine("            |---|---|---|---|---|");


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
            Console.WriteLine("        |---|447|548|647|746|845|");


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
            Console.WriteLine("    |---|346|445|546|645|744|");


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
            Console.WriteLine("|---|245|344|443|544|643|");

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
            Console.WriteLine("|144|243|342|441|542|");
            Console.WriteLine("");
            Console.WriteLine("        |---|---|---|---|---|---|");


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
            Console.WriteLine("    |---|335|436|537|638|737|836|");


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
            Console.WriteLine("|---|234|333|434|535|636|735|");

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
            Console.WriteLine("|133|232|331|432|533|634|");
            Console.WriteLine("");
            Console.WriteLine("    |---|---|---|---|---|---|---|");


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
            Console.WriteLine("|---|223|324|425|526|627|728|827|");

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
            Console.WriteLine("|122|221|322|423|524|625|726|");
            Console.WriteLine("");
            Console.WriteLine("|---|---|---|---|---|---|---|---|");

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
            */
        }
    }
}