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
            { // Counter does not have an item on it

                if (player.HasKitchenItem())
                { // player holding an item

                    player.GetKitchenItem().SetKitchenItemParent(this);
                }
                else
                { // player not carrying item

                }
            }
            else
            { // counter has item

                if (player.HasKitchenItem())
                { // player carrying item

                    if (player.GetKitchenItem().TryToGetPlate(out PlateKitchenItemManager plateKitchenItem))
                    { // player is holding a plate

                        if (plateKitchenItem.TryToAddIngredient(GetKitchenItem().GetKitchenItemsSO()))
                        {
                            GetKitchenItem().DestroySelf();
                        }
                    }
                    else
                    { // player is not holding a plate, but holding something else

                        if (GetKitchenItem().TryToGetPlate(out plateKitchenItem))
                        { // counter holding plate

                            if (plateKitchenItem.TryToAddIngredient(player.GetKitchenItem().GetKitchenItemsSO()))
                            { // item player is holding can be added to plate (valid ingredient)

                                player.GetKitchenItem().DestroySelf();
                            }
                        }
                    }
                }
                else
                { // player not carrying item

                    GetKitchenItem().SetKitchenItemParent(player);
                }
            }
        }

    }
}
