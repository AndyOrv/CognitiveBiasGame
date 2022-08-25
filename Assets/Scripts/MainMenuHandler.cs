using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject helpMenu;
    public GameObject credits;

    private void Start()
    {
        optionsMenu.SetActive(false);
        helpMenu.SetActive(false);
        credits.SetActive(false);
    }
    public void openOptions(){
        optionsMenu.gameObject.SetActive(true);
        closeHelp();
        closeCredits();
    }
    public void closeOptions(){optionsMenu.gameObject.SetActive(false);}
    public void openHelp(){
        helpMenu.gameObject.SetActive(true);
        closeOptions();
        closeCredits();
    }
    public void closeHelp() { helpMenu.gameObject.SetActive(false); }
    public void openCredits(){
        credits.gameObject.SetActive(true);
        closeHelp();
        closeOptions();
    }
    public void closeCredits() { credits.gameObject.SetActive(false); }

}
