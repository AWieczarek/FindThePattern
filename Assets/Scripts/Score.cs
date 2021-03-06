using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
	public int _score = 0;

	void Update()
    {
        score.text = _score.ToString();
    }
}
