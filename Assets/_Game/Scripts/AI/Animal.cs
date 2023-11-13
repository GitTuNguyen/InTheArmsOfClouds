using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public float Thirst
    {
        get { return thirst; }
    }

    public float Hunger
    {
        get { return hunger; }
    }

    private float timeLine;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float timeToAdult;

    [SerializeField]
    private AnimalUI animalUI;

    [SerializeField]
    public GameObject rightVision;

    [SerializeField]
    public GameObject leftVision;

    [SerializeField]
    public LayerMask obstacleLayerMask;

    [SerializeField]
    private float detectionRadius;

    private Vector3 posFood;
    
    private Vector3 posWater;
   
    private Vector3 posMate;

    private bool isEating;
    private bool isDrinking;

    public bool IsEating
    {
        set { isEating = value; }
        get { return isEating; }
    }

    public bool IsDrinking
    {
        set { isDrinking = value; }
        get { return isDrinking; }
    }


    // Start is called before the first frame update
    void Start()
    {
        RestartAnimal();
        //animalUI = GetComponent<AnimalUI>();
    }
    void OnDrawGizmos()
    {
        if (rightVision != null)
        {
            Gizmos.color = Color.green;
            Vector3 direction = rightVision.transform.forward;
            Gizmos.DrawRay(rightVision.transform.position, direction.normalized);
        }

        if (leftVision != null)
        {
            Gizmos.color = Color.red;
            Vector3 direction = leftVision.transform.forward;
            Gizmos.DrawRay(leftVision.transform.position, direction.normalized);
        }

        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    // Update is called once per frame
    void Update()
    {
        timeLine += Time.deltaTime;

        if (status == Status.Childe)
        {
            if (timeLine >= timeToAdult)
            {
                status = Status.Adults;
                StartCoroutine(TimeToGrownUp());
            }
        }

        animalUI.SetAnimalUI(hunger, thirst, reproductive);
    }

    public void UpdateStateOfAnimal(float hungerStats, float thirstStats, float reproductiveStats)
    {

        hunger += Time.deltaTime* hungerStats;

        thirst += Time.deltaTime * 2* thirstStats;

        hunger = Mathf.Clamp(hunger,0, 100);

        thirst = Mathf.Clamp(thirst,0, 100);

        if (status == Status.Adults)
        {
            reproductive += Time.deltaTime* reproductiveStats;
        }
    }

    private void RestartAnimal()
    {
        transform.localScale = chidleScale;

        timeLine = 0;

        thirst = Random.Range(0, 5);

        hunger = Random.Range(0, 4);

        reproductive = 0;

        posMate = Vector3.zero;
        posFood = Vector3.zero;
        posWater = Vector3.zero;

        isEating = false;
        isDrinking = false;
    }

    public bool IsSearchFoodAndDrink()
    {
        float hungerStats = Random.Range(40, 60);
        if (hunger > hungerStats)
        {
            if(posFood != Vector3.zero)
            {
                transform.LookAt(posFood);
            }
        }

        return hunger > hungerStats /*|| thirst > 25*/;
    }

    public void AnimalWalking()
    {

        transform.position += transform.forward * Time.deltaTime * walkSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            posFood = other.transform.position;
            isEating = true;
        }

        if (other.gameObject.tag == "Water")
        {
            posWater = other.transform.position;
            isDrinking = true;
        }
    }

}
