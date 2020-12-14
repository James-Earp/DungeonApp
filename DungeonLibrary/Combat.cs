using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This class will not have fields, props, or any custom constructors as it is just a warehouse for other methods.

        public static void DoAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(100);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcDamage()))
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!\n", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0} missed!\n", attacker.Name);
            }
        }

        public static void DoBattle(Player player, Monster monster)
        {
            //player Attack first
            DoAttack(player, monster);
            //If the monster is still alive it attacks back
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
