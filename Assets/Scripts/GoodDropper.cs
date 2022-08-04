using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDropper : Dropper
{
    public int BadTally;
    public int GoodTally;

    public GameObject badDoorTrig;
    public GameObject goodDoorTrig;

    private void Start()
    {
        badDoorTrig.SetActive(false);
        goodDoorTrig.SetActive(false);
    }

    // Start is called before the first frame update
    private void Update()
    {
        if (count >= BadTally)
        {
            badDoorTrig.SetActive(true);
        }
        if (count >= GoodTally)
        {
            goodDoorTrig.SetActive(true);
        }
    }
}
