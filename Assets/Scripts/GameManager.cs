using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	bool isPaused = false;
	public GameObject GameOverUI;
	public GameObject PauseUI;
	public Animator animator;
	public void GameOver()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<SwipeManager>().enabled = false;
		animator.SetBool("GameOver", true);
	}


	public IEnumerator GameOverOpenUI()
	{
		yield return new WaitForSeconds(1f);
		Time.timeScale = 0;
		GameOverUI.SetActive(true);
	}

	public void Pause()
	{
		if(isPaused)
		{
			PauseUI.SetActive(false);
			GameObject.FindGameObjectWithTag("Player").GetComponent<SwipeManager>().enabled = true;
			Time.timeScale = 1;
			isPaused = false;
		}else
		{
			PauseUI.SetActive(true);
			GameObject.FindGameObjectWithTag("Player").GetComponent<SwipeManager>().enabled = false;
			Time.timeScale = 0;
			isPaused = true;
		}
	}

	public void Reset()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
	}
}
