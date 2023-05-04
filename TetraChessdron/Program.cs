// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace TetraChessdron
{
    //
    class TetraChessdron
    {
        private static List<List<List<CubeCell>>> xYZCube = MakeCube();


        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            WriteTetrahedronBoardOntoCube();
            SetupTeams();
            PrintBoardToConsole();
            //MoveAPiece();
        }
 
        private static void CheckPiece(string copySelectedPieceString, int xSelectionInt, int ySelectionInt, int zSelectionInt)
        {

            Console.WriteLine(copySelectedPieceString);
            if (copySelectedPieceString == "-R-")
            {

            }
        }
        /*
        private static List<List<List<CubeCell>>> MoveAPiece()
        {
            List<List<List<CubeCell>>> pieceMovement = new List<List<List<CubeCell>>>();
            TetrahedronCell emptyCell = new TetrahedronCell();
            ConsoleColor colorDarkYellow = ConsoleColor.DarkYellow;
            ConsoleColor colorGray = ConsoleColor.Gray;

            Console.WriteLine("select a location to move from:");
            string xSelectionString = Console.ReadLine();
            int xSelectionInt = int.Parse(xSelectionString);
            string ySelectionString = Console.ReadLine();
            int ySelectionInt = int.Parse(ySelectionString);
            string zSelectionString = Console.ReadLine();
            int zSelectionInt = int.Parse(zSelectionString);

            string copySelectedPieceString = xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].CellContents();
            CheckPiece(copySelectedPieceString, xSelectionInt, ySelectionInt, zSelectionInt);

            Console.WriteLine("select a destination:");
            string xDestinationString = Console.ReadLine();
            int xDestinationInt = int.Parse(xDestinationString);
            string yDestinationString = Console.ReadLine();
            int yDestinationInt = int.Parse(yDestinationString);
            string zDestinationString = Console.ReadLine();
            int zDestinationInt = int.Parse(zDestinationString);

            string xYZCubeCell = xYZCube[xSelectionInt][ySelectionInt][zSelectionInt].CellContents();
            xYZCubeCell = emptyCell.EmptyTetrahedronCell();
            xYZCubeCell = copySelectedPieceString;
            
            


            PrintBoardToConsole();
            return pieceMovement;
        }
        */
        
        private static void SetupTeams()
        {
            //team 1
            xYZCube[1][1][1].SetCellContents("-R-");
            xYZCube[1][2][2].SetCellContents("-KN");
            xYZCube[1][3][3].SetCellContents("-B-");
            xYZCube[1][4][4].SetCellContents("-Q-");
            xYZCube[1][5][5].SetCellContents("-K-");
            xYZCube[1][6][6].SetCellContents("-B-");
            xYZCube[1][7][7].SetCellContents("-KN");
            xYZCube[1][8][8].SetCellContents("-R-");
            xYZCube[2][1][2].SetCellContents("-P-");
            xYZCube[2][2][1].SetCellContents("-P-");
            xYZCube[2][2][3].SetCellContents("-P-");
            xYZCube[2][3][2].SetCellContents("-P-");
            xYZCube[2][3][4].SetCellContents("-P-");
            xYZCube[2][4][3].SetCellContents("-P-");
            xYZCube[2][4][5].SetCellContents("-P-");
            xYZCube[2][5][4].SetCellContents("-P-");
            xYZCube[2][5][6].SetCellContents("-P-");
            xYZCube[2][6][5].SetCellContents("-P-");
            xYZCube[2][6][7].SetCellContents("-P-");
            xYZCube[2][7][6].SetCellContents("-P-");
            xYZCube[2][7][8].SetCellContents("-P-");
            xYZCube[2][8][7].SetCellContents("-P-");
            //team 2
            xYZCube[8][1][8].SetCellContents("-r-");
            xYZCube[8][2][7].SetCellContents("-kn");
            xYZCube[8][3][6].SetCellContents("-b-");
            xYZCube[8][4][5].SetCellContents("-q-");
            xYZCube[8][5][4].SetCellContents("-k-");
            xYZCube[8][6][3].SetCellContents("-b-");
            xYZCube[8][7][2].SetCellContents("-kn");
            xYZCube[8][8][1].SetCellContents("-r-");
            xYZCube[7][1][7].SetCellContents("-p-");
            xYZCube[7][2][6].SetCellContents("-p-");
            xYZCube[7][2][8].SetCellContents("-p-");
            xYZCube[7][3][5].SetCellContents("-p-");
            xYZCube[7][3][7].SetCellContents("-p-");
            xYZCube[7][4][4].SetCellContents("-p-");
            xYZCube[7][4][6].SetCellContents("-p-");
            xYZCube[7][5][3].SetCellContents("-p-");
            xYZCube[7][5][5].SetCellContents("-p-");
            xYZCube[7][6][2].SetCellContents("-p-");
            xYZCube[7][6][4].SetCellContents("-p-");
            xYZCube[7][7][1].SetCellContents("-p-");
            xYZCube[7][7][3].SetCellContents("-p-");
            xYZCube[7][8][2].SetCellContents("-p-");
        }
        
        private static List<List<List<CubeCell>>> WriteTetrahedronBoardOntoCube() 
        {
            List<List<List<CubeCell>>> tetrahedronInACube = new List<List<List<CubeCell>>>();
            CubeCell cellContent = new CubeCell();
            TetrahedronCell emptyCell = new TetrahedronCell();

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
                        string cellContents = emptyCell.EmptyTetrahedronCell();
                        xYZCube[x][y][z].SetCellContents(cellContents);
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
            ConsoleColor colorDarkYellow = ConsoleColor.DarkYellow;
            ConsoleColor colorGray = ConsoleColor.Gray;
            ConsoleColor colorDarkRed = ConsoleColor.DarkRed;
            ConsoleColor colorDarkBlue = ConsoleColor.DarkBlue;
            ConsoleColor currentColor;

            public void SetCellColor(ConsoleColor setCellColor)
            {
                currentColor = setCellColor;
            }
            public ConsoleColor GetCellColor() 
            {
                return currentColor;
            }
            public void SetCellContents(string cellContentUpdate)
            {
                cellContents = cellContentUpdate;
            }
            public string SetCellContentsToEmpty()
            {
                cellContents = "-+-";
                return cellContents;
            }
            public string getCellContents()
            {
                return cellContents;
            }

        }
        class TetrahedronCell
        {
            private static string anEmptyCell = "-+-";
            public string EmptyTetrahedronCell()
            {
                return anEmptyCell;
            }

        }
        
        private static void PrintBoardToConsole()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"|" + xYZCube[1][8][8].getCellContents() + "|" + xYZCube[2][8][7].getCellContents() + "|" + xYZCube[3][8][6].getCellContents() + "|" + xYZCube[4][8][5].getCellContents() + "|" + xYZCube[5][8][4].getCellContents() + "|" + xYZCube[6][8][3].getCellContents() + "|" + xYZCube[7][8][2].getCellContents() + "|" + xYZCube[8][8][1].getCellContents() + "|") ;
            Console.WriteLine($"|188|287|386|485|584|683|782|881|");
            Console.WriteLine($"    |"+xYZCube[2][7][6].getCellContents()+"|"+xYZCube[3][7][5].getCellContents()+"|"+xYZCube[4][7][4].getCellContents()+"|"+xYZCube[5][7][3].getCellContents()+"|"+xYZCube[6][7][2].getCellContents()+"|"+xYZCube[7][7][1].getCellContents()+"|"+xYZCube[8][7][2].getCellContents()+"|");
            Console.WriteLine($"|---|276|375|474|573|672|771|872|");
            Console.WriteLine($"|"+xYZCube[1][7][7].getCellContents()+"|"+xYZCube[2][7][8].getCellContents()+"|"+xYZCube[3][7][7].getCellContents()+"|"+xYZCube[4][7][6].getCellContents()+"|"+xYZCube[5][7][5].getCellContents()+"|"+xYZCube[6][7][4].getCellContents()+"|"+xYZCube[7][7][3].getCellContents()+"|");
            Console.WriteLine($"|177|278|377|476|575|674|773|---|");
            Console.WriteLine($"        |"+xYZCube[3][6][4].getCellContents()+"|"+xYZCube[4][6][3].getCellContents()+"|"+xYZCube[5][6][2].getCellContents()+"|"+xYZCube[6][6][1].getCellContents()+"|"+xYZCube[7][6][1].getCellContents()+"|"+xYZCube[8][6][3].getCellContents()+"|");
            Console.WriteLine($"    |364|463|562|661|761|863|---|");
            Console.WriteLine($"    |"+xYZCube[2][6][5].getCellContents()+"|"+xYZCube[3][6][6].getCellContents()+"|"+xYZCube[4][6][5].getCellContents()+"|"+xYZCube[5][6][4].getCellContents()+"|"+xYZCube[6][6][3].getCellContents()+"|"+xYZCube[7][6][4].getCellContents()+"|");
            Console.WriteLine($"|---|265|366|465|564|663|764|");
            Console.WriteLine($"|"+xYZCube[1][6][6].getCellContents()+"|"+xYZCube[2][6][7].getCellContents()+"|"+xYZCube[3][6][8].getCellContents()+"|"+xYZCube[4][6][7].getCellContents()+"|"+xYZCube[5][6][6].getCellContents()+"|"+xYZCube[6][6][5].getCellContents()+"|");
            Console.WriteLine($"|166|267|368|467|566|665|---|---|");
            Console.WriteLine($"            |"+xYZCube[4][5][2].getCellContents()+"|"+xYZCube[5][5][1].getCellContents()+"|"+xYZCube[6][5][2].getCellContents()+"|"+xYZCube[7][5][3].getCellContents()+"|"+xYZCube[8][5][4].getCellContents()+"|");
            Console.WriteLine($"        |---|452|551|652|753|854|");
            Console.WriteLine($"        |"+xYZCube[3][5][3].getCellContents()+"|"+xYZCube[4][5][4].getCellContents()+"|"+xYZCube[5][5][3].getCellContents()+"|"+xYZCube[6][5][4].getCellContents()+"|"+xYZCube[7][5][5].getCellContents()+"|");
            Console.WriteLine($"    |---|353|454|553|654|755|");
            Console.WriteLine($"    |"+xYZCube[2][5][4].getCellContents()+"|"+xYZCube[3][5][5].getCellContents()+"|"+xYZCube[4][5][6].getCellContents()+"|"+xYZCube[5][5][5].getCellContents()+"|"+xYZCube[6][5][6].getCellContents()+"|");
            Console.WriteLine($"|---|254|355|456|555|656|");
            Console.WriteLine($"|"+xYZCube[1][5][5].getCellContents()+"|"+xYZCube[2][5][6].getCellContents()+"|"+xYZCube[3][5][7].getCellContents()+"|"+xYZCube[4][5][8].getCellContents()+"|"+xYZCube[5][5][7].getCellContents()+"|");
            Console.WriteLine($"|155|256|357|458|557|---|---|---|");
            Console.WriteLine($"            |"+xYZCube[4][4][1].getCellContents()+"|"+xYZCube[5][4][2].getCellContents()+"|"+xYZCube[6][4][3].getCellContents()+"|"+xYZCube[7][4][4].getCellContents()+"|"+xYZCube[8][4][5].getCellContents()+"|");
            Console.WriteLine($"        |441|542|643|744|845|---|");
            Console.WriteLine($"        |"+xYZCube[3][4][2].getCellContents()+"|"+xYZCube[4][4][3].getCellContents()+"|"+xYZCube[5][4][4].getCellContents()+"|"+xYZCube[6][4][5].getCellContents()+"|"+xYZCube[7][4][6].getCellContents()+"|");
            Console.WriteLine($"        |342|443|544|645|746|");
            Console.WriteLine($"    |"+xYZCube[2][4][3].getCellContents()+"|"+xYZCube[3][4][4].getCellContents()+"|"+xYZCube[4][4][5].getCellContents()+"|"+xYZCube[5][4][6].getCellContents()+"|"+xYZCube[6][4][7].getCellContents()+"|");
            Console.WriteLine($"|---|243|344|445|546|647|");
            Console.WriteLine($"|"+xYZCube[1][4][4].getCellContents()+"|"+xYZCube[2][4][5].getCellContents()+"|"+xYZCube[3][4][6].getCellContents()+"|"+xYZCube[4][4][7].getCellContents()+"|"+xYZCube[5][4][8].getCellContents()+"|");
            Console.WriteLine($"|144|245|346|447|548|---|---|---|");
            Console.WriteLine($"        |"+xYZCube[3][3][1].getCellContents()+"|"+xYZCube[4][3][2].getCellContents()+"|"+xYZCube[5][3][3].getCellContents()+"|"+xYZCube[6][3][4].getCellContents()+"|"+xYZCube[7][3][5].getCellContents()+"|"+xYZCube[8][3][6].getCellContents()+"|");
            Console.WriteLine($"        |331|432|533|634|735|836|");
            Console.WriteLine($"    |"+xYZCube[2][3][2].getCellContents()+"|"+xYZCube[3][3][3].getCellContents()+"|"+xYZCube[4][3][4].getCellContents()+"|"+xYZCube[5][3][5].getCellContents()+"|"+xYZCube[6][3][6].getCellContents()+"|"+xYZCube[7][3][7].getCellContents()+"|");
            Console.WriteLine($"|---|232|333|434|535|636|737|");
            Console.WriteLine($"|"+xYZCube[1][3][3].getCellContents()+"|"+xYZCube[2][3][4].getCellContents()+"|"+xYZCube[3][3][5].getCellContents()+"|"+xYZCube[4][3][6].getCellContents()+"|"+xYZCube[5][3][7].getCellContents()+"|"+xYZCube[6][3][8].getCellContents()+"|");
            Console.WriteLine($"|133|234|335|436|537|638|---|---|");
            Console.WriteLine($"    |"+xYZCube[2][2][1].getCellContents()+"|"+xYZCube[3][2][2].getCellContents()+"|"+xYZCube[4][2][3].getCellContents()+"|"+xYZCube[5][2][4].getCellContents()+"|"+xYZCube[6][2][5].getCellContents()+"|"+xYZCube[7][2][6].getCellContents()+"|"+xYZCube[8][2][7].getCellContents()+"|");
            Console.WriteLine($"|---|221|322|423|524|625|726|827|");
            Console.WriteLine($"|"+xYZCube[1][2][2].getCellContents()+"|"+xYZCube[2][2][3].getCellContents()+"|"+xYZCube[3][2][4].getCellContents()+"|"+xYZCube[4][2][5].getCellContents()+"|"+xYZCube[5][2][6].getCellContents()+"|"+xYZCube[6][2][7].getCellContents()+"|"+xYZCube[7][2][8].getCellContents()+"|");
            Console.WriteLine($"|122|223|324|425|526|627|728|---|");
            Console.WriteLine($"|"+xYZCube[1][1][1].getCellContents()+"|"+xYZCube[2][1][2].getCellContents()+"|"+xYZCube[3][1][3].getCellContents()+"|"+xYZCube[4][1][4].getCellContents()+"|"+xYZCube[5][1][5].getCellContents()+"|"+xYZCube[6][1][6].getCellContents()+"|"+xYZCube[7][1][7].getCellContents()+"|"+xYZCube[8][1][8].getCellContents()+"|");
            Console.WriteLine($"|111|212|313|414|515|616|717|818|");
            Console.WriteLine("");
        }
        
        private static void PrintPrototypeBoardToConsole()
        {

            string G188 = "-0-";
            string G287 = "-0-";
            string G386 = "-0-";
            string G485 = "-0-";
            string G584 = "-0-";
            string G683 = "-0-";
            string G782 = "-0-";
            string G881 = "-0-";
            string G276 = "-0-";
            string G375 = "-0-";
            string G474 = "-0-";
            string G573 = "-0-";
            string G672 = "-0-";
            string G771 = "-0-";
            string G872 = "-0-";
            string G177 = "-0-";
            string G278 = "-0-";
            string G377 = "-0-";
            string G476 = "-0-";
            string G575 = "-0-";
            string G675 = "-0-";
            string G773 = "-0-";
            string G364 = "-0-";
            string G463 = "-0-";
            string G562 = "-0-";
            string G661 = "-0-";
            string G761 = "-0-";
            string G863 = "-0-";
            string G265 = "-0-";
            string G366 = "-0-";
            string G465 = "-0-";
            string G564 = "-0-";
            string G663 = "-0-";
            string G764 = "-0-";
            string G166 = "-0-";
            string G267 = "-0-";
            string G368 = "-0-";
            string G467 = "-0-";
            string G566 = "-0-";
            string G665 = "-0-";
            string G452 = "-0-";
            string G551 = "-0-";
            string G652 = "-0-";
            string G753 = "-0-";
            string G854 = "-0-";
            string G353 = "-0-";
            string G454 = "-0-";
            string G553 = "-0-";
            string G654 = "-0-";
            string G755 = "-0-";
            string G254 = "-0-";
            string G355 = "-0-";
            string G456 = "-0-";
            string G555 = "-0-";
            string G656 = "-0-";
            string G155 = "-0-";
            string G256 = "-0-";
            string G357 = "-0-";
            string G458 = "-0-";
            string G557 = "-0-";
            string G441 = "-0-";
            string G542 = "-0-";
            string G643 = "-0-";
            string G744 = "-0-";
            string G845 = "-0-";
            string G342 = "-0-";
            string G443 = "-0-";
            string G544 = "-0-";
            string G645 = "-0-";
            string G746 = "-0-";
            string G243 = "-0-";
            string G344 = "-0-";
            string G445 = "-0-";
            string G546 = "-0-";
            string G647 = "-0-";
            string G144 = "-0-";
            string G245 = "-0-";
            string G346 = "-0-";
            string G447 = "-0-";
            string G548 = "-0-";
            string G331 = "-0-";
            string G432 = "-0-";
            string G533 = "-0-";
            string G634 = "-0-";
            string G735 = "-0-";
            string G836 = "-0-";
            string G232 = "-0-";
            string G333 = "-0-";
            string G434 = "-0-";
            string G535 = "-0-";
            string G636 = "-0-";
            string G737 = "-0-";
            string G133 = "-0-";
            string G234 = "-0-";
            string G335 = "-0-";
            string G436 = "-0-";
            string G537 = "-0-";
            string G638 = "-0-";
            string G221 = "-0-";
            string G322 = "-0-";
            string G423 = "-0-";
            string G524 = "-0-";
            string G625 = "-0-";
            string G726 = "-0-";
            string G827 = "-0-";
            string G122 = "-0-";
            string G223 = "-0-";
            string G324 = "-0-";
            string G425 = "-0-";
            string G526 = "-0-";
            string G627 = "-0-";
            string G728 = "-0-";
            string G111 = "-0-";
            string G212 = "-0-";
            string G313 = "-0-";
            string G414 = "-0-";
            string G515 = "-0-";
            string G616 = "-0-";
            string G717 = "-0-";
            string G818 = "-0-";

            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"|{G188}|{G287}|{G386}|{G485}|{G584}|{G683}|{G782}|{G881}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"    |{G276}|{G375}|{G474}|{G573}|{G672}|{G771}|{G872}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"|{G177}|{G278}|{G377}|{G476}|{G575}|{G675}|{G773}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"        |{G364}|{G463}|{G562}|{G661}|{G761}|{G863}|");
            Console.WriteLine($"    |---|---|---|---|---|---|---|");
            Console.WriteLine($"    |{G265}|{G366}|{G465}|{G564}|{G663}|{G764}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|");
            Console.WriteLine($"|{G166}|{G267}|{G368}|{G467}|{G566}|{G665}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"            |{G452}|{G551}|{G652}|{G753}|{G854}|");
            Console.WriteLine($"        |---|---|---|---|---|---|");
            Console.WriteLine($"        |{G353}|{G454}|{G553}|{G654}|{G755}|");
            Console.WriteLine($"    |---|---|---|---|---|---|");
            Console.WriteLine($"    |{G254}|{G355}|{G456}|{G555}|{G656}|");
            Console.WriteLine($"|---|---|---|---|---|---|");
            Console.WriteLine($"|{G155}|{G256}|{G357}|{G458}|{G557}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"            |{G441}|{G542}|{G643}|{G744}|{G845}|");
            Console.WriteLine($"        |---|---|---|---|---|---|");
            Console.WriteLine($"        |{G342}|{G443}|{G544}|{G645}|{G746}|");
            Console.WriteLine($"        |---|---|---|---|---|");
            Console.WriteLine($"    |{G243}|{G344}|{G445}|{G546}|{G647}|");
            Console.WriteLine($"|---|---|---|---|---|---|");
            Console.WriteLine($"|{G144}|{G245}|{G346}|{G447}|{G548}|");
            Console.WriteLine($"|---|---|---|---|---|---|");
            Console.WriteLine($"        |{G331}|{G432}|{G533}|{G634}|{G735}|{G836}|");
            Console.WriteLine($"        |---|---|---|---|---|---|");
            Console.WriteLine($"    |{G232}|{G333}|{G434}|{G535}|{G636}|{G737}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|");
            Console.WriteLine($"|{G133}|{G234}|{G335}|{G436}|{G537}|{G638}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"    |{G221}|{G322}|{G423}|{G524}|{G625}|{G726}|{G827}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"|{G122}|{G223}|{G324}|{G425}|{G526}|{G627}|{G728}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine($"|{G111}|{G212}|{G313}|{G414}|{G515}|{G616}|{G717}|{G818}|");
            Console.WriteLine($"|---|---|---|---|---|---|---|---|");
            Console.WriteLine("");
        }
    }
}
