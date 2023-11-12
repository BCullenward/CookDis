using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookDis
{
    public class PlayerManager : MonoBehaviour, IKitchenItemParentManager//, IAnimalItemParentManager
    {
        public static PlayerManager Instance { get; private set; }

        public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
        public class OnSelectedCounterChangedEventArgs : EventArgs
        {
            public CounterManager selectedCounter;
        }

        public event EventHandler<OnSelectedAnimalChangedEventArgs> OnSelectedAnimalChanged;
        public class OnSelectedAnimalChangedEventArgs :EventArgs
        {
            public AnimalManager selectedAnimal;
        }

        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private PlayerInputManager playerInput;
        [SerializeField] private LayerMask countersLayerMask;
        [SerializeField] private LayerMask animalsLayerMask;
        [SerializeField] private Transform itemHoldPoint;

        private bool isWalking;
        private Vector3 lastInteractDir;
        private CounterManager selectedCounter;
        private KitchenItemManager kitchenItem;

        private AnimalManager selectedAnimal;
        //private AnimalItemManager animalItem;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            playerInput.OnInteractAction += PlayerInput_OnInteractAction;
            playerInput.OnInteractAlternateAction += PlayerInput_OnInteractAlternateAction;
        }

        private void PlayerInput_OnInteractAlternateAction(object sender, EventArgs e)
        {
            if (selectedCounter != null)
            {
                selectedCounter.InteractAlternate(this);
            }

            if (selectedAnimal != null)
            {
                selectedAnimal.InteractAlternate(this);
            }
        }

        private void PlayerInput_OnInteractAction(object sender, EventArgs e)
        {
            if (selectedCounter != null)
            {
                selectedCounter.Interact(this);
            }

            if (selectedAnimal != null)
            {
                selectedAnimal.Interact(this);
            }

        }

        private void Update()
        {
            HandleAllPlayerActions();
        }

        private void HandleAllPlayerActions()
        {
            HandleMovement();
            HandleInteractions();
        }

        private void HandleInteractions()
        {
            Vector2 inputVector = playerInput.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            if (moveDir != Vector3.zero)
            {
                lastInteractDir = moveDir;
            }

            CheckCounterSelect();
            CheckAnimalSelect();
        }

        private void CheckCounterSelect()
        {
            SetSelectedCounter(null);
            float interactCounterDistance = 2f;
            if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactCounterDistance, countersLayerMask))
            {
                // set Counter
                if (raycastHit.transform.TryGetComponent(out CounterManager counter))
                {
                    // has clear counter
                    if (counter != selectedCounter)
                    {
                        SetSelectedCounter(counter);
                    }
                }
            }
        }

        private void CheckAnimalSelect()
        {
            SetSelectedAnimal(null);
            float interactAnimalDistance = 2f;

            //Debug.Log("Transform.position: " + transform.position + "---LastInteractDir: " +  lastInteractDir);

            Ray ray = new Ray(transform.position, lastInteractDir);
            RaycastHit hitData;
            //Physics.Raycast(ray, out hitData, interactAnimalDistance, animalsLayerMask);

            //if (hitData.transform.TryGetComponent(out BisonManager bison))
            //{
            //    Debug.Log("found");
            //}
            //else
            //{
            //    Debug.Log("not found");
            //}

            if (Physics.Raycast(ray, out hitData, interactAnimalDistance, countersLayerMask))
            {
                Debug.Log("wha");
                // set Animal
                if (hitData.transform.TryGetComponent(out AnimalManager animal))
                {
                    Debug.Log("Animal->" + animal + " - Selected Animal->" + selectedAnimal);
                    if (animal != selectedAnimal)
                    {
                        Debug.Log("Set start");
                        SetSelectedAnimal(animal);
                        Debug.Log("Set end");
                    }
                }
            }
        }


        public bool IsWalking()
        {
            return isWalking;
        }

        private void HandleMovement()
        {
            Vector2 inputVector = playerInput.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

            float playerRadius = 0.7f;
            float playerHeight = 2f;
            float moveDistance = moveSpeed * Time.deltaTime;
            bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

            if (!canMove)
            {
                // attempt only x movement
                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
                canMove = moveDir.x !=0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

                if (canMove)
                {
                    // can move only on the x
                    moveDir = moveDirX;
                }
                else
                {
                    // cannot move only on the x
                    // attempt only z movement
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                    canMove = moveDir.z !=0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                    if (canMove)
                    {
                        // can move only on the y
                        moveDir = moveDirZ;
                    }
                    else
                    {
                        // cannot move in any direction
                    }
                }
            }

            if (canMove)
            {
                transform.position += moveDir * moveDistance;
            }
            isWalking = moveDir != Vector3.zero;

            float rotateSpeed = 10f;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }

        private void SetSelectedCounter(CounterManager selectedCounter)
        {
            this.selectedCounter = selectedCounter;
            OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
            {
                selectedCounter = selectedCounter
            });
        }


        private void SetSelectedAnimal(AnimalManager selectedAnimal)
        {
            this.selectedAnimal = selectedAnimal;
            OnSelectedAnimalChanged?.Invoke(this, new OnSelectedAnimalChangedEventArgs
            {
                selectedAnimal = selectedAnimal
            });
        }

        public Transform GetKitchenItemFollowTransform()
        {
            return itemHoldPoint;
        }

        public void SetKitchenItem(KitchenItemManager kitchenItem)
        {
            // TO_DO play grab animation
            // TO_DO play soundFX
            this.kitchenItem = kitchenItem;
        }

        public KitchenItemManager GetKitchenItem()
        {
            return kitchenItem;
        }

        public void ClearKitchenItem()
        {
            // TO_DO play drop animation
            // TO_DO  play SFX
            kitchenItem = null;
        }

        public bool HasKitchenItem()
        {
            return kitchenItem != null;
        }

        //public AnimalItemManager GetAnimalItem()
        //{
        // //   return animalItem;
        //}

        //public bool HasAnimalItem()
        //{
        //    return animalItem != null;
        //}
    }
}
