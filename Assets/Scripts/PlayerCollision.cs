using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public GameObject player;
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Finish")
		{
			Time.timeScale = 0;
			player.GetComponent<SwipeManager>().enabled = false;
		}
	}
}
