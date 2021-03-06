using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	bool isPaused = false;
	public GameObject GameOverUI;
	public GameObject PauseUI;
	public Animator animator;
	public SwipeManager swipeManager;
	public Score score;
	public TextMeshProUGUI highestScore;
	public GameObject GameMenu;
	public void GameOver()
	{
		swipeManager.enabled = false;
		GameMenu.SetActive(false);
		if (score._score > PlayerPrefs.GetInt("Score"))
		{
			PlayerPrefs.SetInt("Score", score._score);
			highestScore.text = score._score.ToString();
		}else
		{
			highestScore.text = PlayerPrefs.GetInt("Score").ToString();
		}
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
			GameMenu.SetActive(true);
			swipeManager.enabled = true;
			Time.timeScale = 1;
			isPaused = false;
		}else
		{
			PauseUI.SetActive(true);
			GameMenu.SetActive(false);
			swipeManager.enabled = false;
			Time.timeScale = 0;
			isPaused = true;
		}
	}

	public void Reset()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
	}

	public void Play()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		Time.timeScale = 1;
	}
}
