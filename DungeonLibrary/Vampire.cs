using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Vampire : Monster
    {
        public bool IsVampy { get; set; }

        public Vampire(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isVampy) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsVampy = isVampy;
        }
        public Vampire()
        {
            MaxLife = 10;
            MaxDamage = 5;
            Name = "Suggit Vampire";
            Life = 10;
            HitChance = 30;
            Block = 22;
            MinDamage = 1;
            Description = "Just a stupid Suggit Vamp, probably worth killing.";
            IsVampy = false;
        }
        public override string ToString()
        {
            return base.ToString() + (IsVampy ? "Those are long fangs" : "Those are tiny fangs");
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsVampy)
            {
                calculatedBlock += calculatedBlock / 4;
            }

            return calculatedBlock;
        }
    }
}
