using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsequenceDataSO", menuName = "Event System/Consequence")]

public class ConsequenceData : ScriptableObject
{
    public int consequenceCode;
    public Sprite artwork;
    public int weight;

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
        // Todo: Deploy effects - wip
        if (healthEffect != 0)
        {
            EffectDescription effectDecs;
            effectDecs.effectStat = healthEffect;
            effectDecs.effectDesc = "Health";
            effectDescriptions.Add(effectDecs);
            Debug.LogFormat("Deploy health effect: {0}", healthEffect);
        }
        if (luckEffect != 0)
        {
            EffectDescription effectDecs;
            effectDecs.effectStat = luckEffect;
            effectDecs.effectDesc = "Luck";
            effectDescriptions.Add(effectDecs);
            Debug.LogFormat("Deploy luck effect: {0}", luckEffect);
        }
        if (sanityEffect != 0)
        {
            EffectDescription effectDecs;
            effectDecs.effectStat = sanityEffect;
            effectDecs.effectDesc = "Sanity";
            effectDescriptions.Add(effectDecs);
            Debug.LogFormat("Deploy sanity effect: {0}", sanityEffect);
        }
        if (meatEffect != 0)
        {
            EffectDescription effectDecs;
            effectDecs.effectStat = meatEffect;
            effectDecs.effectDesc = "Meat";
            effectDescriptions.Add(effectDecs);
            Debug.LogFormat("Deploy meat effect: {0}", meatEffect);
        }
        if (logEffect != 0)
        {
            EffectDescription effectDecs;
            effectDecs.effectStat = logEffect;
            effectDecs.effectDesc = "Log";
            effectDescriptions.Add(effectDecs);
            Debug.LogFormat("Deploy log effect: {0}", logEffect);
        }
        if (cropEffect != 0)
        {
            EffectDescription effectDecs;
            effectDecs.effectStat = cropEffect;
            effectDecs.effectDesc = "Crop";
            effectDescriptions.Add(effectDecs);
            Debug.LogFormat("Deploy crop effect: {0}", cropEffect);
        }
        if (gemEffect != 0)
        {
            EffectDescription effectDecs;
            effectDecs.effectStat = gemEffect;
            effectDecs.effectDesc = "Gem";
            effectDescriptions.Add(effectDecs);
            Debug.LogFormat("Deploy gem effect: {0}", gemEffect);
        }
        if (seashellEffect != 0)
        {
            EffectDescription effectDecs;
            effectDecs.effectStat = seashellEffect;
            effectDecs.effectDesc = "Seashell";
            effectDescriptions.Add(effectDecs);
            Debug.LogFormat("Deploy seashell effect: {0}", seashellEffect);
        }
        if (magicScrollEffect != 0)
        {
            EffectDescription effectDecs;
            effectDecs.effectStat = magicScrollEffect;
            effectDecs.effectDesc = "Magic Scroll";
            effectDescriptions.Add(effectDecs);
            Debug.LogFormat("Deploy magicScroll effect: {0}", magicScrollEffect);
        }
        foreach (EffectDescription effectDescription in effectDescriptions)
        {
            Debug.LogFormat("ConsequenceData_{0} has effect decription {1} {2}", consequenceCode, effectDescription.effectStat, effectDescription.effectDesc);
        }    
    }    
}
