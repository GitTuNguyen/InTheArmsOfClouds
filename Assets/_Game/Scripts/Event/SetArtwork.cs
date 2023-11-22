using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArtwork : MonoBehaviour
{
    [SerializeField]
    private ConsequenceData consequence;
    public ConsequenceData Consequence 
    {
        get { return consequence; }
        set { consequence = value; }
    }

    /*[SerializeField]
    private Sprite artwork;
    public Sprite Artwork
    {  
        get { return artwork; } 
        set { artwork = value; }
    }*/
 
    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(consequence != null)
        {
            spriteRenderer.sprite = consequence.artwork;
        }
        
    }
}
