using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class LootBagManager : MonoBehaviour
    {
        public GameObject droppedItemPrefab;
        public List<LootSOManager> lootList = new List<LootSOManager>();

        private List<LootSOManager> GetDroppedItems()
        {
            int randomNumber = Random.Range(1, 101);
            List<LootSOManager> possibleItems = new List<LootSOManager>();
            foreach (LootSOManager item in lootList)
            {
                if (randomNumber <= item.dropChance)
                {
                    possibleItems.Add(item);
                }
            }

            if (possibleItems.Count > 0)
            {
                // drops a random item, modify to drop multiple items if wanted
                List<LootSOManager> droppedItems = new List<LootSOManager>();
                droppedItems.Add(possibleItems[Random.Range(0, possibleItems.Count)]);

                return droppedItems;
            }

            return null;
        }

        public void InstantiateLoot(Vector3 spawnPosition)
        {
            List<LootSOManager> droppedItems = GetDroppedItems();

            if (droppedItems != null)
            {
                foreach (LootSOManager dropItem in droppedItems)
                {
                    GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
                    lootGameObject.GetComponent<SpriteRenderer>().sprite = dropItem.lootSprite;

                    // add animations
                    // add SFX
                }
            }

        }
    }
}
