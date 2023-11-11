using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class CuttingCounterManager : CounterManager
    {
        public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
        public class OnProgressChangedEventArgs : EventArgs
        {
            public float progressNormalized;
        }

        public event EventHandler OnCut;

        [SerializeField] private CuttingRecipeSOManager[] cuttingRecipeSOArray;

        private int cuttingProgress;


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
                        cuttingProgress = 0;

                        CuttingRecipeSOManager cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenItem().GetKitchenItemsSO());

                        OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                        {
                            progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                        });
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
                    cuttingProgress++;

                    OnCut?.Invoke(this, EventArgs.Empty);
                    CuttingRecipeSOManager cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenItem().GetKitchenItemsSO());

                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                    });


                    if (cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
                    {
                        KitchenItemsSOManager outputKitchenObjectSO = GetOutputForInput(GetKitchenItem().GetKitchenItemsSO());
                        GetKitchenItem().DestroySelf();

                        KitchenItemManager.SpawnKitchenItem(outputKitchenObjectSO, this);
                    }
                }
            }
        }

        private bool HasRecipeWithInput(KitchenItemsSOManager inputKitchenItemSO)
        {
            CuttingRecipeSOManager cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenItemSO);
            return cuttingRecipeSO != null;
        }

        private KitchenItemsSOManager GetOutputForInput(KitchenItemsSOManager inputKitchenItemSO)
        {
            CuttingRecipeSOManager cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenItemSO);

            if (cuttingRecipeSO != null)
            {
                return cuttingRecipeSO.output;
            }
            else
            {
                return null;
            }
        }

        private CuttingRecipeSOManager GetCuttingRecipeSOWithInput(KitchenItemsSOManager inputKitchenItemSO)
        {
            foreach (CuttingRecipeSOManager cuttingRecipeSO in cuttingRecipeSOArray)
            {
                if (cuttingRecipeSO.input == inputKitchenItemSO)
                {
                    return cuttingRecipeSO;
                }
            }

            return null;
        }

    }
}
