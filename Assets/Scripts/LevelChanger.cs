using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : GameManager
{
    public int from;
    public int to;
    //public bool isTrigger = false;

    public override void firstLoad(){return;}

    public void LevelChange()
    {
        LoadGame((SceneIndexes)from, (SceneIndexes)to);
    }

    //this is used for map triggers where the player will enter an end zone and move to the next level
    public void OnTriggerEnter(Collider other)
    {
        LevelChange();
        Debug.Log("level change");
    }
}
