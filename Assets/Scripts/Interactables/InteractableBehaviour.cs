using UnityEngine;

public class InteractableBehaviour : MonoBehaviour
{
    public GameObject interactionTarget;
    bool isInCollider = false;
    public bool canBeTriggeredMoreThanOnce = true;
    bool haveBeenTriggered = false;

    void Update()
    {
        if (
            isInCollider &&
            Input.GetKeyDown(KeyCode.E) &&
            interactionTarget != null && 
            (canBeTriggeredMoreThanOnce || !haveBeenTriggered)
        ) {
            string targetTag = interactionTarget.tag;
            // TODO revisit this switch statement?
            switch(targetTag) {
                case "Ship":
                    ShipBehaviour shipBehaviour = interactionTarget.GetComponent<ShipBehaviour>();
                    if (shipBehaviour != null){
                        shipBehaviour.onInteraction();
                    }
                    break;
                case "Iceblock":
                    IceBlockBehaviour iceBlockBehaviour = interactionTarget.GetComponent<IceBlockBehaviour>();
                    if (iceBlockBehaviour != null) {
                        iceBlockBehaviour.onInteraction();
                    }
                    break;
                case "Soil":
                    SoilBehaviour soilBehaviour = interactionTarget.GetComponent<SoilBehaviour>();
                    if (soilBehaviour != null) {
                        soilBehaviour.onInteraction();
                    }
                    break;
                default:
                    break;
            }
            haveBeenTriggered = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            isInCollider = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player") {
            isInCollider = false;
        }
    }
}
