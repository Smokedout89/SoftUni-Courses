using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public bool IsAlive { get; set; } = true;

        public double BaseHealth { get; }

        public double BaseArmor { get; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }


        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double Health
        {
            get
            {
                return health;
            } 
            set
            {
                health = value;

                if (health < 0)
                {
                    health = 0;
                    IsAlive = false;
                }

                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            private set
            {
                armor = value;

                if (armor < 0)
                {
                    armor = 0;
                }
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double pointsLeft = hitPoints - Armor > 0
                ? hitPoints - Armor
                : 0;

            Armor -= hitPoints;
            Health -= pointsLeft;
            IsAlive = Health > 0;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}