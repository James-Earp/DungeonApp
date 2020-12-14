using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class LegoMan : Monster
    {
        public int BonusBlock { get; set; }
        public int HidePercent { get; set; }
        public LegoMan(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, int bonusBlock, int hidePercent) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            BonusBlock = bonusBlock;
            HidePercent = hidePercent;
        }
        public LegoMan()
        {
            MaxLife = 20;
            MaxDamage = 13;
            Name = "Lego The Man";
            Life = 20;
            HitChance = 10;
            Block = 20;
            MinDamage = 1;
            Description = "AHHHHHHH KILL IT!";
            BonusBlock = 5;
            HidePercent = 10;

        }
        public override string ToString()
        {
            return string.Format("{0}\nChance he'll hide: {1}% and then he has a bonus block of {2}", base.ToString(), HidePercent, BonusBlock);
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            Random rand = new Random();
            int percent = rand.Next(101);
            if (percent <= HidePercent)
            {
                calculatedBlock += BonusBlock;
            }

            return calculatedBlock;
        }
    }
}
