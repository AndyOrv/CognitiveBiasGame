using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

/*
-- Author: Andrew Orvis
-- Description: Class that makes text appear one character at a time starting when specified, used in intro scene
 */

public class TypeWriterEffect : MonoBehaviour
{

	[SerializeField] string fullText;
	[SerializeField] float delay = 0.1f;
	[SerializeField] float startTIme = 0;


	private string currentText = "";
	private bool start = false;



    private void Update()
    {

		if (this.isActiveAndEnabled)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		if (startTIme <= 0.0f && !start)
		{
			start = true;
			StartCoroutine(ShowText());
		}
        else if(startTIme >= 0.0f)
        {
			startTIme -= Time.deltaTime;
		}


	}

    IEnumerator ShowText()
	{
		int offset = 1;
		AudioManager audio = FindObjectOfType<AudioManager>();

		for (int i = 0; i < fullText.Length + offset; i++)
		{
			currentText = fullText.Substring(0, i);
			this.GetComponent<TMP_Text>().text = currentText;
			audio.Play("Pat");
			yield return new WaitForSeconds(delay);
		}
	}
}
