using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class DeliveryManager : MonoBehaviour
    {
        public static DeliveryManager Instance {get; private set; }
        [SerializeField] RecipeListSOManager recipeListSO;
        private List<RecipeSOManager> waitingRecipeSOList;

        private float spawnRecipeTimer;
        private float spawnRecipeTimerMax = 4f;
        private int waitingRecipesMax = 4;

        private void Awake()
        {
            Instance = this;

            waitingRecipeSOList = new List<RecipeSOManager>();
        }

        private void Update()
        {
            if (waitingRecipeSOList.Count > waitingRecipesMax)
                return;

            spawnRecipeTimer -= Time.deltaTime;
            if (spawnRecipeTimer <= 0f)
            {
                spawnRecipeTimer = spawnRecipeTimerMax;

                RecipeSOManager waitingRecipeSO = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);
                waitingRecipeSOList.Add(waitingRecipeSO);
            }
        }

        public void DeliverRecipe(PlateKitchenItemManager plateKitchenItem)
        {
            for (int i=0; i < waitingRecipeSOList.Count; i++)
            {
                RecipeSOManager waitingRecipeSO = waitingRecipeSOList[i];

                if (waitingRecipeSO.kitchenItemsSOList.Count == plateKitchenItem.GetKitchenItemsSOList().Count)
                {   // has same number of ingredients
                    // the plate object should be changed so it can get a recipe name as items are being put on the plate then the names can be compared to see if it's a valid recipe

                    bool plateContentsMatchesRecipe = true;
                    foreach (KitchenItemsSOManager recipeKitchenItemSO in waitingRecipeSO.kitchenItemsSOList)
                    {   // cycle through ingredients in recipe
                        bool ingredientFound = false;
                        foreach (KitchenItemsSOManager plateKitchenItemSO in plateKitchenItem.GetKitchenItemsSOList())
                        {   // cycle through ingredients on plate
                            if (plateKitchenItemSO == recipeKitchenItemSO)
                            {
                                ingredientFound = true;
                                break;
                            }
                        }
                        if (!ingredientFound)
                        { // This Recipe ingredient was not found on the plate
                            plateContentsMatchesRecipe = false;
                        }
                    }

                    if (plateContentsMatchesRecipe)
                    { // Player delivered correct recipe
                        Debug.Log("Correct");
                        waitingRecipeSOList.RemoveAt(i);
                        return;
                    }
                }
            }

            // No matches found - Player did not deliver correct recipe
            Debug.Log("Wah wah no correct recipe");
        }


    }

}
