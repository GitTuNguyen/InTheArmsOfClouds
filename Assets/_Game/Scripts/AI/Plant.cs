using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plant : LivingEntity,IPointerClickHandler
{
    [SerializeField]
    private int verdancy;

    [SerializeField]
    private float timeToAdult;

    private float timeLine;
    // Start is called before the first frame update
    void Start()
    {
       ResetLiving();
    }

    // Update is called once per frame
    void Update()
    {
        if(status == Status.Childe) 
        {
            timeLine += Time.deltaTime;
            if(timeLine >= timeToAdult)
            {
                // Grown-up
                GrownUp();
                status = Status.Adults;
            }
        }

        if(status == Status.Adults) {
            if (verdancy <= 0)
            {
                status = Status.Sleeping;
                timeLine = 0;
                Die();
            }
        }

        if(status == Status.Sleeping)
        {
            timeLine += Time.deltaTime;

            if(timeLine >= timeToAdult)
            {
                ResetLiving();
            }
        }
    }

    private void ResetLiving()
    {
        status = Status.Childe;

        transform.localScale = chidleScale;

        verdancy = 0;

        timeLine = 0;

    }

    private void GrownUp()
    {
        // Scale up
        StartCoroutine(TimeToGrownUp());

        verdancy = 10;
    }

    IEnumerator TimeToDie()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (transform.localScale == Vector3.zero)
            {
                break;
            }

            transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);

        }

    }

    private void Die()
    {
        StartCoroutine(TimeToDie());
        verdancy = 0;
    }

    private void LoseVerdancy(int value)
    {
        verdancy -= value;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        LoseVerdancy(5);
        Debug.Log("Tale damage");
    }
}
