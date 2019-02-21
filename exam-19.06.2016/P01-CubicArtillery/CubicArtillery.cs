namespace P01_CubicArtillery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicArtillery
    {
        public static void Main()
        {
            int bunkerCapacity = int.Parse(Console.ReadLine());
            int freeCapacity = bunkerCapacity;
            var bunkers = new Queue<string>();
            var weapons = new Queue<int>();

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "Bunker")
                {
                    break;
                }

                foreach (var element in input)
                {
                    if (char.IsLetter(element[0]))
                    {
                        bunkers.Enqueue(element);
                    }

                    else
                    {
                        int weaponCapacity = int.Parse(element);
                        bool findSpace = false;

                        while (bunkers.Count > 1)
                        {
                            if (freeCapacity >= weaponCapacity)
                            {
                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                                findSpace = true;
                                break;
                            }

                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> Empty");
                            }

                            else
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> {string.Join(", ", weapons)}");
                            }

                            bunkers.Dequeue();
                            weapons.Clear();
                            freeCapacity = bunkerCapacity;
                        }

                        if (!findSpace && bunkers.Count == 1)
                        {
                            if (bunkerCapacity >= weaponCapacity)
                            {
                                if (freeCapacity < weaponCapacity)
                                {
                                    while (freeCapacity < weaponCapacity)
                                    {
                                        int removedWeapon = weapons.Dequeue();
                                        freeCapacity += removedWeapon;
                                    }
                                }

                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                            }
                        }
                    }
                }
            }
        }
    }
}
