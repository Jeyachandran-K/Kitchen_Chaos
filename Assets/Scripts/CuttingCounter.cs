using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField]private CutKitchenObjectSO[] cutKitchenObjectSOArray;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
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
            KitchenObjectSO inputKitchenObjectSO = GetInputOutputKitchenObjectSO(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(inputKitchenObjectSO, this);
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
