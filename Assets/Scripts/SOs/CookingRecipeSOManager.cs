using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    [CreateAssetMenu]
    public class CookingRecipeSOManager : ScriptableObject
    {
        public KitchenItemsSOManager input;
        public KitchenItemsSOManager output;
        public int cookingProgressMax;
    }
}
