using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformManager platformManager;
    public GameObject destroyedPlatform;

    private void OnEnable()
    {
        platformManager = GameObject.FindObjectOfType<PlatformManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameManager>().GameOver();
    }

	private void OnTriggerExit(Collider other)
	{
        Instantiate(destroyedPlatform, transform.position, transform.rotation);
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Explosion>().ExplosionTrigger();
        Destroy(gameObject);
	}

	void Update()
    {
        if (this.gameObject.transform.position.z <= platformManager.player.position.z - 6f)
        {
            this.gameObject.transform.position += new Vector3(0, 0, 75f);
        } else if (this.gameObject.transform.position.x <= platformManager.player.position.x - (platformManager.wCount * platformManager.offsetChange) - 1.5f)
        {
            this.gameObject.transform.position += new Vector3((platformManager.wCount * platformManager.offsetChange) * 2, 0, 0);
        }
        else if (this.gameObject.transform.position.x >= platformManager.player.position.x + (platformManager.wCount * platformManager.offsetChange) + 1.5f)
        {
            this.gameObject.transform.position -= new Vector3((platformManager.wCount * platformManager.offsetChange)*2, 0, 0);
        }
    }

    
}
