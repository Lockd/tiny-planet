using UnityEngine;

[CreateAssetMenu(fileName = "Hint", menuName = "ScriptableObjects/Hint", order = 1)]
public class HintObject : ScriptableObject
{
    public BackpackItem[] itemsRequiredToDisplay;
    public string hintText;
}