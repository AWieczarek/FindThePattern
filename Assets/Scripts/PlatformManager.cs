using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public int fCount = 100;
    public int wCount = 20;
    public float offsetChange = 1.5f;
    private GameObject[,] platforms;
    int step = 0;
    int level = 2;
    int pom = 0;
    void Start()
    {
        platforms = new GameObject[fCount, wCount*2];
        for (int i = 0; i < fCount; i++)
        {
            for (int j = -wCount; j < wCount; j++)
            {
                platforms[i,j+wCount] = Instantiate(platformPrefab, new Vector3(j * offsetChange, 0, i * offsetChange), Quaternion.identity);
            }
        }
    }

	private void Update()
	{
		if(player.position.z > pom)
		{
			for (int i = 0; i < level; i++)
			{
                Holes();
            }

            if (step == 80)
            {
                step = 0;
                level++;
            }
            else if (step == 40)
            {
                step += 20;
                pom += 20;
                level++;
            }
            else
            {
                step += 20;
                pom += 20;
            }
        }

        
    }

	public int EmptyPosition()
	{
        return Random.Range(2 + step, 20 + step);
	}

    void Holes()
	{
        for (int j = -wCount; j < wCount; j++)
        {
            int x = EmptyPosition();
            platforms[x, j + wCount].GetComponent<Renderer>().material.color = Color.green;
            platforms[x, j + wCount].GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
