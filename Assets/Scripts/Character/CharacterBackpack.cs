using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBackpack : MonoBehaviour
{
    public List<BackpackItem> itemsInBackPack = new List<BackpackItem>();
    
    public void addItems(BackpackItem[] items) {
        for (int i = 0; i < items.Length; i++) {
            itemsInBackPack.Add(items[i]);
        }
    }

    public void removeItems(string[] itemNames) {
        for (int i = 0; i < itemNames.Length; i++) {
            BackpackItem itemToRemove = itemsInBackPack.Find(item => item.prefabName == itemNames[i]);
            itemsInBackPack.Remove(itemToRemove);
        }
    }
}
