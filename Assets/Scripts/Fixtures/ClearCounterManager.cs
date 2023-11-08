using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class ClearCounterManager : CounterManager
    {
        [SerializeField] private KitchenItemsSOManager kitchenItemsSO;


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

    }
}
