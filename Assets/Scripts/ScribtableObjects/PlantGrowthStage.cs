using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlantGrowthStage", order = 1)]
public class PlantGrowthStage : ScriptableObject
{
    public string stageName;
    public float timeToGrow;
    public Sprite sprite;
    public bool isWateringNeeded = true;
}