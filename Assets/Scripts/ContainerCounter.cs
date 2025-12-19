using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnOpenOrClose;
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {

            KitchenObject.SpawnKitchenObject(kitchenObjectSO,player);

            OnOpenOrClose?.Invoke(this, EventArgs.Empty);
        }
    }
    
}
