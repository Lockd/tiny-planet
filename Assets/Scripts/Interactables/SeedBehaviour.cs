using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBehaviour : MonoBehaviour
{
    // This var should not be public when seed selection is ready
    public SpriteRenderer spriteRenderer;
    public Seed seed;
    public CharacterBackpack backpack;
    public HelperTextBehaviour helperTextBehaviour;
    public HintObject plantSeedHint;
    public HintObject addWaterHint;
    public HintObject harvestHint;
    [ HideInInspector ] public bool isGrown = false;
    int currentGrowthStageIdx = 0;
    PlantGrowthStage[] plantGrowthStages;
    int amountOfStages;
    // TODO revisit the naming?
    float finishTime;
    bool isWaterAdded = false;
    PlantGrowthStage currentGrowthStage;

    void Start() {
        helperTextBehaviour.setHint(plantSeedHint);
    }

    void Update()
    {
        // TODO allow to collect or destroy current plant?
        if (
            seed != null &&
            currentGrowthStageIdx < amountOfStages - 1 &&
            finishTime < Time.time &&
            ((currentGrowthStage.isWateringNeeded && isWaterAdded) || !currentGrowthStage.isWateringNeeded)
        ) {
            moveToNextStage();
        }
    }

    void moveToNextStage(bool isInitialRendering = false) {
        if (!isInitialRendering) {
            currentGrowthStageIdx++;
        }
        currentGrowthStage = plantGrowthStages[currentGrowthStageIdx];
        spriteRenderer.sprite = currentGrowthStage.sprite;
        finishTime = Time.time + currentGrowthStage.timeToGrow;
        isWaterAdded = false;

        if (currentGrowthStageIdx == amountOfStages - 1 && !isGrown) {
            onGrowthComplete();
        }
    }

    void onGrowthComplete() {
        Debug.Log("Plant have finished growing");
        helperTextBehaviour.setHint(harvestHint);
        isGrown = true;
    }

    public void onHarvestItems() {
        Debug.Log("Harvesting plants");
        backpack.addItems(seed.itemsToHarvest);
        helperTextBehaviour.setHint(plantSeedHint);
        seed = null;
        isGrown = false;
        isWaterAdded = false;
        currentGrowthStageIdx = 0;
        spriteRenderer.sprite = null;
    }

    public void addWater() {
        Debug.Log("Adding water to plant");
        if (seed != null) {
            isWaterAdded = true;
        }
    }
    public void addSeed(Seed seedToBeAdded) {
        Debug.Log("Adding seed to soil");
        seed = seedToBeAdded;
        plantGrowthStages = seed.plantGrowthStages;
        amountOfStages = plantGrowthStages.Length;
        helperTextBehaviour.setHint(addWaterHint);

        if (plantGrowthStages.Length != 0) {
            moveToNextStage(true);
        }
    }
}
