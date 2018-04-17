using System;
using System.Collections.Generic;
using System.Linq;
using Vue.Domain.Champions;

namespace Vue.Domain.Cards
{
    public class HansGump: Card

    {
        public override string Name => "Hans Gump";

        public override Row Row => Row.Back;

        public override Row Targets => Row.Front;

        public override Rarity Rarity => Rarity.Uncommon;

        public override int Speed => 3;

        public override int Damage {get;set;} = 2;
        public override int Healing => 0;

        public override string Description => "";

        public override int MaxHealth => 8;

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