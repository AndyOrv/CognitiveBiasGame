using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShifter : MonoBehaviour
{

    public bool isUpDown = true; //defualt the cube shifter to up down movement

    public GameObject theCube;

    public float rotationSpeed = 1;

    private bool startrotating;
    private bool rotating;

    //public GameObject failTrigger;

    private void Start()
    {
        //failTrigger.SetActive(false);
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t <= 1; t += Time.deltaTime / inTime)
        {
            theCube.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);

            yield return null;
        }

        transform.rotation = toAngle;
        rotating = false;
        startrotating = false;
    }

    private void OnMouseUpAsButton()
    {
        if (!rotating)
        {
            startrotating = true;
        }

        //failTrigger.SetActive(true);
    }

    private void Update()
    {
        if(startrotating && !rotating && isUpDown)
        {
            rotating = true;
            StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
        }
        if (startrotating && !rotating && !isUpDown)
        {
            rotating = true;
            StartCoroutine(RotateMe(Vector3.right * 90, 0.8f));
        }

        if (Input.GetKeyDown("e"))
        {
            Debug.Log(theCube.transform.rotation.eulerAngles);
        }

    }
}
