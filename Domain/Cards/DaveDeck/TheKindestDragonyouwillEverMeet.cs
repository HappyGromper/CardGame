using System;
using System.Collections.Generic;
using System.Linq;
using Vue.Domain.Champions;

namespace Vue.Domain.Cards
{
    public class TheKindestDragonyouwillEverMeet : Card

    {
        public override string Name => "The Kindest Dragon you will Ever Meet";

        public override Row Row => Row.Front;

        public override Row Targets => Row.Both;

        public override Rarity Rarity => Rarity.Legendary;

        public override int Speed => 3;

        public override int Damage {get;set;} = 1;
        public override int Healing => 0;

        public override string Description => "Goop";
        public override int MaxHealth => 12;

        public override void ApplyMove(List<Card> enemyCards, List<Card> friendlyCards, Champion enemyChamp, List<GameAction> actions)
        {
            var cardsToAttack = TargetedCards(enemyCards);

            if (cardsToAttack.Any())
            {
                var rand = new Random();
                var index = rand.Next(cardsToAttack.Count);                
                var first = cardsToAttack[index];
                first.Health = first.Health - Damage;            
                actions.Add(new GameAction(this, new List<Character> { first }, null));
            }
            else
            {
                Attack(enemyChamp);
                actions.Add(new GameAction(this, new List<Character> { enemyChamp }, null));
            }
        }
    }
}