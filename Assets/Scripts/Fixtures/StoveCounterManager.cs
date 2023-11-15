using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class StoveCounterManager : CounterManager, IHasProgressManager
    {

        public event EventHandler<IHasProgressManager.OnProgressChangedEventArgs> OnProgressChanged;
        public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
        public class OnStateChangedEventArgs : EventArgs
        {
            public State state;
        }

        public enum State
        {
            Idle,
            Cooking,
            Cooked,
            Burned,
        }

        [SerializeField] private CookingRecipeSOManager[] cookingRecipeSOArray;
        [SerializeField] private BurningRecipeSOManager[] burningRecipeSOArray;


        private State state;
        private float cookingTimer;
        private float burningTimer;
        private CookingRecipeSOManager cookingRecipeSO;
        private BurningRecipeSOManager burningRecipeSO;

        private void Start()
        {
            state = State.Idle;
        }

        private void Update()
        {
            if (HasKitchenItem())
            {
                switch (state)
                {
                    case State.Idle:
                        break;
                    case State.Cooking:
                        cookingTimer += Time.deltaTime;

                        OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
                        {
                            progressNormalized = cookingTimer / cookingRecipeSO.cookingTimerMax
                        });


                        if (cookingTimer > cookingRecipeSO.cookingTimerMax)
                        {
                            // cooked
                            GetKitchenItem().DestroySelf();

                            KitchenItemManager.SpawnKitchenItem(cookingRecipeSO.output, this);

                            state = State.Cooked;
                            burningTimer = 0f;
                            burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenItem().GetKitchenItemsSO());

                            OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                            { state = state });
                        }
                        break;
                    case State.Cooked:
                       burningTimer += Time.deltaTime;

                        OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
                        {
                            progressNormalized = burningTimer / burningRecipeSO.burningTimerMax
                        });

                        if (burningTimer > burningRecipeSO.burningTimerMax)
                        {
                            // burned
                            GetKitchenItem().DestroySelf();

                            KitchenItemManager.SpawnKitchenItem(burningRecipeSO.output, this);
                            state = State.Burned;
                            OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                            {
                                state = state
                            });

                            OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
                            {
                                progressNormalized = 0f
                            });
                        }
                        break;
                    case State.Burned:
                        break;
                    default:
                        break;
                }
            }
        }

        public override void Interact(PlayerManager player)
        {
            if (!HasKitchenItem())
            { // no item is on the counter

                if (player.HasKitchenItem() && HasRecipeWithInput(player.GetKitchenItem().GetKitchenItemsSO()))
                {   // player has item that can be cut

                    player.GetKitchenItem().SetKitchenItemParent(this);

                    cookingRecipeSO = GetCookingRecipeSOWithInput(GetKitchenItem().GetKitchenItemsSO());

                    state = State.Cooking;
                    cookingTimer = 0f;

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state
                    });

                    OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
                    {
                        progressNormalized = cookingTimer / cookingRecipeSO.cookingTimerMax
                    });


                }
                else
                {   // player not carrying item that can be cooked

                }
            }
            else
            {   // counter has item

                if (!player.HasKitchenItem())
                {   // player not carrying item

                    GetKitchenItem().SetKitchenItemParent(player);
                    state = State.Idle;
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state
                    });
                    OnProgressChanged?.Invoke(this, new IHasProgressManager.OnProgressChangedEventArgs
                    {
                        progressNormalized = 0f
                    });
                }
            }
        }

        private bool HasRecipeWithInput(KitchenItemsSOManager inputKitchenItemSO)
        {
            CookingRecipeSOManager cookingRecipeSO = GetCookingRecipeSOWithInput(inputKitchenItemSO);
            return cookingRecipeSO != null;
        }

        private KitchenItemsSOManager GetOutputForInput(KitchenItemsSOManager inputKitchenItemSO)
        {
            CookingRecipeSOManager cookingRecipeSO = GetCookingRecipeSOWithInput(inputKitchenItemSO);

            if (cookingRecipeSO != null)
            {
                return cookingRecipeSO.output;
            }
            else
            {
                return null;
            }
        }

        private CookingRecipeSOManager GetCookingRecipeSOWithInput(KitchenItemsSOManager inputKitchenItemSO)
        {
            foreach (CookingRecipeSOManager cookingRecipeSO in cookingRecipeSOArray)
            {
                if (cookingRecipeSO.input == inputKitchenItemSO)
                {
                    return cookingRecipeSO;
                }
            }

            return null;
        }

        private BurningRecipeSOManager GetBurningRecipeSOWithInput(KitchenItemsSOManager inputKitchenItemSO)
        {
            foreach (BurningRecipeSOManager burningRecipeSO in burningRecipeSOArray)
            {
                if (burningRecipeSO.input == inputKitchenItemSO)
                {
                    return burningRecipeSO;
                }
            }

            return null;
        }
    }
}
