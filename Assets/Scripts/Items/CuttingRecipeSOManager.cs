using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    [CreateAssetMenu]
    public class CuttingRecipeSOManager : ScriptableObject
    {
        public KitchenItemsSOManager input;
        public KitchenItemsSOManager output;
    }
}
