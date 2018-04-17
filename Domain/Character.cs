using System;
using System.Collections.Generic;
using Vue.Domain.Cards;
using Vue.Domain.Champions;

namespace Vue.Domain
{
    public abstract class Character
    {
        public Character()
        {
            Health = MaxHealth;
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public BasicUser User { get; set; }
        public abstract string Name { get; }
        public abstract int MaxHealth { get; }
        public int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract int Healing { get; }
        public abstract string Description { get; }

        public abstract void ApplyMove(List<Card> enemyCards, List<Card> friendlyCards, Champion enemyChampion, List<GameAction> actions);

        public Character Attack(Character character)
        {
            character.Health = character.Health - Damage;
            return character;
        }

        public List<Character> Attack(List<Card> characters)
        {
            var attackedCards = new List<Character>();
            foreach (var cardToAttack in characters)
            {
                attackedCards.Add(Attack(cardToAttack));
            }
            return attackedCards;
        }

        public Character Heal(Character character)
        {
            var healthAfter = character.Health + Healing;
            healthAfter = healthAfter > character.MaxHealth ? character.MaxHealth : healthAfter;
            character.Health = healthAfter;
            return character;
        }
    }
}