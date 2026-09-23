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
        bool rightIsPressed = Input.GetKey(KeyCode.RightArrow);
        bool leftIsPressed = Input.GetKey(KeyCode.LeftArrow);
        bool upIsPressed = Input.GetKey(KeyCode.UpArrow);
        bool downIsPressed = Input.GetKey(KeyCode.DownArrow);

        if (rightIsPressed)
        {
            transformComponent.position += new Vector3(speed, 0, 0);

        }
        if (leftIsPressed)
        {
            transformComponent.position += new Vector3(-speed, 0, 0);
        }
        if (upIsPressed)
        {
            transformComponent.position += new Vector3(0, speed, 0);
        }
        if (downIsPressed)
        {
            transformComponent.position += new Vector3(0, -speed, 0);
        }
        else
        {
            transformComponent.position += new Vector3(0, 0, 0);
        }

    }
}
