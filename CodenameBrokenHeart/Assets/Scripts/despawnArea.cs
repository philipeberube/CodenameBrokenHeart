using UnityEngine;

public class despawnArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }




}
