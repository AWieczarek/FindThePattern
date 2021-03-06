using System.Collections;
using UnityEngine;
public class MenuManager : MonoBehaviour
{
    private GameObject[,] platforms;
    public GameObject platformPrefab;
    public Material defaultMaterial;
    int height = 101, width = 41;
    public float offsetChange = 1.5f;
    void Start()
    {
        platforms = new GameObject[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                platforms[i, j] = Instantiate(platformPrefab, new Vector3((j * offsetChange)-(Mathf.Floor(width/2)*offsetChange), 0, (i * offsetChange) - (Mathf.Floor(height / 2) * offsetChange)), Quaternion.identity);
            }
        }
        StartCoroutine(ChangePattern());
    }

    void Update()
    {
        
    }

    IEnumerator ChangePattern()
	{
        while (true)
        {
            for (int i = 0; i < height; i++)
            {
				for (int j = 0; j < width; j++)
				{
                    platforms[i, j].GetComponent<Renderer>().material.color = defaultMaterial.color;
				}
            }

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < width; j++)
                { 
                    platforms[Random.Range(0, height), j].GetComponent<Renderer>().material.color = Color.green;
                }
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}
