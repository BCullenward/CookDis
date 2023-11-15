using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    [CreateAssetMenu]
    public class BurningRecipeSOManager : ScriptableObject
    {
        public KitchenItemsSOManager input;
        public KitchenItemsSOManager output;
        public float burningTimerMax;
    }
}
