using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
	public GameObject MusicToogleForeground;
	public GameObject SoundsToogleForeground;
	public GameObject OptionsUI;
	public GameObject MenuUI;
	bool music = true;
	bool sounds = true;
	public void ONOFFMusic()
	{
		if(music)
		{
			MusicToogleForeground.transform.position -= new Vector3(90, 0, 0);
			music = false;
		}
		else
		{
			MusicToogleForeground.transform.position += new Vector3(90,0,0);
			music = true;
		}
	}
	public void ONOFFSounds()
	{
		if (sounds)
		{
			SoundsToogleForeground.transform.position -= new Vector3(90, 0, 0);
			sounds = false;
		}
		else
		{
			SoundsToogleForeground.transform.position += new Vector3(90, 0, 0);
			sounds = true;
		}
	}

	public void BackToMenu()
	{
		OptionsUI.SetActive(false);
		MenuUI.SetActive(true);
	}

	public void OpenOptions()
	{
		OptionsUI.SetActive(true);
		MenuUI.SetActive(false);
	}
}
