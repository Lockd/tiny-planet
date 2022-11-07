using UnityEngine;
using TMPro;

public class HelperTextBehaviour : MonoBehaviour
{
    public GameObject textContainer;
    public TMP_Text textComponent;
    public HintObject[] hints;
    public CharacterBackpack backpack;
    int currentHintIdx = 0;
    HintObject activeHint;

    void Start() {
        textContainer.SetActive(false);
        if (hints.Length > 0) {
            activeHint = hints[currentHintIdx];
        }
    }

    public void moveToNextHint() {
        if (currentHintIdx == hints.Length - 1) {
            onChangeHintActivity(false);
        }
        if (textComponent != null && currentHintIdx < hints.Length - 1) {
            currentHintIdx++;
            activeHint = hints[currentHintIdx];
            textComponent.text = activeHint.hintText;
            if (!getIsRequiredItemsPresent()) {
                onChangeHintActivity(false);
            }
        }
    }

    public void setHint(HintObject hint) {
        activeHint = hint;
        textComponent.text = hint.hintText;
    }

    // Check if all required backpackItems are present in character backpack
    bool getIsRequiredItemsPresent() {
        bool isRequiredItemsPresent = true;
        BackpackItem[] requiredItems = activeHint.itemsRequiredToDisplay;
        foreach (BackpackItem requiredItem in requiredItems)
        {
            bool isPresent = backpack.itemsInBackPack.Find(presentItem => presentItem.prefabName == requiredItem.prefabName);
            if (!isPresent) {
                isRequiredItemsPresent = false;
            }
        }
        return isRequiredItemsPresent;
    }

    void onChangeHintActivity(bool activity) {
        textContainer.gameObject.SetActive(activity);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player" && getIsRequiredItemsPresent()) {
           onChangeHintActivity(true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player") {
            onChangeHintActivity(false);
        }
    }
}
