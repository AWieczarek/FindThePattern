using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
	public TextMeshProUGUI score;
	public TextMeshProUGUI highestScore;
	public int _score = 0;

	private void Start()
	{
		highestScore.text = PlayerPrefs.GetInt("Score").ToString();
	}

	private void Update()
	{
		score.text = _score.ToString();
	}
}
