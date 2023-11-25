using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMachine : MonoBehaviour
{
    private List<Block> blocks;

    private void Start()
    {
        blocks = new List<Block>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            Block block = other.GetComponent<Block>();

            if(block != null && block.CheckCloudOfBlock())
            {
                block.ActivePreditionCouldBlock();
                blocks.Add(block);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Block block = other.GetComponent<Block>();

            if (block != null && block.CheckCloudOfBlock())
            {
                block.DeactivePreditionCouldBlock();
                blocks.Remove(block);
            }
        }
    }

    public void RemoveCouldOfListBlock()
    {
        foreach(Block block in blocks)
        {
            block.RemoveCloudOfBlock();
        }
    }
}
