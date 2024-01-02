using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class CuttingCounterManager : CounterManager, IHasProgressManager
    {
        public static event EventHandler OnAnyCut;

        public event EventHandler<IHasProgressManager.OnProgressChangedEventArgs> OnProgressChanged;
        public event EventHandler OnCut;

        [SerializeField] private CuttingRecipeSOManager[] cuttingRecipeSOArray;

        private int cuttingProgress;


        public override void Interact(PlayerManager player)
        {
            if (!HasKitchenItem())
            { // no item is on the counter

                if (player.HasKitchenItem() && HasRecipeWithInput(player.GetKitchenItem().GetKitchenItemsSO()))
                {   // player has item that can be cut

                    player.GetKitchenItem().SetKitchenItemParent(this);
                    cuttingProgress = 0;

                    CuttingRecipeSOManager cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenItem().GetKitchenItemsSO());
                    OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
                    {
                        progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                    });
                }
                else
                {   // player not carrying item that can be cut

                }
            }
            else
            {   // counter has item

                if (player.HasKitchenItem())
                { // player carrying item
                    if (player.GetKitchenItem().TryToGetPlate(out PlateKitchenItemManager plateKitchenItem))
                    { // player is holding a plate

                        if (plateKitchenItem.TryToAddIngredient(GetKitchenItem().GetKitchenItemsSO()))
                        {
                            GetKitchenItem().DestroySelf();
                        }
                    }
                }
                else
                {   // player not carrying item

                    GetKitchenItem().SetKitchenItemParent(player);
                    OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
                    {
                        progressNormalized = 0f
                    });
                }
            }
        }

        public override void InteractAlternate(PlayerManager player)
        {
            if (HasKitchenItem()  && HasRecipeWithInput(GetKitchenItem().GetKitchenItemsSO()))
            {   // item that can be cut is on the counter

                if (!player.HasKitchenItem())
                {   // player isn't carrying anything so cut the item

                    cuttingProgress++;

                    OnCut?.Invoke(this, EventArgs.Empty);
                    OnAnyCut?.Invoke(this, EventArgs.Empty);

                    CuttingRecipeSOManager cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenItem().GetKitchenItemsSO());

                    OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
                    {
                        progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
                    });


                    if (cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
                    {   // item has been cut to max level

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
