using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform posPlayer;

    private Vector3 offset;

    private float fieldOfViewMinimum = 40;

    private float fieldOfViewMaximum = 60;

    [SerializeField]
    private float speedZoom = 30;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - posPlayer.position;
        //fieldOfView = Camera.main.fieldOfView;
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            Camera.main.fieldOfView += Time.deltaTime * speedZoom;
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            Camera.main.fieldOfView -= Time.deltaTime * speedZoom;
        }

        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, fieldOfViewMinimum, fieldOfViewMaximum);
    }

    private void LateUpdate()
    {
        Vector3 newPos = posPlayer.position + offset;
        transform.position = newPos;
    }
}
