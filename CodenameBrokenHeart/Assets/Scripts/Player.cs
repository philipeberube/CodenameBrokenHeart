using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = .1f;
    [SerializeField] private Transform transformComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
                       
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transformComponent.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transformComponent.position -= new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transformComponent.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transformComponent.position -= new Vector3(0, speed, 0);
        }
        
    }
}
