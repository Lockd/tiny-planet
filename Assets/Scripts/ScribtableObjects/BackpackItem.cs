using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BackpackItem", order = 1)]
public class BackpackItem : ScriptableObject
{
    public string prefabName;
    public int amount;
    public Sprite sprite;
    public Seed seed;
}