using UnityEngine;

public class BackgroundController : MonoBehaviour 
{
    public float startPos;
    public GameObject cam;
    public float parallaxEffect;
    private void Start()
    {
        startPos = transform.position.x;
    }
    private void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z); 
        
    }
}
