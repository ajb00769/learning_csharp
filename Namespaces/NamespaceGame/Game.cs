using System;
using Player;
using Enemy;
using System.Runtime.InteropServices;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Linq;
using System.Threading;
using TextEffects;

namespace Game
{
    public class Game
    {
        private bool GameOver = false;

        public Game()
        { }

        public void StartGame()
        {
            while (!this.GameOver)
            {
                TypeWriter TypewriteText = new TypeWriter();

                System.Console.Clear();
                System.Console.WriteLine("Welcome to Allen's Text RPG!");
                Thread.Sleep(750);
                Player.Player NewPlayer = CreatePlayer();
                System.Console.Clear();

                // string WelcomeMessage = $"Greetings {NewPlayer.PlayerName}!\n\nWelcome to the world of Lunaria. A land of fantasy sprawling with magic, adventure, treasure, and dragons!\n\nYou, {NewPlayer.PlayerName}, are an adventurer who will decide on what adventure you will take. Kill monsters, find or craft gear, level up, and more!\n\nTry to get as much swag as you can and have as much fun as possible!\n\nI'm really bad at writing a story!";
                // TypewriteText.TypeWriteText(WelcomeMessage);
                // WaitAndContinue();
                // System.Console.Clear();

                System.Console.WriteLine("Here are your stats:");
                Thread.Sleep(250);
                NewPlayer.PrintPlayerStats();
                Thread.Sleep(250);
                // string StatExplanation = $"\nTo give you a brief explanation of how your stats work:\n\nHITPOINTS will allow you to take incoming damage, your final HP value will be calculated as (HITPOINTS Stat * 10) * (1 + Gear HP%) + Flat Gear HP. So if you have 10 HitPoints stat and your gear has +25% HP and +100 HP your final HP value will be 10 * 10 = 100 * 1.25 = 125 + 100 = 225 HP.\n\nSTRENGTH will allow you to increase your physical damage inflicted, your final PDMG value will be calculated as (STRENGTH Stat * 10) * (1 + Gear PDMG%) + Flat Gear PDMG value.\n\nAGILITY determines your Attack Speed for both Phyiscal and Magical attacks, the higher your agility the more you can outspeed the opponent. It also possible to move twice or more before your opponent can have their turn if your agility level is high enough.\n\nDEXTERITY determines your accuracy for both Physical and Magical attacks, the higher your dexterity the less likely it is for your opponent to dodge your attacks.\n\nDEFENSE lowers the damage of incoming enemy Physical attacks. This stat also affects incoming Magical attacks but only at 25% efficacy.\n\nMAGIC allows you to increase your magical damage inflicted, your final MDMG value iwll be calculated as (MAGIC Stat * 10) * (1 + Gear MDMG%) + Flat Gear MDMG value. Your MANA value also comes from here calculated as (MAGIC Stat * 10) * (1 + Gear MANA%) + Flat Gear MANA value. This stat also helps reduce incoming Magical Damage.\n";
                // TypewriteText.TypeWriteText(StatExplanation);
                // WaitAndContinue();
                // System.Console.Clear();

                TypewriteText.TypeWriteText("Let's now fight your first ever opponent!");
                WaitAndContinue();
                System.Console.Clear();

                System.Console.WriteLine("A new enemy appeared!\n");
                Enemy.Enemy FirstEnemy = new Enemy.Enemy("Goblin", "Melee", 1, 1);
                FirstEnemy.PrintEnemyStats();

                while (NewPlayer.GetIsAlive() || FirstEnemy.GetIsAlive())
                {
                    char UserChoice = CombatInterface();
                    System.Console.WriteLine(this.GameOver);
                    System.Console.Clear();
                    PerformCombat(UserChoice, NewPlayer, FirstEnemy);
                    if (UserChoice == '4') { break; }
                    if (!NewPlayer.GetIsAlive() || !FirstEnemy.GetIsAlive())
                    {
                        this.GameOver = true;
                        break;
                    }
                }

                if (this.GameOver)
                {
                    System.Console.WriteLine("Game Over!");
                    break;
                }
            }
        }

        public Player.Player CreatePlayer()
        {
            bool ConfirmName = false;
            string PlayerName = "";

            while (!ConfirmName)
            {
                System.Console.Write("Please enter your name: ");
                string? TempPlayerName = Console.ReadLine();

                if (string.IsNullOrEmpty(TempPlayerName) || TempPlayerName.All(char.IsWhiteSpace))
                {
                    System.Console.WriteLine("[INFO] Name cannot be empty string. Please try again.");
                    continue;
                }

                System.Console.WriteLine($"Do you want to name yourself as '{TempPlayerName}'? [y\\N]");

                while (true)
                {
                    var KeyPressed = Console.ReadKey(true).Key;
                    if (KeyPressed == ConsoleKey.Y)
                    {
                        PlayerName = TempPlayerName;
                        ConfirmName = true;
                        break;
                    }
                    else if (KeyPressed == ConsoleKey.N)
                    {
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine($"[ERROR] Key {KeyPressed} not a valid option.");
                        continue;
                    }
                }
            }
            return new Player.Player(PlayerName);
        }

