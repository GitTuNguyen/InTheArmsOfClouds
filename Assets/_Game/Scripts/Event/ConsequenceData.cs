using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsequenceDataSO", menuName = "Event System/Consequence")]

public class ConsequenceData : ScriptableObject
{
    public int consequenceCode;
    public Sprite artwork;
    public int weight;
    public string consequenceDesc;

    // Efect
    public int healthEffect;
    public int luckEffect;
    public int sanityEffect;
    public int meatEffect;
    public int logEffect;
    public int cropEffect;
    public int gemEffect;
    public int seashellEffect;
    public int magicScrollEffect;
    [System.Serializable] public struct EffectDescription
    {
        public int effectStat;
        public string effectDesc;
    }
    public List<EffectDescription> effectDescriptions;


    public void DeployEffects()
    {
        effectDescriptions.Clear(); //Tu: Clear data
        // Todo: Deploy effects - done
        DeployEffectForPlayerStats(healthEffect, luckEffect, sanityEffect);

        if (healthEffect != 0)
        {
            Debug.LogFormat("Deploy health effect: {0}", healthEffect);
        }
        if (luckEffect != 0)
        {
            Debug.LogFormat("Deploy luck effect: {0}", luckEffect);
        }
        if (sanityEffect != 0)
        {
            Debug.LogFormat("Deploy sanity effect: {0}", sanityEffect);
        }
        if (meatEffect != 0)
        {
            DeployEffectForItems(ItemType.Meat, meatEffect);
            Debug.LogFormat("Deploy meat effect: {0}", meatEffect);
        }
        if (logEffect != 0)
        {
            DeployEffectForItems(ItemType.Log, logEffect);
            Debug.LogFormat("Deploy log effect: {0}", logEffect);
        }
        if (cropEffect != 0)
        {
            DeployEffectForItems(ItemType.Crop, cropEffect);
            Debug.LogFormat("Deploy crop effect: {0}", cropEffect);
        }
        if (gemEffect != 0)
        {
            DeployEffectForItems(ItemType.Gem, gemEffect);
            Debug.LogFormat("Deploy gem effect: {0}", gemEffect);
        }
        if (seashellEffect != 0)
        {
            DeployEffectForItems(ItemType.Seashell, seashellEffect);
            Debug.LogFormat("Deploy seashell effect: {0}", seashellEffect);
        }
        if (magicScrollEffect != 0)
        {
            DeployEffectForItems(ItemType.MagicScroll, magicScrollEffect);
            Debug.LogFormat("Deploy magicScroll effect: {0}", magicScrollEffect);
        }

        foreach (EffectDescription effectDescription in effectDescriptions)
        {
            Debug.LogFormat("ConsequenceData_{0} has effect decription {1} {2}", consequenceCode, effectDescription.effectStat, effectDescription.effectDesc);
        }
        GameManager.Instance.player.RemoveShield();
    }

    void DeployEffectForPlayerStats(int health, int luck, int sanity)
    {
        GameManager.Instance.player.UpdateStatsOfPlayer(health, luck, sanity);
    }    

    void DeployEffectForItems(ItemType itemType, int effect)
    {
        InventoryItemData itemData = InventoryHolder.Instance.InventorySystem.GetItemByItemType(itemType);
        InventoryHolder.Instance.InventorySystem.AddToInventory(itemData, effect);
    }    
}
