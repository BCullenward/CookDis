using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class CuttingCounterManager : CounterManager
    {
        [SerializeField] private KitchenItemsSOManager cutKitchenItemSO;

        public override void Interact(PlayerManager player)
        {
            if (!HasKitchenItem())
            {
                // no item
                if (player.HasKitchenItem())
                {
                    // player has item
                    player.GetKitchenItem().SetKitchenItemParent(this);
                }
                else
                {
                    // player not carrying item
                }
            }
            else
            {
                // has item
                if (player.HasKitchenItem())
                {
                    // player carrying item
                }
                else
                {
                    // player not carrying item
                    GetKitchenItem().SetKitchenItemParent(player);
                }
            }
        }

        public override void InteractAlternate(PlayerManager player)
        {
            if (HasKitchenItem())
            {
                if (!player.HasKitchenItem())
                {
                    GetKitchenItem().DestroySelf();

                    KitchenItemManager.SpawnKitchenItem(cutKitchenItemSO, this);
                }

            }
        }

    }
}
