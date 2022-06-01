using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject door;
    public int upheight;

    bool isOpened = false;

    void OnTriggerEnter(Collider other)
    {
        if(!isOpened)
        {
            isOpened = true;
            door.transform.position = new Vector3(0,upheight,0);
        }
    }
}