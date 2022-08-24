using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMix;

    Resolution[] resolutions;

    public TMPro.TMP_Dropdown resoDropDown;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resoDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResoIndex = 0;
        for(int i =0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResoIndex = i;
            }
        }

        resoDropDown.AddOptions(options);
        resoDropDown.value = currentResoIndex;
        resoDropDown.RefreshShownValue();
    }

    public void setResolution (int resolutionIndex)
    {
        Resolution reso = resolutions[resolutionIndex];

        Screen.SetResolution(reso.width, reso.height, Screen.fullScreen);
    }

    public void SetVolume (float vol)
    {
        audioMix.SetFloat("volume", vol);
    }

    public void setQuality (int Qindex)
    {
        QualitySettings.SetQualityLevel(Qindex);
    }

    public void SetFUllscreen (bool isFull)
    {
        Screen.fullScreen = isFull;
    }
}
