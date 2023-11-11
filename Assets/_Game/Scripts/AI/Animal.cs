using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : LivingEntity
{
    [SerializeField]
    private Gender gemder;

    [SerializeField]
    private AnimalType type;

    private float thirst;

    private float hunger;

    private float reproductive;

    private float timeLine;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float timeToAdult;

    [SerializeField]
    private AnimalUI animalUI;


    // Start is called before the first frame update
    void Start()
    {
        RestartAnimal();
        //animalUI = GetComponent<AnimalUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLine += Time.deltaTime;

        if(status == Status.Childe)
        {
            if(timeLine >= timeToAdult)
            {
                status = Status.Adults;
                StartCoroutine(TimeToGrownUp());
            }
        }

        hunger += Time.deltaTime;
        thirst += Time.deltaTime*2;
        if(status == Status.Adults)
        {
            reproductive+= Time.deltaTime;
        }

        animalUI.SetAnimalUI(hunger, thirst, reproductive);
    }

    private void RestartAnimal()
    {
        transform.localScale = chidleScale;

        timeLine = 0;

        thirst = Random.Range(0,5);

        hunger = Random.Range(0, 10);

        reproductive = 0;
    }

    public bool IsSearchFoodAndDrink()
    {
        return hunger > 20 || thirst > 25;

    }

    public void AnimalWalking()
    {
        transform.position += transform.forward * Time.deltaTime * walkSpeed;
    }
}
