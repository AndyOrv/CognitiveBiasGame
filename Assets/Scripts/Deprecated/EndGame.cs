using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    [SerializeField] int from;
    [SerializeField] int to;
    //public bool isTrigger = false;


    public void LevelChange()
    {
        FindObjectOfType<GameManager>().LoadGame((SceneIndexes)from, (SceneIndexes)to);
    }

    //this is used for map triggers where the player will enter an end zone and move to the next level
    public void OnTriggerEnter(Collider other)
    {
        LevelChange();
        Debug.Log("level change");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}







