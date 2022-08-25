using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    public float holdLimit = 0.3f;

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
