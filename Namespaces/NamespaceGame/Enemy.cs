using System;
using System.Collections.Generic;

namespace Enemy
{
    public class Enemy
    {
        private string EnemyName;
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
        }

        public void PrintEnemyStats()
        {
            System.Console.WriteLine($"---[{this.EnemyClass}] {this.EnemyName} [Lv.{this.EnemyLevel}]---\n");
            System.Console.WriteLine($"HitPoints".ToString().PadRight(9, ' ') + $": {this.EnemyHitPoints}");
            System.Console.WriteLine($"Strength".ToString().PadRight(9, ' ') + $": {this.EnemyStrength}");
            System.Console.WriteLine($"Agility".ToString().PadRight(9, ' ') + $": {this.EnemyAgility}");
            System.Console.WriteLine($"Dexterity".ToString().PadRight(9, ' ') + $": {this.EnemyDexterity}");
            System.Console.WriteLine($"Defense".ToString().PadRight(9, ' ') + $": {this.EnemyDefense}");
            System.Console.WriteLine($"Magic".ToString().PadRight(9, ' ') + $": {this.EnemyMagic}");
        }
    }
}