using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject door;
    public int upheight;
    private Vector3 startPoint;

    bool isOpened = false;

    private void Start()
    {
        startPoint = door.transform.position;
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        if(!isOpened)
        {
            isOpened = true;
            door.transform.position = new Vector3(0,upheight,0);
        }

    }
    */
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("door opened");

        if (other.attachedRigidbody)
        {
            door.transform.position = new Vector3(0, upheight, 0);
        }
    }

    //private void Update()
    //{
    //   door.transform.position = startPoint;
    //}
}