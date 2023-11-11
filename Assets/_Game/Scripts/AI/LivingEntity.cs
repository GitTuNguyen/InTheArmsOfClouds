using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    [SerializeField]
    protected Vector3 chidleScale = new Vector3(0.5f,0.5f,0.5f);

    [SerializeField]
    protected Vector3 chidleAdult = new Vector3(0.5f, 0.5f, 0.5f);

    [SerializeField]
    protected SpeciesType species;

    [SerializeField]
    protected Status status;

    public IEnumerator TimeToGrownUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (transform.localScale == chidleAdult)
            {
                break;
            }

            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);

        }

    }
}
