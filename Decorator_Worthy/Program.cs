using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Worthy
{
    internal class Program
    {
        public abstract class Professsion
        {
            public string Name { get; set; }
            public int Attack { get; set; }
            public int Speed { get; set; }
            public int Health { get; set; }
            public int Protection { get; set; }
            public abstract string Operation();
            public string ToString()
            {
                return $"Название профессии: {Name}\nАтака: {Attack}\nСкорость: {Speed}\nЗдоровье: {Health}\nЗащита: {Protection}";
            }
        }
        class Human : Professsion
        {

            public override string Operation()
            {
                Name = "Человек";
                Attack += 20;
                Speed += 20;
                Health += 150;
                Protection += 0;
                return ToString();
            }
        }
        class Elf : Professsion
        {
            public override string Operation()
            {
                Name = "Ельф";
                Attack += 15;
                Speed += 30;
                Health += 100;
                Protection += 0;
                return ToString();
            }
        }
        abstract class Decorator : Professsion
        {
            protected Professsion _Professsion;

            public Decorator(Professsion Professsion)
            {
                _Professsion = Professsion;
            }

            public void SetProfesssion(Professsion Professsion)
            {
                _Professsion = Professsion;
            }
            public override string Operation()
            {

                if (_Professsion != null)
                {
                    return ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        class ManWarrior : Human
        {
            public ManWarrior(Human comp)
            {
                Name = "Человек воин";
                Attack += 20;
                Speed = comp.Speed+10;
                Health = comp.Health + 50;
                Protection = comp.Protection + 20;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Swordsman : Human
        {
            public Swordsman(ManWarrior comp) 
            {
                Name = "Меченосец";
                Attack = comp.Attack + 40;
                Speed =comp.Speed - 10;
                Health = comp.Health + 50;
                Protection = comp.Protection + 40;
            }

            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Archer : Human
        {
            public Archer(ManWarrior comp) 
            {
                Name = "Лучник";
                Attack = comp.Attack + 20;
                Speed = comp.Speed + 20;
                Health = comp.Health + 50;
                Protection = comp.Protection + 10;
            }

            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class  Rider: Human
        {
            public Rider(Swordsman comp) 
            {
                Name = "Всадник";
                Attack = comp.Attack - 10;
                Speed = comp.Speed + 40;
                Health = comp.Health + 200;
                Protection = comp.Protection + 100;
            }

            public override string Operation()
            {
                return $"{ToString()}";
            }
        }

        class ElfWarrior: Elf
        {
            public ElfWarrior(Elf comp)
            {
                Name = "Эльф воин";
                Attack =comp.Attack + 20;
                Speed = comp.Speed - 10;
                Health = comp.Health + 100;
                Protection = comp.Protection + 20;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class ElfMage : Elf
        {
            public ElfMage(Elf comp)
            {
                Name = "Эльф маг";
                Attack = comp.Attack + 10;
                Speed = comp.Speed + 10;
                Health = comp.Health - 50;
                Protection = comp.Protection + 10;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Crossbowman : Elf
        {
            public Crossbowman(ElfWarrior comp)
            {
                Name = "Арбалетчик";
                Attack = comp.Attack + 20;
                Speed = comp.Speed + 10;
                Health = comp.Health + 50;
                Protection = comp.Protection - 10;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class EvilMage : Elf
        {
            public EvilMage(ElfMage comp)
            {
                Name = "Злой маг";
                Attack = comp.Attack + 70;
                Speed = comp.Speed + 20;
                Health = comp.Health + 0;
                Protection = comp.Protection + 0;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class KindMage : Elf
        {
            public KindMage(ElfMage comp)
            {
                Name = "Добрый маг";
                Attack = comp.Attack + 50;
                Speed = comp.Speed + 30;
                Health = comp.Health + 100;
                Protection = comp.Protection + 30;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        public class Client
        {
            public void ClientCode(Professsion Professsion)
            {
                Console.WriteLine(Professsion.Operation());
            }
        }
        static void Main(string[] args)
        {
            Client client = new Client();

            Human human = new Human();
            client.ClientCode(human);

            ManWarrior warrior = new ManWarrior(human);
            client.ClientCode(warrior);

            Swordsman swordsman = new Swordsman(warrior);
            client.ClientCode(swordsman);

            Rider rider = new Rider(swordsman);
            client.ClientCode(rider);
            ///
   
            Elf elf = new Elf();
            client.ClientCode(elf);

            ElfWarrior warrior1 = new ElfWarrior(elf);
            client.ClientCode(warrior1);

            ElfMage mage = new ElfMage(elf);
            client.ClientCode(mage);

            Crossbowman crossbowman = new Crossbowman(warrior1);
            client.ClientCode(crossbowman);

            EvilMage evil = new EvilMage(mage);
            client.ClientCode(evil);

            KindMage kind = new KindMage(mage);
            client.ClientCode(kind);
        }
    }
}
