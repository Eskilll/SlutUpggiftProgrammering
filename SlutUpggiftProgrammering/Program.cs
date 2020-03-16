using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutUpggiftProgrammering
{
    class Program
    {
        static void Main(string[] args)
        {
            //här skapar jag allt jag kommer behöva för att få mitt spel att fungera, t.ex mina bools för key(som leder ut och låter dig öppna en drawer för att få keycard)
            string playerA = "";
            bool key = false;
            bool keycard = false;
            bool truewin = false;
            string room = "Puzzle1";
            string inpt = "";
            //här skapar jag en array med alla mina room descriptions som jag tyvvär inte han skriva i detalj men de räcker för att spelet ska fungera.
            string[] roomdesc = { "PuzzleRoom... go east, go south(keycard)", "FightRoom... go fight"};
            //jag använder de finaste färgerna möjligt för min fina kod, "bluescreen blå" som bakgrund och "flashbang vit" som text
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            //här startar jag loopen som inehåller hela spelet den säger att: när stringen room = end så tar spelet slut och stängs av
            while (room != "end")
            {
                //min första gamestate är när room = LivingRoom så kan man gå till olika platser via Livingroom
                while (room == "Puzzle1")
                {
                    //jag skriver ut roomdescriptionen från min array 
                    Console.WriteLine(roomdesc[0]);
                    //i de här två if satserna kollar jag vad användaren skriver och ger dig en output t.ex så får du inte göra eller byter rum baserat på vilka Collectibles du har(keycard)
                    inpt = Console.ReadLine().ToLower();
                    if (inpt == "go east")
                    {
                        Console.Clear();
                        Console.WriteLine("You went east into the Fightroom");
                        room = "FightRoom";
                        //efter varje sak som händer resettar jag "inpt" så att man inte fastnar i en infinite loop av misstag
                        inpt = "";
                    }
                       


                    

                }
                //alla mina gamestates ser likadana ut förutom att varje room leder till sina egna platser och jag kommer därför bara skriva om jag gör något speciellt vid de andra gamestatsen
                while (room == "FightRoom")
                {
                    Console.WriteLine(roomdesc[1]);
                    Console.WriteLine("Enter the name of your fighter, it has to be between 1 and 15 characters.");
                    while (true)
                    {
                        playerA = Console.ReadLine();
                        if (playerA.Length < 16 && playerA.Length > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The name needs to be between 1 and 15 letters");
                            Console.WriteLine("Try again");
                        }
                    }
                    int a = FightRoom(playerA);
                    if (a == 0)
                    {
                        Console.WriteLine("you lost F m8");
                    }
                    if (a == 1)
                    {
                        Console.WriteLine("Good job you won!");
                        truewin = true;
                        room = "Exit";
                    }
                    if (a == 2)
                    {
                        Console.WriteLine("you got a draw");
                        Console.WriteLine("I guess you won in some way so good job!");
                        room = "Exit";
                    }
                }

                

                //här är exit rummet som ger spelaren ett val att antingen fortsätta spela(starta om spelet med truewin av om man fick truewin) eller stänga av spelet, om man har truewin = true så får man ett speciellt meddelande när man stänger av
                while (room == "Exit")
                {
                    Console.Clear();
                    Console.WriteLine("Do you want to play again?");
                    Console.WriteLine("[Y]/[N]");
                    inpt = Console.ReadLine();
                    if (inpt == "N")
                    {
                        room = "end";
                    }
                    else if (inpt == "Y")
                    {
                        truewin = false;
                        room = "Puzzle1";
                        inpt = "";
                    }
                    else
                    {
                        Console.WriteLine("Sorry you can't do that, try something else");
                    }


                }

            }
            //det här är den delen av koden som ger truewin meddelandet när man stänger av i slutet men bara om man har låst upp truewin
            if (truewin == true)
            {
                Console.Clear();
                Console.WriteLine("You got the true ending of \"The Puzzle Fight-Room\"");
                Console.WriteLine("Good Job!");
                Console.ReadLine();
            }

        }

        static int FightRoom(string Name)
        {
            int nameB = 0;
            int hpA = 100;
            int hpB = 100;
            string playerA = Name;
            string playerB = "Ben Dover";
            int damage = 0;
            int round = 1;
            bool crit = false;
            Random rand = new Random();
            damage = rand.Next(101);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            Console.WriteLine("CHello it me game!");


            nameB = rand.Next(4);
            if (nameB == 2)
            {
                playerB = "BAUHOWD";
            }
            if (nameB == 3)
            {
                playerB = "BOIOOIOOIOIOOOIIIO";
            }
            Console.Clear();
            Console.WriteLine("In the red corner we have " + playerA);
            Console.WriteLine("And in the blue corner we have " + playerB);
            Console.WriteLine("Fight!");

            while (hpA > 0 && hpB > 0)
            {
                Console.WriteLine("ROUND " + round);
                round += 1;
                if (damage > 89)
                {
                    crit = true;
                    damage = rand.Next(101);
                }

                if (crit == true)
                {
                    damage *= 2;
                }
                Console.WriteLine(playerA + " attacks first");
                if (crit == true)
                {
                    Console.WriteLine("CRITICAL HIT!");
                    Console.WriteLine("Double damage!");
                }
                crit = false;
                Console.WriteLine(playerA + " hit " + playerB + " for " + damage + " damage!");
                hpB -= damage;
                Console.WriteLine(playerB + " has " + hpB + " hp left!");
                damage = rand.Next(101);
                if (damage > 90)
                {
                    crit = true;
                    damage = rand.Next(101);
                }
                if (crit == true)
                {
                    damage *= 2;
                }
                Console.WriteLine("Press ''ANY'' key to continue");
                Console.ReadKey();
                Console.WriteLine(playerB + " attacks last");
                if (crit == true)
                {
                    Console.WriteLine("CRITICAL HIT!");
                    Console.WriteLine("Double damage!");
                }
                crit = false;
                Console.WriteLine(playerB + " hit " + playerA + " for " + damage + " damage!");
                hpA -= damage;
                Console.WriteLine(playerA + " has " + hpA + " hp left!");
                damage = rand.Next(101);
                Console.WriteLine("Press ''ANY'' key to continue");
                Console.ReadKey();
                Console.Clear();
            }

            if (hpA > 0)
            {
                Console.WriteLine(playerA + " wins!");
                return 1;
            }
            if (hpB > 0)
            {
                Console.WriteLine(playerB + " wins!");
            }
            if (hpA < 0 && hpB < 0)
            {
                Console.WriteLine("Both " + playerA + " and " + playerB + " got knocked out");
                Console.WriteLine("IT'S A DRAW!");
                return 2;
            }
            Console.ReadKey();
            return 0;
        }
    }
}