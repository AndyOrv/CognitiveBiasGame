using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Simple door mecanisn to move door towards a given postion
 */


public class DoorTrigger : MonoBehaviour
{
    [SerializeField] bool willClose = true;
    [SerializeField] GameObject Door;
    [SerializeField] GameObject DoorOpen;
    [SerializeField] bool isOpened = false;
    [SerializeField] float moveSpeed = 3;
    [SerializeField] float rotationSpeed = 90;

    // this will be a copy of the original door so that we have some numbers to work with.
    private GameObject DoorClosed;

    private bool done = false;

    void Start()
    {
        // copy the door to keep its position
        DoorClosed = Instantiate(Door, Door.transform.position, Door.transform.rotation);
        // hide both the open and closed door
        DoorClosed.SetActive(false);
        DoorOpen.SetActive(false);
    }

    void Update()
    {
        // every frame, move the door towards the Open/Closed door
        var target = isOpened ? DoorOpen : DoorClosed;

        Door.transform.position = Vector3.MoveTowards(Door.transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        Door.transform.rotation = Quaternion.RotateTowards(Door.transform.rotation, target.transform.rotation, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider cube)
    {

        isOpened = true;
        if (!done)
        {
            FindObjectOfType<AudioManager>().Play("Door");
            done = true;
        }

    }

    void OnTriggerExit(Collider cube)
    {
        // whenever anything exits the trigger, close the door.
        if (willClose)
        {
            isOpened = false;
        }
    }
}
