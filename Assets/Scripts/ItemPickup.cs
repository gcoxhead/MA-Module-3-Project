using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    [SerializeField]
    GameBehaviour gamebehaviour;
    
    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        if (item.name=="GateKey")
        {
            gamebehaviour.hasKey = true;
        }
        Destroy(gameObject);
        
    }

    private void OnMouseDown()
    {
        Pickup();
        
    }
}
