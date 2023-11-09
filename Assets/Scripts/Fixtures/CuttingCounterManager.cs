using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class CuttingCounterManager : CounterManager
    {
        [SerializeField] private CuttingRecipeSOManager[] cuttingRecipeSOArray;

        public override void Interact(PlayerManager player)
        {
            if (!HasKitchenItem())
            {
                // no item
                if (player.HasKitchenItem())
                {
                    // player has item
                    if (HasRecipeWithInput(player.GetKitchenItem().GetKitchenItemsSO()))
                    {
                        // player carrying item that can be cut
                        player.GetKitchenItem().SetKitchenItemParent(this);
                    }
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
            if (HasKitchenItem()  && HasRecipeWithInput(GetKitchenItem().GetKitchenItemsSO()))
            {
                if (!player.HasKitchenItem())
                {
                    KitchenItemsSOManager outputKitchenObjectSO = GetOutputForInput(GetKitchenItem().GetKitchenItemsSO());
                    GetKitchenItem().DestroySelf();

                    KitchenItemManager.SpawnKitchenItem(outputKitchenObjectSO, this);
                }
            }
        }

        private bool HasRecipeWithInput(KitchenItemsSOManager inputKitchenItemSO)
        {
            foreach (CuttingRecipeSOManager cuttingRecipeSO in cuttingRecipeSOArray)
            {
                if (cuttingRecipeSO.input == inputKitchenItemSO)
                {
                    return true;
                }
            }
            return false;
        }

        private KitchenItemsSOManager GetOutputForInput(KitchenItemsSOManager inputKitchenItemSO)
        {
            foreach (CuttingRecipeSOManager cuttingRecipeSO in cuttingRecipeSOArray)
            {
                if (cuttingRecipeSO.input == inputKitchenItemSO)
                {
                    return cuttingRecipeSO.output;
                }
            }

            return null;
        }

    }
}
