using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField]private CutKitchenObjectSO[] cutKitchenObjectSOArray;

    private int numberOfCuts;
    private float progressPercent;

    public event EventHandler<OnObjectCutEventArgs> OnObjectCut;

    public class OnObjectCutEventArgs : EventArgs
    {
        public float progressPercent;
    }



    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject() && player.GetKitchenObject().GetKitchenObjectSO().isCuttable)
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
                numberOfCuts = 0;
            }
            else
            {

            }
        }
        else
        {
            if (player.HasKitchenObject())
            {

            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    public  override void AlternateInteract(Player player)
    {
        if (HasKitchenObject())
        {
            if (GetKitchenObject().GetKitchenObjectSO().isCuttable)
            {
                numberOfCuts++;
                progressPercent = (float)numberOfCuts / GetKitchenObject().GetKitchenObjectSO().maxCutsRequired;
                OnObjectCut?.Invoke(this,new OnObjectCutEventArgs
                {
                    progressPercent=progressPercent,
                });

                if (numberOfCuts >= GetKitchenObject().GetKitchenObjectSO().maxCutsRequired)
                {
                    KitchenObjectSO outputKitchenObjectSO = GetInputOutputKitchenObjectSO(GetKitchenObject().GetKitchenObjectSO());
                    GetKitchenObject().DestroySelf();
                    SetKitchenObject(null);
                    KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
                } 
            }
            else
            {
                Debug.LogError("Object is not cuttable");
            }
        }
    }

    private KitchenObjectSO GetInputOutputKitchenObjectSO(KitchenObjectSO inputKitchObjectSO)
    {
        foreach (CutKitchenObjectSO input in cutKitchenObjectSOArray)
        {
            if(input.inputKitchenObjectSO == inputKitchObjectSO)
            {
                return input.outputKitchenObjectSO;
            }
        }
        return null;
    }

}
