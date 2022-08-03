using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDropper : Dropper
{
    public GameObject doorTrig;

    private void Start()
    {
        doorTrig.SetActive(false);
    }

    // Start is called before the first frame update
    private void Update()
    {
        if (count >= totalTally)
        {
            doorTrig.SetActive(true);
        }
    }
}
