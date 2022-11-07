using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public BackpackItem[] itemsToGiveOnInitialSearch;
    public CharacterBackpack backpack;
    public BackpackItem[] itemsAfterMeltingIce;
    public HelperTextBehaviour helperTextBehaviour;
    BackpackItem ice;
    string[] itemsToRemoveOnMeltingIce = { "Ice" };

    bool areItemsTaken = false;
    bool isIceBlockMelted = false;

    public void onInteraction() {
        BackpackItem ice = backpack.itemsInBackPack.Find(x => x.prefabName == "Ice");
        if (areItemsTaken && !isIceBlockMelted && ice != null) {
            onIceblockMelting();
        }
        if (!areItemsTaken) {
            onInitialSearch();
        }
    }

    void onInitialSearch() {
        backpack.addItems(itemsToGiveOnInitialSearch);
        areItemsTaken = true;
        helperTextBehaviour.moveToNextHint();
    }

    void onIceblockMelting() {
        backpack.removeItems(itemsToRemoveOnMeltingIce);
        backpack.addItems(itemsAfterMeltingIce);
        isIceBlockMelted = true;
        helperTextBehaviour.moveToNextHint();
    }
}
