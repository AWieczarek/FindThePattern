using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public GameManager gm;
    public void ExplosionTrigger()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, 8);

		foreach (Collider nearby in colliders)
		{
			Rigidbody rig = nearby.GetComponent<Rigidbody>();
			if (rig != null)
			{
				rig.AddExplosionForce(100, gameObject.transform.position, 8);
			}
		}
		StartCoroutine(gm.GameOverOpenUI());
	}
}
