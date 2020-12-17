using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DUNGEON OF LIKE KINDA DOOM BUT MAYBE YOU WILL LIVE BUT MAYBE NOT, IT REALLY JUST DEPENDS";
            Console.WriteLine("OH MY GOD IM STUCK IN THIS DUNGEON WITH MONSTERS - THE STORY - THE GAME - THE SEQUAL!");
            Console.WriteLine("Your journey starts now...");
            //running total variable that will keep track of the score
            int score = 0;

            //TODO 1. Create a player - need to learn about custom classes
            //TODO 2. Create a weapon
            Weapon sword = new Weapon(1, 8, "Long Sword", 10, true);
            Weapon sword2 = new Weapon(1, 6, "Short Sword", 8, false);
            Weapon sword3 = new Weapon(1, 7, "Lolipop Sword", 9, true);
            Weapon sword4 = new Weapon(1, 6, "Peasant Sword", 7, false);
            Weapon scythe = new Weapon(4, 18, "Scythe of Death Grips", 12, true);
            Weapon scythe2 = new Weapon(7, 23, "Scythe of the Reaper", 18, true);
            Weapon scythe3 = new Weapon(2, 13, "Scythe of Homer Simpson", 10, true);
            Weapon scythe4 = new Weapon(5, 21, "Scythe of the Old World", 16, true);
            Weapon hammer = new Weapon(7, 20, "War Hammer", 14, true);
            Weapon hammer2 = new Weapon(10, 25, "Hammer of the Gods", 20, true);
            Weapon hammer3 = new Weapon(4, 8, "Carpenters Hammer", 9, false);
            Weapon hammer4 = new Weapon(9, 12, "Shattered War Hammer", 13, false);
            Weapon dagger = new Weapon(1, 4, "Dusty Dagger", 7, false);
            Weapon dagger2 = new Weapon(1, 20, "Lucky Dagger", 12, false);
            Weapon dagger3 = new Weapon(1, 5, "Lone Dagger", 8, false);
            Weapon dagger4 = new Weapon(1, 20, "Dagger of the Angry Egg", 15, false);

            Player p1 = new Player("Sir Egg", 70, 2, 40, 40, Race.VeryMadEgg, dagger4);

            //TODO 3. Create a loop for the room and monster
            bool exit = false;
            do
            {
                Console.WriteLine(GetRoom());
                Fairy f1 = new Fairy("Bloody Fairy", 25, 25, 20, 20, 4, 10, "That fairy is made of blood!", true);
                Fairy f2 = new Fairy();
                Vampire v1 = new Vampire("Count Chocula", 40, 40, 20, 20, 5, 15, "Hes a vampire and a cereal killer!", true);
                Vampire v2 = new Vampire();
                LegoMan lm1 = new LegoMan("Dave", 35, 35, 15, 15, 3, 10, "Hes made of Legos!", 20, 17);
                LegoMan lm2 = new LegoMan();
                LegoMan lm3 = new LegoMan("Gio", 50, 50, 50, 30, 20, 28, "Hes made of legos and spaghetti!", 20, 15);
                Monster[] monsters = { f1, f2, v1, v2, lm1, lm2, lm3 };

                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];
                //TODO 4. Create a menu of options
                bool reload = false;
                do
                {


                    #region Menu Loop

                    Console.WriteLine("\n\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n" +
                        "Score: {0}\n\n", score);

                    //TODO 5. Catch the user choice
                    //ReadKey(true) - keeps the key press from generating its corresponding character on the screen. .Key aligns the information to stored in the same datatype.
                    //ReadKey - static and key is the instance in a way.
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    //TODO 6. Clear the Console
                    Console.Clear();

                    //TODO 7. Build out the switch that determines what functionality the user wants.
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Player Attacks!");
                            //TODO 8. Handle the attack sequence
                            Combat.DoBattle(p1, monster);
                            //TODO 9. Handle if the player wins
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou defeated {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!");
                            //TODO 10. Monster gets a free attack
                            Console.WriteLine($"\n{monster.Name} attacks you as you run away!\n");
                            //TODO 11. Exit the inner loop and get a new monster/room
                            Combat.DoAttack(monster, p1);
                            reload = true;//exit the inner loop and get a new room for the monster
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info\n");
                            //TODO 12. Print out the player info
                            Console.WriteLine(p1);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info\n");
                            //TODO 13. Print out the monster info
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                            Console.WriteLine("Nobody liked you anyways. You are a mere peasant.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Thoust are really stupid. Read thyne text more carefully.");
                            break;
                    }
                    #endregion

                    //TODO 14. Check the players HP before continuing

                } while (!exit && !reload);


            } while (!exit);//exit the program

            //Tell the user the game has ended and give them their score
            //Ternary operator
            Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s."));

        }
        private static string GetRoom()
        {
            string[] rooms =
            {
            "The room is dark and musty with the smell of lost souls.",
            "You enter a pretty pink powder room and instantly get glitter on you.",
            "You arrive in a room filled with chairs and a ticket stub machine...DMV",
            "You enter a quiet library... silence... nothing but silence....",
            "As you enter the room, you realize you are standing on a platform surrounded by sharks",
            "Oh my.... what is that smell? You appear to be standing in a compost pile",
            "You enter a dark room and all you can hear is hair band music blaring.... This is going to be bad!",
            "Oh no.... the worst of them all... Oprah's bedroom....",
            "The room looks just like the room you are sitting in right now... or does it?",
            "The scent of earthy decay assaults your nose upon peering through the open door to this room. \nSmashed bookcases and their sundered contents litter the floor. \nPaper rots in mold-spotted heaps, and shattered wood grows white fungus.",
            "This hall is choked with corpses. \nThe bodies of orcs and ogres lie in tangled heaps where they died, and the floor is sticky with dried blood. \nIt looks like the orcs and ogres were fighting. Some side was the victor but you're not sure which one. \nThe bodies are largely stripped of valuables, but a few broken weapons jut from the slain or lie discarded on the floor.",
            "A chill crawls up your spine and out over your skin as you look upon this room. \nThe carvings on the wall are magnificent, a symphony in stonework -- but given the themes represented, it might be better described as a requiem. \nScenes of death, both violent and peaceful, appear on every wall framed by grinning skeletons and ghoulish forms in ragged cloaks.",
            "A wall that holds a seat with a hole in it is in this chamber. \nIt's a privy! The noisome stench from the hole leads you to believe that the privy sees regular use."
            };

            Random rand = new Random();
            //Since the maxValue is exclusive in the Next(), we can just call to the rooms.Length.
            int indexNbr = rand.Next(rooms.Length);
            string room = "****** NEW ROOM ******\n" +
                rooms[indexNbr] + "\n";

            return room;
        }//get room
    }

}
