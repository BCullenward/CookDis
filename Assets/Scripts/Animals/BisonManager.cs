using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class BisonManager : AnimalManager
    {
        //private
        //public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
        //public class OnProgressChangedEventArgs : EventArgs
        //{
        //    public float progressNormalized;
        //}

        [SerializeField] private FloatingHarvestProgressBar harvestBar;

        public event EventHandler OnCut;
        [SerializeField] private HarvestProgressSOManager harvest;

        //[SerializeField] private AnimalItemsSOManager[] animalItemsSO;

        private int harvestProgress;

        private void Awake()
        {
            harvestBar = GetComponentInChildren<FloatingHarvestProgressBar>();
        }


        public override void Interact(PlayerManager player)
        {
            Debug.Log("Moo");
        }

        public override void InteractAlternate(PlayerManager player)
        {
            Debug.Log("Test");

            harvestProgress++;

            OnCut?.Invoke(this, EventArgs.Empty);

            harvestBar.UpdateHarvestBar(harvestProgress, harvest.harvestProgressMax);


            //harvestBar.OnProgressChanged?.Invoke(this, new FloatingHarvestProgressBar.OnProgressChangedEventArgs)
            //    {

            //}

            //OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            //{
            //    progressNormalized = (float)harvestProgress / harvest.harvestProgressMax
            //});

            if (harvestProgress >= harvest.harvestProgressMax)
            {
                //Get Loot/harvest items
                Debug.Log("Drop loot");

                Destroy(this);

            }




            //AnimalHarvestItemsSOManager animalHarvestItemSO = GetAnimalHarvestItemSOWithInput());

            ////CuttingRecipeSOManager cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenItem().GetKitchenItemsSO());

            //OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            //{
            //    progressNormalized = (float)cuttingProgress / cuttingRecipeSO.cuttingProgressMax
            //});


            //if (cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
            //{
            //    KitchenItemsSOManager outputKitchenObjectSO = GetOutputForInput(GetKitchenItem().GetKitchenItemsSO());
            //    GetKitchenItem().DestroySelf();

            //    KitchenItemManager.SpawnKitchenItem(outputKitchenObjectSO, this);
            //}

        }


        //private AnimalHarvestItemsSOManager GetAnimalHarvestItemSOWithInput(AnimalItemsSOManager animal)
        //{
        //    foreach (AnimalHarvestItemsSOManager cuttingRecipeSO in cuttingRecipeSOArray)
        //    {
        //        if (cuttingRecipeSO.input == inputKitchenItemSO)
        //        {
        //            return cuttingRecipeSO;
        //        }
        //    }

        //    return null;
        //}
    //}

    }
}
