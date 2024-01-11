using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platformblock;
    public int maxPlatformCount = 5;
    public int currentPlatformCount = 0;
    public float zPos;
    public float blockLength = 10;
    public List<GameObject> generatedTiles;

    public Transform player;
    public TMP_Text distanceText;

    private void Start()
    {
        generatedTiles = new List<GameObject>();
        GeneratePlatform();
        

    }
    private void Update()
    {
        CheckDistance();
        distanceText.text = Mathf.FloorToInt(player.transform.position.z).ToString();
    }
    public void CheckDistance()
    {
        if (Mathf.Abs(player.transform.position.z - zPos) < 100)
        {
            DestroyBlocks();
            GeneratePlatform();
        }
    }
    public void DestroyBlocks()
    {
        if (generatedTiles.Count > 0)
        {
            GameObject blockToRemove = generatedTiles[0]; // Get the first block in the list
            generatedTiles.RemoveAt(0); // Remove it from the list
            Destroy(blockToRemove); // Destroy the GameObject
            currentPlatformCount--;
        }
    }
    public void GeneratePlatform()
    {
        for(int i = currentPlatformCount; i < maxPlatformCount; i++)
        {
            GameObject block = Instantiate(platformblock[Random.Range(0,platformblock.Length)], new Vector3(0, 0, zPos), Quaternion.identity);
            generatedTiles.Add(block);
            zPos += blockLength;
            currentPlatformCount++;
        }
    }
}
