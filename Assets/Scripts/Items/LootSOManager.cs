using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    [CreateAssetMenu]
    public class LootSOManager : ScriptableObject
    {
        public Sprite lootSprite;
        public string lootName;
        public int dropChance;
        public int amountDropped;


        public LootSOManager(string lootName, int dropChance, int amountDropped)
        {
            this.lootName = lootName;
            this.dropChance = dropChance;
            this.amountDropped = amountDropped;
        }

    }
}
