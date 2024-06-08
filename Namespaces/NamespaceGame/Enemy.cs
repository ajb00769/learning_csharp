using System;
using System.Collections.Generic;

namespace Enemy
{
    public class Enemy
    {
        public string EnemyName;
        private string EnemyClass;
        private int EnemyLevel;
        private int EnemyTier;
        private int EnemyHitPoints;
        private int EnemyStrength;
        private int EnemyAgility;
        private int EnemyDexterity;
        private int EnemyDefense;
        private int EnemyMagic;
        private bool IsAlive;
        private long ExpYield;

        private int EnemyHP;
        private int EnemyPDMG;
        private int EnemyMDMG;

        private List<KeyValuePair<string, int>> EnemyStatMap;

        public Enemy(string enemyName, string enemyClass, int enemyLevel, int enemyTier)
        {
            this.EnemyName = enemyName;
            this.EnemyClass = enemyClass;
            this.EnemyLevel = enemyLevel;
            this.EnemyTier = enemyTier;
            this.EnemyHitPoints = 10;
            this.EnemyStrength = 1;
            this.EnemyAgility = 1;
            this.EnemyDexterity = 1;
            this.EnemyDefense = 1;
            this.EnemyMagic = 1;
            this.IsAlive = true;
            this.ExpYield = (this.EnemyLevel ^ this.EnemyTier) * 10;

            int StatsToAllocate = this.EnemyLevel * 6;

            if (this.EnemyClass == "Melee")
            {
                this.EnemyHitPoints += (int)Math.Ceiling(StatsToAllocate * 0.2);
                this.EnemyStrength += (int)Math.Ceiling(StatsToAllocate * 0.3);
                this.EnemyDexterity += (int)Math.Ceiling(StatsToAllocate * 0.2);
                this.EnemyDefense += (int)Math.Ceiling(StatsToAllocate * 0.3);
            }
            else if (this.EnemyClass == "Mage")
            {
                this.EnemyHitPoints += (int)Math.Ceiling(StatsToAllocate * 0.1);
                this.EnemyMagic += (int)Math.Ceiling(StatsToAllocate * 0.5);
                this.EnemyDexterity += (int)Math.Ceiling(StatsToAllocate * 0.2);
                this.EnemyAgility += (int)Math.Ceiling(StatsToAllocate * 0.2);
            }
            else if (this.EnemyClass == "Archer")
            {
                this.EnemyHitPoints += (int)Math.Ceiling(StatsToAllocate * 0.1);
                this.EnemyStrength += (int)Math.Ceiling(StatsToAllocate * 0.3);
                this.EnemyDexterity += (int)Math.Ceiling(StatsToAllocate * 0.3);
                this.EnemyAgility += (int)Math.Ceiling(StatsToAllocate * 0.3);
            }
            else
            {
                throw new Exception("[ERROR] Attempted to create invalid enemy class. Please create either 'Melee', 'Mage', or 'Archer'.");
            }

            if (this.EnemyTier > 5)
            {
                throw new Exception("[ERROR] Enemy tier cannot be higher than 5.");
            }
            else
            {
                this.EnemyHitPoints *= this.EnemyTier;
                this.EnemyStrength *= this.EnemyTier;
                this.EnemyAgility *= this.EnemyTier;
                this.EnemyDexterity *= this.EnemyTier;
                this.EnemyDefense *= this.EnemyTier;
                this.EnemyMagic *= this.EnemyTier;
            }

            this.EnemyStatMap = new()
            {
                new KeyValuePair<string, int> ("HitPoints", this.EnemyHitPoints),
                new KeyValuePair<string, int> ("Strength", this.EnemyStrength),
                new KeyValuePair<string, int> ("Agility", this.EnemyAgility),
                new KeyValuePair<string, int> ("Dexterity", this.EnemyDexterity),
                new KeyValuePair<string, int> ("Defense", this.EnemyDefense),
                new KeyValuePair<string, int> ("Magic", this.EnemyMagic),
            };

            this.EnemyPDMG = this.EnemyStrength;
            this.EnemyMDMG = this.EnemyMagic;
            this.EnemyHP = this.EnemyHitPoints;
        }

        public void PrintEnemyStats()
        {
            string EnemyHeader = $"---[{this.EnemyClass}] {this.EnemyName} [Lv.{this.EnemyLevel}]---\n";
            int TextWidth = EnemyHeader.Count();

            System.Console.WriteLine(EnemyHeader);
            foreach (var item in this.EnemyStatMap)
            {
                System.Console.WriteLine($"{item.Key}".ToString().PadRight(9, ' ') + $": {item.Value}");
            }
            System.Console.WriteLine("\n".PadRight(TextWidth, '-'));
        }

        public int DeductEnemyHP(int hpAmount)
        {
            this.EnemyHP -= hpAmount;
            if (this.EnemyHP <= 0)
            {
                IsAlive = false;
            }
            return this.EnemyHP;
        }

        public int GetAgility() { return this.EnemyAgility; }

        public int GetPDMG() { return this.EnemyPDMG; }

        public int GetMDMG() { return this.EnemyMDMG; }

        public string GetEnemyClass() { return this.EnemyClass; }

        public bool GetIsAlive() { return this.IsAlive; }

        public int GetEnemyHP() { return this.EnemyHP; }
    }
}