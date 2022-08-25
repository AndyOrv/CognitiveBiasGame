using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    private bool swapStates = false;
    private GameObject player;

    private void Start()
    {
        pauseMenu.SetActive(swapStates);
    }

    public void pauseState()
    {
        swapStates = !swapStates;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseState();
            pauseMenu.SetActive(swapStates);

            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().notPaused = swapStates;

        }
    }
}
