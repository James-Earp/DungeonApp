using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Fairy : Monster
    {
        //No feilds needed for this one
        public bool IsFairy { get; set; }

        public Fairy(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isFairy) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsFairy = isFairy;
        }
        public Fairy()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Lil Fairy Dude";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "Now Thats a fairy who doesnt have much!";
            IsFairy = false;
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsFairy)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}
