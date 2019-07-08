using System;

namespace Dojodachi.Resources
{
    public class Domogachi
    {

        private Random rng = new Random();

        public int Fullness { get; set; }
        public int Happiness { get; set; }
        public int Meals { get; set; }
        public int Energy { get; set; }

        public bool IsWin
        {
            get
            {
                return Fullness > 100 && Happiness > 100 && Energy > 100;
            }
        }

        public bool IsAlive
        {
            get
            {
                return Fullness > 0 && Happiness > 0;
            }
        }

        public Domogachi()
        {
            this.Fullness = 20;
            this.Happiness = 20;
            this.Meals = 3;
            this.Energy = 50;
        }

        public Domogachi(int fullness, int happiness, int meals, int energy)
        {
            this.Fullness = fullness;
            this.Happiness = happiness;
            this.Meals = meals;
            this.Energy = energy;
        }

        public string Eat()
        {
            if (this.Meals > 0)
            {
                this.Meals--;

                if (this.rng.Next(4) > 0)
                {
                    var f = this.rng.Next(5, 11);
                    this.Fullness += f;

                    return $"Dojodachi ate a meal. Fullness +{f}";
                }
                else
                {
                    return $"Dojodachi vomitted :(";
                }
            }
            else
            {
                return "Dojodachi doesn't have any meals to eat.";
            }
        }

        public string Play()
        {
            if (this.Energy >= 5)
            {
                this.Energy -= 5;

                if (this.rng.Next(4) > 0)
                {
                    var hap = this.rng.Next(5, 11);
                    this.Happiness += hap;

                    return $"You played with Dojodachi! Happiness +{hap}, Energy: -5";
                }
                else
                {
                    return "Dojodachi doesn't want to play";
                }
            }
            else
            {
                return "Dojodachi doesn't have enough energy to play...";
            }
        }

        public string Work()
        {
            if (this.Energy >= 5)
            {
                this.Energy -= 5;

                var meals = this.rng.Next(1, 4);
                this.Meals += meals;

                return $"Dojodachi worked hard and earned {meals} meals";
            }
            else
            {
                return "Dojodachi doesn't have enough energy to work... @_@";
            }
        }

        public string Sleep()
        {
            this.Energy += 15;
            this.Fullness -= 5;
            this.Happiness -= 5;

            return "Dojodachi slept well. Energy +15, Fullness -5, Happiness -5";
        }

        public override string ToString()
        {
            return $"Fullness: {this.Fullness}, Happiness: {this.Happiness}, Meals: {this.Meals}, Energy: {this.Energy}";
        }
    }
}