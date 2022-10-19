using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> characters;
        private readonly List<Item> items;

        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = null;

            if (characterType == nameof(Warrior))
            {
                character = new Warrior(name);
            }
            else if (characterType == nameof(Priest))
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            characters.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = null;

            if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            items.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = characters.FirstOrDefault(n => n.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = items.LastOrDefault();
            items.Remove(item);
            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = characters.FirstOrDefault(n => n.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters
                         .OrderByDescending(a => a.IsAlive)
                         .ThenByDescending(h => h.Health))
            {
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health,
                    character.BaseHealth, character.Armor, character.BaseArmor, character.IsAlive ? "Alive" : "Dead"));
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = characters.FirstOrDefault(n => n.Name == attackerName);
            Character receiver = characters.FirstOrDefault(n => n.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (!(attacker is IAttacker))
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, attacker.Name);
            }

            ((IAttacker)attacker).Attack(receiver);

            string result = string.Format(SuccessMessages.AttackCharacter, attacker.Name, receiver.Name,
                attacker.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor,
                receiver.BaseArmor);

            if (!receiver.IsAlive)
            {
                result += Environment.NewLine + string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name);
            }

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healReceiverName = args[1];

            Character healer = characters.FirstOrDefault(n => n.Name == healerName);
            Character healReceiver = characters.FirstOrDefault(n => n.Name == healReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (healReceiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healReceiverName));
            }

            if (!(healer is IHealer))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }

            ((IHealer)healer).Heal(healReceiver);

            return string.Format(SuccessMessages.HealCharacter, healer.Name, healReceiver.Name,
                healer.AbilityPoints, healReceiver.Name, healReceiver.Health);
        }
    }
}
