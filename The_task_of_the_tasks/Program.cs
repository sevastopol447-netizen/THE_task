using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_task_of_the_tasks
{
    internal class Program
    {
        class MessageHelper
        {
            public static string GetString(string message)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    throw new FormatException("Input cannot be empty!");

                return input;
            }

            public static int GetInt(string message)
            {
                if (!int.TryParse(GetString(message), out int num))
                    throw new FormatException("Failed to parse input!");
                return num;
            }

            public static float GetFloat(string message)
            {
                if (!float.TryParse(GetString(message), out float num))
                    throw new FormatException("Failed to parse input!");

                return num;
            }

            public static bool GetBoolean(string message)
            {
                switch (GetString(message + "(Y/n)").ToLower()[0])
                {
                    case 'y': return true;
                    case 'n': return false;
                    default: throw new Exception("Input cannot be empty!");
                }
            }
        }

        class Player
        {
            public string name;
            public int activeWeapon;
            public List<Weapon> weapons;
            public List<double> magazines;

            public Player (string name, List<Weapon> weapons,  List<double> magazines)
            {
                this.name = name;
                this.activeWeapon = 1;
                this.weapons = weapons;
                this.magazines = magazines;
            }

            public void chooseWeapon(int id)
            {
                activeWeapon = id;
            }
            public void nextWeapon()
            {
                if (activeWeapon != 4)
                {
                    activeWeapon++;
                }
                else
                {
                    activeWeapon = 1;
                }
            }
            public void reload(Weapon Weapon) {
                if (magazines.Remove(Weapon.caliber)){
                    Weapon.magazineSlot = true;
                }
                else
                {
                    Console.WriteLine("No right magasine");
                }
            }

        }

        class Weapon
        {
            public int id;
            public int autoinc = 0;
            public string name;
            public double caliber;
            public bool magazineSlot;

            public Weapon(string name, double caliber)
            {
                this.id = autoinc++;
                this.name = name;
                this.caliber = caliber;
                this.magazineSlot = false;
            }
        }

        class Magazine
        {
            public int id;
            public int autoinc;
            public double caliber;

            public Magazine(double caliber)
            {
                this.id = autoinc++;
                this.caliber = caliber;
            }
        }
    }
}
