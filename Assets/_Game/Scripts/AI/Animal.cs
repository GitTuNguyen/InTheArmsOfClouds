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

    [SerializeField]
    public BoxCollider bigBoxCollider;

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

        thirst += Time.deltaTime * thirstStats;

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

        thirst = Random.Range(0, 20);

        hunger = Random.Range(0, 20);

        reproductive = 0;

        posMate = Vector3.zero;
        posFood = Vector3.zero;
        posWater = Vector3.zero;
    }
    public int hungerStats;
    public int thirstStats;
    public bool IsSearchFoodAndDrink()
    {
        if (hunger > hungerStats || thirst > thirstStats)
        {
            if(posFood != Vector3.zero && hunger > hungerStats)
            {
                transform.LookAt(posFood);
            }

            if(posWater != Vector3.zero && thirst > thirstStats)
            {
                transform.LookAt(new Vector3(posWater.x,1,posWater.z));
            }
        }

        return hunger > hungerStats || thirst > thirstStats;
    }

    public void CheckEnableBigBoxCollider()
    {
        if(posFood == Vector3.zero)
        {
            bigBoxCollider.enabled = true;
        }
        else
        {
            bigBoxCollider.enabled = false;
        }
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
        }

        if (other.gameObject.tag == "Water")
        {
            posWater = other.transform.position;
        }
    }

}
