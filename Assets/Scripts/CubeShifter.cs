using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Class for rotating the cubes sidesways in level 3
 */

public class CubeShifter : MonoBehaviour
{

    public bool isUpDown = true; //defualt the cube shifter to up down movement

    public GameObject theCube;

    public float rotationSpeed = 1;

    private bool startrotating;
    private bool rotating;

    //rotate cube
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

    //button to activate the spin uses mouse down
    private void OnMouseUpAsButton()
    {
        if (!rotating)
        {
            startrotating = true;
        }

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
    }
}
