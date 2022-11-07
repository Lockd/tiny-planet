using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SoilBehaviour : MonoBehaviour
{
    public CharacterBackpack backpack;
    public SeedBehaviour seedBehaviour;
    
    public void onInteraction() {
        bool isSeedPlanted = seedBehaviour.seed != null;
        if (!isSeedPlanted) {
            // initial interaction when there is no seed planted
            BackpackItem backpackSeed = backpack.itemsInBackPack.Find(item => item.seed != null);
            if (!backpackSeed) {
                return;
            }
            seedBehaviour.addSeed(backpackSeed.seed);
            string[] itemsToRemoveFromBackpack = { backpackSeed.prefabName };
            backpack.removeItems(itemsToRemoveFromBackpack);
        }
        if (isSeedPlanted && !seedBehaviour.isGrown) {
            if (backpack.itemsInBackPack.Find(item => item.prefabName == "Water")) {
                seedBehaviour.addWater();
            } else {
                Debug.Log("You have no water, go find it first");
            }
        }
        if (seedBehaviour.isGrown) {
            seedBehaviour.onHarvestItems();
        }
    }
}
