﻿// See https://aka.ms/new-console-template for more information
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

        private static bool hasTeam1KingMoved = false;
        private static bool hasTeam1Rook1Moved = false;
        private static bool hasTeam1Rook2Moved = false;
        private static bool hasTeam2KingMoved = false;
        private static bool hasTeam2Rook1Moved = false;
        private static bool hasTeam2Rook2Moved = false;

        private static bool hasTeam1UsedPawnOpeningMove = false;
        private static bool hasTeam2UsedPawnOpeningMove = false;
        private static List<int> team1LastPawnOpeningMoveOrigin = new List<int> { 0, 0, 0 };
        private static List<int> team1LastPawnOpeningMoveEnd = new List<int> { 0, 0, 0 };
        private static List<int> team1LastPawnOpeningMoveAttackLocation = new List<int> { 0, 0, 0 };
        private static List<int> team2LastPawnOpeningMoveOrigin = new List<int> { 0, 0, 0 };
        private static List<int> team2LastPawnOpeningMoveEnd = new List<int> { 0, 0, 0 };
        private static List<int> team2LastPawnOpeningMoveAttackLocation = new List<int> { 0, 0, 0 };

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
                    hasTeam1UsedPawnOpeningMove = false;
                }
                else
                {
                    Console.WriteLine("Player 2's turn");
                    hasTeam2UsedPawnOpeningMove = false;
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
                                            if (x < 9&&x > 0&&y < 9&&y > 0&&z < 9&&z > 0)
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




            //save one move, to undo if self check
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

            if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " K ")
            {
                if (xDestinationInt == 1 && yDestinationInt == 3 && zDestinationInt == 3)
                {
                    xYZCube[1][1][1].SetCellContents("   ");
                    xYZCube[1][4][4].SetCellContents(" R ");
                }
                if (xDestinationInt == 1 && yDestinationInt == 7 && zDestinationInt == 7)
                {

                    xYZCube[1][8][8].SetCellContents("   ");
                    xYZCube[1][6][6].SetCellContents(" R ");
                }
            }
            if (xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].GetCellContents() == " k ")
            {
                if (xDestinationInt == 8 && yDestinationInt == 6 && zDestinationInt == 3)
                {
                    xYZCube[8][8][1].SetCellContents("   ");
                    xYZCube[8][5][4].SetCellContents(" r ");
                }
                if (xDestinationInt == 8 && yDestinationInt == 2 && zDestinationInt == 7)
                {

                    xYZCube[8][1][8].SetCellContents("   ");
                    xYZCube[8][3][6].SetCellContents(" r ");
                }
            }

            xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].SetCellContentsToEmpty();
            xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].SetCellContents(copySelectedPieceString);

            if (CheckForLegalPieceMoveset(copySelectedPieceString, xSelectionInt, ySelectionInt, zSelectionInt, xDestinationInt, yDestinationInt, zDestinationInt) == false)
            {
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        for (int z = 0; z < 9; z++)
                        {
                            xYZCube[x][y][z].SetCellContents(previousXYZCube[x][y][z].GetCellContents());
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

                PrintBoardToConsole();
                Console.WriteLine("not a legal move for this piece");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }
            if (SelfCheckCheck(thePlayersTurnBool) == true)
            {
               
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        for (int z = 0; z < 9; z++)
                        {
                            xYZCube[x][y][z].SetCellContents(previousXYZCube[x][y][z].GetCellContents());
                        }
                    }
                }
                PrintBoardToConsole();
                Console.WriteLine("cannot make move, would endanger king");
                thePlayersTurnBool = !thePlayersTurnBool;
                return;
            }
            if (hasTeam1KingMoved == false)
            {
                if (xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].GetCellContents() == " K ")
                {
                    hasTeam1KingMoved = true;
                }
            }
            if (hasTeam2KingMoved == false)
            {
                if (xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].GetCellContents() == " k ")
                {
                    hasTeam2KingMoved = true;
                }
            }
            if (hasTeam1Rook1Moved == false| hasTeam1Rook2Moved == false)
            {
                if (xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].GetCellContents() == " R ")
                {
                    if (xSelectionInt == 1 && ySelectionInt == 1 && zSelectionInt == 1)
                    {
                        hasTeam1Rook1Moved = true;
                    }
                    if (xSelectionInt == 1 && ySelectionInt == 8 && zSelectionInt == 8)
                    {
                        hasTeam1Rook2Moved = true;
                    }
                }
            }
            if (hasTeam2Rook1Moved == false | hasTeam2Rook2Moved == false)
            {
                if (xYZCube[xDestinationInt][yDestinationInt][zDestinationInt].GetCellContents() == " r ")
                {
                    if (xSelectionInt == 8 && ySelectionInt == 8 && zSelectionInt == 1)
                    {
                        hasTeam2Rook1Moved = true;
                    }
                    if (xSelectionInt == 8 && ySelectionInt == 1 && zSelectionInt == 8)
                    {
                        hasTeam2Rook2Moved = true;
                    }
                }
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
                if (hasTeam1KingMoved == false && hasTeam1Rook1Moved == false && xYZCube[1][2][2].GetCellContents() == "   " && xYZCube[1][3][3].GetCellContents() == "   " && xYZCube[1][4][4].GetCellContents() == "   ")
                {
                    isALegalMove = true;
                }
                if (hasTeam1KingMoved == false && hasTeam1Rook2Moved == false && xYZCube[1][7][7].GetCellContents() == "   " && xYZCube[1][6][6].GetCellContents() == "   ")
                {
                    isALegalMove = true;
                }
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
                if (hasTeam2KingMoved == false && hasTeam2Rook1Moved == false && xYZCube[8][7][2].GetCellContents() == "   " && xYZCube[8][6][3].GetCellContents() == "   " && xYZCube[8][5][4].GetCellContents() == "   ")
                {
                    isALegalMove = true;
                }
                if (hasTeam2KingMoved == false && hasTeam2Rook2Moved == false && xYZCube[8][2][7].GetCellContents() == "   " && xYZCube[8][3][6].GetCellContents() == "   ")
                {
                    isALegalMove = true;
                }
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
                                                                team1LastPawnOpeningMoveOrigin[0] = xSelectionInt;
                                                                team1LastPawnOpeningMoveOrigin[1] = ySelectionInt;
                                                                team1LastPawnOpeningMoveOrigin[2] = zSelectionInt;
                                                                team1LastPawnOpeningMoveEnd[0] = xDestinationInt;
                                                                team1LastPawnOpeningMoveEnd[1] = yDestinationInt;
                                                                team1LastPawnOpeningMoveEnd[2] = zDestinationInt;
                                                                team1LastPawnOpeningMoveAttackLocation[0] = ((xDestinationInt - xSelectionInt) / 2) + xSelectionInt;
                                                                team1LastPawnOpeningMoveAttackLocation[1] = ((yDestinationInt - ySelectionInt) / 2) + ySelectionInt;
                                                                team1LastPawnOpeningMoveAttackLocation[2] = ((zDestinationInt - zSelectionInt) / 2) + zSelectionInt;
                                                                hasTeam1UsedPawnOpeningMove = true;
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
                                            if (hasTeam2UsedPawnOpeningMove == true)
                                            {
                                                if (x == 5)
                                                {

                                                }
                                            }
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

                List<List<int>> enPassantTargetOriginMoveset = new List<List<int>>
                {
                    new List<int> {2,1,3},
                    new List<int> {2,3,1},
                    new List<int> {2,1,-3},
                    new List<int> {2,3,-1},
                    new List<int> {2,-1,3},
                    new List<int> {2,-3,1},
                    new List<int> {2,-1,-3},
                    new List<int> {2,-3,-1}
                };
                if (hasTeam2UsedPawnOpeningMove == true)
                {
                    foreach (List<int> target in enPassantTargetOriginMoveset)
                    {
                        if (xSelectionInt + target[0] == team2LastPawnOpeningMoveOrigin[0] && ySelectionInt + target[1] == team2LastPawnOpeningMoveOrigin[1] && zSelectionInt + target[2] == team2LastPawnOpeningMoveOrigin[2])
                        {
                                if (xYZCube[team2LastPawnOpeningMoveAttackLocation[0]][team2LastPawnOpeningMoveAttackLocation[1]][team2LastPawnOpeningMoveAttackLocation[2]].GetCellContents() == "  ")
                                {
                                    isALegalMove = true;
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
                                                                team2LastPawnOpeningMoveOrigin[0] = xSelectionInt;
                                                                team2LastPawnOpeningMoveOrigin[1] = ySelectionInt;
                                                                team2LastPawnOpeningMoveOrigin[2] = zSelectionInt;
                                                                team2LastPawnOpeningMoveEnd[0] = xDestinationInt;
                                                                team2LastPawnOpeningMoveEnd[1] = yDestinationInt;
                                                                team2LastPawnOpeningMoveEnd[2] = zDestinationInt;
                                                                team2LastPawnOpeningMoveAttackLocation[0] = ((xDestinationInt- xSelectionInt)/2)+ xSelectionInt;
                                                                team2LastPawnOpeningMoveAttackLocation[1] = ((yDestinationInt- ySelectionInt)/2)+ ySelectionInt;
                                                                team2LastPawnOpeningMoveAttackLocation[2] = ((zDestinationInt- zSelectionInt)/2)+ zSelectionInt;
                                                                hasTeam2UsedPawnOpeningMove = true;
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

                List<List<int>> enPassantTargetOriginMoveset = new List<List<int>>
                {
                    new List<int> {2,1,3},
                    new List<int> {2,3,1},
                    new List<int> {2,1,-3},
                    new List<int> {2,3,-1},
                    new List<int> {2,-1,3},
                    new List<int> {2,-3,1},
                    new List<int> {2,-1,-3},
                    new List<int> {2,-3,-1}
                };
                if (hasTeam1UsedPawnOpeningMove == true)
                {
                    foreach (List<int> target in enPassantTargetOriginMoveset)
                    {
                        if (xSelectionInt + target[0] == team1LastPawnOpeningMoveOrigin[0] && ySelectionInt + target[1] == team1LastPawnOpeningMoveOrigin[1] && zSelectionInt + target[2] == team1LastPawnOpeningMoveOrigin[2])
                        {
                                if (xYZCube[team1LastPawnOpeningMoveAttackLocation[0]][team1LastPawnOpeningMoveAttackLocation[1]][team1LastPawnOpeningMoveAttackLocation[2]].GetCellContents() == "  ")
                                {
                                    isALegalMove = true;
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
                if (hasTeam1KingMoved == false&&hasTeam1Rook1Moved == false && xYZCube[1][2][2].GetCellContents() == "   "&& xYZCube[1][3][3].GetCellContents() == "   "&& xYZCube[1][4][4].GetCellContents() == "   ")
                {

                    xYZCube[1][3][3].SetCellColor(ConsoleColor.DarkGreen);
                }
                if (hasTeam1KingMoved == false && hasTeam1Rook2Moved == false && xYZCube[1][7][7].GetCellContents() == "   " && xYZCube[1][6][6].GetCellContents() == "   ")
                {
                    xYZCube[1][7][7].SetCellColor(ConsoleColor.DarkGreen);
                }

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
                if (hasTeam2KingMoved == false && hasTeam2Rook1Moved == false && xYZCube[8][7][2].GetCellContents() == "   " && xYZCube[8][6][3].GetCellContents() == "   " && xYZCube[8][5][4].GetCellContents() == "   ")
                {
                    xYZCube[8][6][3].SetCellColor(ConsoleColor.DarkGreen);
                }
                if (hasTeam2KingMoved == false && hasTeam2Rook2Moved == false && xYZCube[8][2][7].GetCellContents() == "   " && xYZCube[8][3][6].GetCellContents() == "   ")
                {
                    xYZCube[8][2][7].SetCellColor(ConsoleColor.DarkGreen);
                }
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
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGreen);
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

                List<List<int>> enPassantTargetOriginMoveset = new List<List<int>>
                {
                    new List<int> {2,1,3},
                    new List<int> {2,3,1},
                    new List<int> {2,1,-3},
                    new List<int> {2,3,-1},
                    new List<int> {2,-1,3},
                    new List<int> {2,-3,1},
                    new List<int> {2,-1,-3},
                    new List<int> {2,-3,-1},
                };
                if (hasTeam2UsedPawnOpeningMove == true)
                {
                    foreach (List<int> target in enPassantTargetOriginMoveset)
                    {
                        if (xSelectionInt + target[0] == team2LastPawnOpeningMoveOrigin[0] && ySelectionInt + target[1] == team2LastPawnOpeningMoveOrigin[1] && zSelectionInt + target[2] == team2LastPawnOpeningMoveOrigin[2])
                        {
                            if (Math.Abs(xSelectionInt - team2LastPawnOpeningMoveEnd[0]) == 0 && Math.Abs(ySelectionInt - team2LastPawnOpeningMoveEnd[1]) == 1 && Math.Abs(zSelectionInt - team2LastPawnOpeningMoveEnd[2]) == 1)
                            {
                                if(xYZCube[team2LastPawnOpeningMoveAttackLocation[0]][team2LastPawnOpeningMoveAttackLocation[1]][team2LastPawnOpeningMoveAttackLocation[2]].GetCellContents() == "  ")
                                {
                                    xYZCube[team2LastPawnOpeningMoveAttackLocation[0]][team2LastPawnOpeningMoveAttackLocation[1]][team2LastPawnOpeningMoveAttackLocation[2]].SetCellColor(ConsoleColor.DarkGreen);
                                }
                            }
                        }
                    }
                }
            }
            if (copySelectedPieceString == " p ")
            {
                List<List<int>> enPassantTargetOriginMoveset = new List<List<int>>
                {
                    new List<int> {-2,1,3},
                    new List<int> {-2,3,1},
                    new List<int> {-2,1,-3},
                    new List<int> {-2,3,-1},
                    new List<int> {-2,-1,3},
                    new List<int> {-2,-3,1},
                    new List<int> {-2,-1,-3},
                    new List<int> {-2,-3,-1},
                };
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
                                                    xYZCube[x][y][z].SetCellColor(ConsoleColor.DarkGreen);
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

                if (hasTeam1UsedPawnOpeningMove == true)
                {
                    foreach (List<int> target in enPassantTargetOriginMoveset)
                    {
                        if (xSelectionInt + target[0] == team1LastPawnOpeningMoveOrigin[0] && ySelectionInt + target[1] == team1LastPawnOpeningMoveOrigin[1] && zSelectionInt + target[2] == team1LastPawnOpeningMoveOrigin[2])
                        {
                            if (Math.Abs(xSelectionInt - team1LastPawnOpeningMoveEnd[0]) == 0 && Math.Abs(ySelectionInt - team1LastPawnOpeningMoveEnd[1]) == 1 && Math.Abs(zSelectionInt - team1LastPawnOpeningMoveEnd[2]) == 1)
                            {
                                if (xYZCube[team1LastPawnOpeningMoveAttackLocation[0]][team1LastPawnOpeningMoveAttackLocation[1]][team1LastPawnOpeningMoveAttackLocation[2]].GetCellContents() == "  ")
                                {
                                    xYZCube[team1LastPawnOpeningMoveAttackLocation[0]][team1LastPawnOpeningMoveAttackLocation[1]][team1LastPawnOpeningMoveAttackLocation[2]].SetCellColor(ConsoleColor.DarkGreen);
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
            xYZCube[8][4][5].SetCellContents(" k ");
            xYZCube[8][5][4].SetCellContents(" q ");
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
        }
    }
}