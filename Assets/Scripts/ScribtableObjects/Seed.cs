using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Seed", order = 1)]
public class Seed : ScriptableObject
{
    public PlantGrowthStage[] plantGrowthStages;
    public BackpackItem[] itemsToHarvest;
}