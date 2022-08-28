using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Attachment to object giving the player the capability to pick them up and walk them around
 */

public class PickUp : MonoBehaviour
{
    [SerializeField] Transform theDest;
    [SerializeField] float holdLimit = 0.3f;

    private void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("HoldPosition").transform;

        //need to stop any movement on pick up
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().freezeRotation = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    private void Update()
    {
        Holdlimit();
    }

    //if object gets seperated from player via hitting a wall etc., this method is a threshold before the the item is dropped
    void Holdlimit()
    {
        if (Mathf.Abs(this.transform.position.x - theDest.position.x) > holdLimit || Mathf.Abs(this.transform.position.y - theDest.position.y) > holdLimit)
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().freezeRotation = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}