        public void SelectInitialClass(Player.Player playerObject)
        {
            bool ClassConfirmed = false;

            while (!ClassConfirmed)
            {
                System.Console.WriteLine("Choose a job by pressing the job's first letter:");

                foreach (var playerClass in playerObject.ClassMap)
                {
                    System.Console.WriteLine(playerClass.Value);
                }

                var KeyPressed = Console.ReadKey(true).KeyChar;
                var MappingCheck = playerObject.ClassMap.Find(item => item.Key == Char.ToUpper(KeyPressed));

                if (MappingCheck.Key != Char.ToUpper(KeyPressed))
                {
                    System.Console.WriteLine("Not a valid player class. Try again.");
                    continue;
                }
                else
                {
                    playerObject.SetPlayerClass(playerObject.ClassMap.Find(item => item.Key == Char.ToUpper(KeyPressed)).Value);
                    ClassConfirmed = true;
                }
            }
        }

        private void WaitAndContinue()
        {
            Thread.Sleep(1000);
            System.Console.WriteLine("\nPress the 'Spacebar' to continue...");

            while (true)
            {
                char SpacebarPressed = Console.ReadKey(true).KeyChar;
                if (SpacebarPressed == ' ')
                {
                    return;
                }
            }
        }

        private char CombatInterface()
        {
            char[] ValidKeyPresses = { '1', '2', '3', '4' };

            System.Console.WriteLine("Press [1] to Attack, [2] to Defend, [3] to show Stats, [4] to Run Away.");

            while (true)
            {
                char KeyPressed = Console.ReadKey(true).KeyChar;

                if (ValidKeyPresses.Contains(KeyPressed))
                {
                    return KeyPressed;
                }
            }
        }

        private void PerformCombat(char combatChoice, Player.Player playerObj, Enemy.Enemy enemyObj)
        {
            string playerClass = playerObj.GetPlayerClass();
            string enemyClass = enemyObj.GetEnemyClass();
            int PlayerAgility = playerObj.GetAgility();
            int EnemyAgility = enemyObj.GetAgility();
            int PlayerDMG;
            int EnemyDMG;
            bool FirstMover = PlayerAgility > EnemyAgility;

            if (playerClass != "Mage")
            {
                PlayerDMG = playerObj.GetPDMG();
            }
            else
            {
                PlayerDMG = playerObj.GetMDMG();
            }

            if (enemyObj.GetEnemyClass() != "Mage")
            {
                EnemyDMG = enemyObj.GetPDMG();
            }
            else
            {
                EnemyDMG = enemyObj.GetMDMG();
            }

            switch (combatChoice)
            {
                case '1':
                    if (FirstMover)
                    {
                        enemyObj.DeductEnemyHP(PlayerDMG);
                        System.Console.WriteLine($"You attack {enemyObj.EnemyName} and they suffered {PlayerDMG}, remaining HP: {enemyObj.GetEnemyHP()}");
                        if (!enemyObj.GetIsAlive())
                        {
                            System.Console.WriteLine($"{enemyObj.EnemyName} has died!");
                            return;
                        }
                        playerObj.DeductHP(EnemyDMG);
                        System.Console.WriteLine($"{enemyObj.EnemyName} attacks {playerObj.PlayerName} and suffers {EnemyDMG}, remaining HP: {playerObj.GetHP()}");
                        return;
                    }
                    playerObj.DeductHP(EnemyDMG);
                    System.Console.WriteLine($"{enemyObj.EnemyName} attacks {playerObj.PlayerName} suffers {EnemyDMG}, remaining HP: {playerObj.GetHP()}");
                    if (!playerObj.GetIsAlive())
                    {
                        System.Console.WriteLine($"{playerObj.PlayerName} has died!");
                        return;
                    }
                    enemyObj.DeductEnemyHP(PlayerDMG);
                    System.Console.WriteLine($"You attack {enemyObj.EnemyName} and they suffered {PlayerDMG}, remaining HP: {enemyObj.GetEnemyHP()}");
                    return;
                case '2':
                    System.Console.WriteLine("You defend against the opponents attack.");
                    playerObj.DeductHP(EnemyDMG / 2);
                    System.Console.WriteLine($"{enemyObj.EnemyName} attacks {playerObj.PlayerName} suffers {EnemyDMG / 2}, remaining HP: {playerObj.GetHP()}");
                    return;
                case '3':
                    playerObj.PrintPlayerStats();
                    enemyObj.PrintEnemyStats();
                    return;
                case '4':
                    this.GameOver = true;
                    return;
                default:
                    System.Console.WriteLine("Something went wrong.");
                    return;
            }
        }
    }
}