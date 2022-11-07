using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockBehaviour : MonoBehaviour
{
    public CharacterBackpack backpack;
    public BackpackItem[] itemsToAddOnInteraction;

    public void onInteraction() {
        backpack.addItems(itemsToAddOnInteraction);
        Destroy(gameObject);
    }
}
