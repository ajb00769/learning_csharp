using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Player
{
    public class Player
    {
        // Declaration of Constants
        private const int StatLimit = 99;
        private const int LevelUpStatPoints = 5;
        private const int MaxPlayerLevel = 100;
        private const long MaxExpAmount = 10000000000000; // 10 trillion

        // Declaration of Strings
        public string PlayerName;
        private string PlayerClass;

        // Declaration of Booleans
        private bool IsAlive;

        // Declaration of stats
        private int PlayerLevel;
        private int HitPoints;
        private int Strength;
        private int Agility;
        private int Dexterity;
        private int Defense;
        private int Magic;
        private long CurrentExp; // private long ExpLevelUp = ((PlayerLevel ^ 9) / 2) + 100;
        public int UnallocatedStats;

        private int HP;
        private int PDMG;
        private int MDMG;

        // Declaration of Lists and mapping
        private List<KeyValuePair<string, int>> StatMap;
        public List<KeyValuePair<char, string>> ClassMap = new() {
            new KeyValuePair<char, string> ('W', "Warrior"),
            new KeyValuePair<char, string> ('A', "Archer"),
            new KeyValuePair<char, string> ('R', "Rogue"),
            new KeyValuePair<char, string> ('M', "Mage"),
        };

        // Constructors
        public Player(string playerName)
        {
            this.PlayerName = playerName;
            this.PlayerClass = "Adventurer";
            this.IsAlive = true;
            this.PlayerLevel = 1;
            this.HitPoints = 10;
            this.Strength = 1;
            this.Agility = 1;
            this.Dexterity = 1;
            this.Defense = 1;
            this.Magic = 1;
            this.UnallocatedStats = 0;
            this.CurrentExp = 0;

            this.StatMap = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int> ("HitPoints",this.HitPoints),
                new KeyValuePair<string, int> ("Strength",this.Strength),
                new KeyValuePair<string, int> ("Agility",this.Agility),
                new KeyValuePair<string, int> ("Dexterity",this.Dexterity),
                new KeyValuePair<string, int> ("Defense",this.Defense),
                new KeyValuePair<string, int> ("Magic",this.Magic),
            };

            this.PDMG = this.Strength;
            this.MDMG = this.Magic;
            this.HP = this.HitPoints;
        }

        // Methods
        public void PrintPlayerStats()
        {
            string StatHeader = $"---{this.PlayerName}'s Stats---";
            System.Console.WriteLine($"\n{StatHeader}\n");
            System.Console.WriteLine($"{"LEVEL".PadRight(9, ' ')}" + $": {this.PlayerLevel}");
            System.Console.WriteLine($"{"Class".PadRight(9, ' ')}" + $": {this.PlayerClass}\n");
            foreach (var stat in this.StatMap)
            {
                System.Console.WriteLine($"{stat.Key.ToString().PadRight(9, ' ')}: {stat.Value}");
            }
            System.Console.WriteLine($"\nStat Pts : {this.UnallocatedStats}");
            System.Console.WriteLine($"".PadRight(StatHeader.Count(), '-'));
        }

        public void UpdateStats(string statName, int statAmount)
        {
            if (statAmount > this.UnallocatedStats || statAmount == 0)
            {
                System.Console.WriteLine("\n[ERROR] Invalid amount of stats to allocate.");
                return;
            }

            switch (statName)
            {
                case "HitPoints":
                    this.HitPoints += statAmount;
                    break;
                case "Strength":
                    this.Strength += statAmount;
                    break;
                case "Agility":
                    this.Agility += statAmount;
                    break;
                case "Dexterity":
                    this.Dexterity += statAmount;
                    break;
                case "Defense":
                    this.Defense += statAmount;
                    break;
                case "Magic":
                    this.Magic += statAmount;
                    break;
                default:
                    throw new Exception("[ERROR] Stat name not valid.");
            }

            this.UnallocatedStats -= statAmount;
            System.Console.WriteLine($"\nSuccessfully allocated {statAmount} stat points to '{statName}'.");
        }

        public void SetPlayerClass(string playerClass)
        {
            if (this.ClassMap.Find(item => item.Value == playerClass).Value == playerClass)
            {
                this.PlayerClass = playerClass;
                return;
            }
            else
            {
                throw new ArgumentException("[ERROR] Argument passed into SetPayerFunction does not match available choices in 'ClassMap' variable.");
            }
        }

        public int DeductHP(int hpAmount)
        {
            this.HP -= hpAmount;
            if (this.HP <= 0)
            {
                IsAlive = false;
            }
            return this.HP;
        }

        public int GetAgility() { return this.Agility; }

        public int GetPDMG() { return this.PDMG; }

        public int GetMDMG() { return this.MDMG; }

        public string GetPlayerClass() { return this.PlayerClass; }

        public bool GetIsAlive() { return this.IsAlive; }

        public int GetHP() { return this.HP; }
    }

}