using UnityEngine;

public class followaboveplayer : MonoBehaviour
{
    [SerializeField] private Transform transformComponentPlayer;
    [SerializeField] private Transform transformComponentFollower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    Vector3 yoffset;
    float minX = -5f;
    float maxX = 5f;
    float randomX;

    // Update is called once per frame
    void Update()
    {

        randomX = Random.Range(minX, maxX);
        yoffset = transformComponentPlayer.position;
        yoffset.y = yoffset.y + 5f;
        yoffset.x = yoffset.x + randomX;
        transformComponentFollower.position = yoffset;

        

        
    }
}
