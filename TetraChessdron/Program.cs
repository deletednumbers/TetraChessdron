// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace TetraChessdron
{
    class TetraChessdron
    {
        static void Main(string[] args)
        {
            List<List<List<string>>> cube = MakeCube();

            Console.WriteLine("Hello, World!");
            PrintPrototypeBoardToConsole();
            Console.WriteLine(cube[8][8][8]);
        }

        private static List<List<List<string>>> MakeCube()
        {
            List<List<List<string>>> board = new List<List<List<string>>>();

            for (var index = 0; index < 9; index++)
            {
                board.Add(MakePlaneOfCube());
            }

            return board;
        }
        private static List<List<string>> MakePlaneOfCube()
        {
            List<List<string>> plane = new List<List<string>>();

            for (var index = 0; index < 9; index++)
            {
                plane.Add(MakeRowOfCube());
            }

            return plane;
        }
        private static List<string> MakeRowOfCube()
        {
            List<string> row = new List<string>();

            for (var index = 0; index < 9; index++)
            {
                CubeCell newCell = new CubeCell();
                row.Add(newCell.EmptyCubeCell());
            }

            return row;
        }
        class CubeCell 
        {
            private static string anEmptyCell = "";
            public string EmptyCubeCell()
            {
                return anEmptyCell;
            }

        }
        /*
        private static void PrintBoardToConsole()
        {
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
        */
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
