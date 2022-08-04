using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public int count = 0;

    public Material changeColour;
    public GameObject[] marks;

    /*
    private void Start()
    {
        doorTrig.SetActive(false);
    }

    // Start is called before the first frame update
    private void Update()
    {
        if(count >= totalTally)
        {
            doorTrig.SetActive(true);
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "GameCube")
        {
            ColourChange(marks[count]);
            count++;

            Debug.Log(count);
        }
    }

    private void ColourChange(GameObject mar)
    {
        mar.GetComponent<Renderer>().sharedMaterial = changeColour;
    }
}
