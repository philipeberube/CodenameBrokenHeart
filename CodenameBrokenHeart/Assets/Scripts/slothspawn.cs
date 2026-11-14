using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class slothspawn : MonoBehaviour
{
    [SerializeField] private GameObject sloth;
    [SerializeField] private float spawnInterval = 3.5f;
    [SerializeField] private Transform transformComponentPlayer;
    [SerializeField] private Transform transformComponentFollower;

    Vector3 yoffset;
    float minX = -5f;
    float maxX = 5f;
    float randomX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        StartCoroutine(SpawnRoutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Wait for the specified interval before spawning
            yield return new WaitForSeconds(spawnInterval);


            randomX = Random.Range(minX, maxX);
            yoffset = transformComponentPlayer.position;
            yoffset.y = yoffset.y + 10f;
            yoffset.x = yoffset.x + randomX;
            transformComponentFollower.position = yoffset;

            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            // birth sloth
            Instantiate(sloth, spawnPosition, Quaternion.identity);
        }
    }



}
