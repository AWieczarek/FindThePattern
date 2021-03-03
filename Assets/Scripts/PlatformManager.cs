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

        for (int j = -wCount; j < wCount; j++)
        {
            int x = EmptyPosition();
            platforms[x, j + wCount].GetComponent<Renderer>().material.color = Color.green;
            platforms[x, j + wCount].GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    public int EmptyPosition()
	{
        return Random.Range(5, 19);
	}
}
