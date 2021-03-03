using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public int fCount = 10;
    public int wCount = 2;
    public float offsetChange = 1.5f;
    void Start()
    {
        for (int i = 0; i < fCount; i++)
        {
            for (int j = -wCount; j < wCount; j++)
            {
                Instantiate(platformPrefab, new Vector3(j * offsetChange, 0, i * offsetChange), Quaternion.identity);
            }
        }
    }
}
