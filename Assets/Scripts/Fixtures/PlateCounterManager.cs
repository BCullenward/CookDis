using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class PlateCounterManager : CounterManager
    {
        public event EventHandler OnPlateSpawned;
        public event EventHandler OnPlateRemoved;

        [SerializeField] private KitchenItemsSOManager plateKitchenItemSO;

        private float spawnPlateTimer;
        private float spawnPlateTimerMax = 4f;
        private int plateSpawnedAmount;
        private int plateSpawnedAmountMax = 4;

        private void Update()
        {
            spawnPlateTimer += Time.deltaTime;
            if (spawnPlateTimer > spawnPlateTimerMax)
            {
                spawnPlateTimer = 0f;

                if (plateSpawnedAmount < plateSpawnedAmountMax)
                {
                    plateSpawnedAmount++;
                    OnPlateSpawned?.Invoke(this, EventArgs.Empty);
                }
            }
        }


        public override void Interact(PlayerManager player)
        {
            if (!player.HasKitchenItem())
            {
                if (plateSpawnedAmount > 0)
                {
                    plateSpawnedAmount--;

                    KitchenItemManager.SpawnKitchenItem(plateKitchenItemSO, player);
                    OnPlateRemoved?.Invoke(this, EventArgs.Empty);
                }
            }



            //if (!HasKitchenItem())
            //{ // no item is on the counter

            //    if (player.HasKitchenItem() && HasRecipeWithInput(player.GetKitchenItem().GetKitchenItemsSO()))
            //    {   // player has item that can be cut

            //        player.GetKitchenItem().SetKitchenItemParent(this);
            //        cuttingProgress = 0;

            //        CuttingRecipeSOManager cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenItem().GetKitchenItemsSO());
            //        OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
            //        {
            //            progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
            //        });
            //    }
            //    else
            //    {   // player not carrying item that can be cut

            //    }
            //}
            //else
            //{   // counter has item

            //    if (!player.HasKitchenItem())
            //    {   // player not carrying item

            //        GetKitchenItem().SetKitchenItemParent(player);
            //        OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
            //        {
            //            progressNormalized = 0f
            //        });
            //    }
            //}
        }

    }
}
