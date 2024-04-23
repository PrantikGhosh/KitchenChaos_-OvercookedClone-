using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

 
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //there is no kitchen object there
            if (player.HasKitchenObject())
            {
                //player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player not carrying anything
            }
        }
        else
        {
            //there is a kitchen object there
            if(player.HasKitchenObject())
            {
                //Player is carrying somethong
                if(player.GetKitchenObject().TryGetPlate(out PlateKItchenObject plateKItchenObject))
                {
                    PlateKItchenObject plateKitchenObject = player.GetKitchenObject() as PlateKItchenObject;
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    //Player is not carrying plate but something else
                    if(GetKitchenObject().TryGetPlate(out plateKItchenObject))
                    {
                        if (plateKItchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                //Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }


}
