using UnityEngine;

public class ToggleBarrier : MonoBehaviour
{
    public GameObject barrier;
    public SpriteRenderer switchRenderer;

    public Sprite switchOnSprite;
    public Sprite switchOffSprite;

    public bool isBarrierEnabled = true;
    public KeyCode interactKey = KeyCode.Z;

    private bool playerInRange = false;
    

    
    void Start()
    {
        if (switchRenderer == null)
        {
            switchRenderer = GetComponent<SpriteRenderer>();
        }
        UpdateBarrierAndSprite();

    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            isBarrierEnabled = !isBarrierEnabled;

            UpdateBarrierAndSprite();

        }  
    }

    void UpdateBarrierAndSprite()
    {
        if (barrier != null)
        {
            barrier.SetActive(isBarrierEnabled);
        }

        if  (switchRenderer != null)
        {
            switchRenderer.sprite = isBarrierEnabled ? switchOnSprite : switchOffSprite;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
