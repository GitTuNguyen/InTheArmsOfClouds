using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollDice(int number)
    {
        switch(number)
        {
            case 1:
                animator.SetTrigger("one");
                break;
            case 2:
                animator.SetTrigger("two");
                break;
            case 3:
                animator.SetTrigger("three");
                break;
            case 4:
                animator.SetTrigger("four");
                break;
            case 5:
                animator.SetTrigger("five");
                break;
            case 6:
                animator.SetTrigger("six");
                break;
        }
    }
}
