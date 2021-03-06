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
	public GameObject GameMenuUI;
	public GameObject OptionsUI;
	public Animator animator;
	public SwipeManager swipeManager;
	public Score score;
	public TextMeshProUGUI highestScore;
	bool gameOver = false;
	public void GameOver()
	{
		swipeManager.enabled = false;
		gameOver = true;
		GameMenuUI.SetActive(false);
		animator.SetBool("GameOver", true);
		if(score._score>PlayerPrefs.GetInt("Score"))
		{
			PlayerPrefs.SetInt("Score", score._score);
			highestScore.text = score._score.ToString();
		}
	}

	public IEnumerator GameOverOpenUI()
	{
		yield return new WaitForSeconds(1f);
		Time.timeScale = 0;
		GameOverUI.SetActive(true);
		GameMenuUI.SetActive(false);
	}

	public void Pause()
	{
		if(isPaused)
		{
			PauseUI.SetActive(false);
			GameMenuUI.SetActive(true);
			swipeManager.enabled = true;
			Time.timeScale = 1;
			isPaused = false;
		}else
		{
			PauseUI.SetActive(true);
			GameMenuUI.SetActive(false);
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

	public void PauseToOptions()
	{
		PauseUI.SetActive(false);
		OptionsUI.SetActive(true);
	}

	public void GOToOptions()
	{
		GameOverUI.SetActive(false);
		OptionsUI.SetActive(true);
	}

	public void Back()
	{
		if (gameOver)
		{
			GameOverUI.SetActive(true);
			OptionsUI.SetActive(false);
		}
		else
		{
			PauseUI.SetActive(true);
			OptionsUI.SetActive(false);
		}
	}
}
