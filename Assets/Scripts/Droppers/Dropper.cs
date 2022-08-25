using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public int count = 0;

    public Material changeColour;
    public GameObject[] marks;

    private string[] drops = new string[] { "Drop1", "Drop2", "Drop3", "Drop4", "Drop5" };
    int index;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "GameCube")
        {
            ColourChange(marks[count]);
            count++;
            index = Random.Range(0, drops.Length);
            //Debug.Log(drops[index]);
            FindObjectOfType<AudioManager>().Play(drops[index]);
            //Debug.Log(count);
        }
    }

    private void ColourChange(GameObject mar)
    {
        mar.GetComponent<Renderer>().sharedMaterial = changeColour;
    }
}
