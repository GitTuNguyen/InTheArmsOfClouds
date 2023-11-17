using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        item.Print();
    }

}
