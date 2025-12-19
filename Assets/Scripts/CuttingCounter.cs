using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField]private KitchenObjectSO cutKitchenObjectSO;
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
            GetKitchenObject().DestroySelf();
            Transform cutKitchenObjectTransform = Instantiate(cutKitchenObjectSO.prefab);
            KitchenObject kitchenObject = cutKitchenObjectTransform.GetComponent<KitchenObject>();

            kitchenObject.SetKitchenObjectParent(this);

        }
    }

}
