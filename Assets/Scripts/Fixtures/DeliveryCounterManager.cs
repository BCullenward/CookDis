using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class DeliveryCounterManager : CounterManager
    {
        public override void Interact(PlayerManager player)
        {
            if (player.HasKitchenItem())
            {
                if (player.GetKitchenItem().TryToGetPlate(out PlateKitchenItemManager plateKitchenItem))
                {   // only accepts plates

                    DeliveryManagerManager.Instance.DeliverRecipe(plateKitchenItem);

                    player.GetKitchenItem().DestroySelf();
                }
            }
        }
    }
}
