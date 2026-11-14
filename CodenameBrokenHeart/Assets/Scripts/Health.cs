using UnityEngine;

public class Health : MonoBehaviour
{


    [SerializeField] public int maximumHealth = 5;
    [SerializeField] public int currentHealth;
    [SerializeField] public bool isDead = false;


    void Start()
    {
        currentHealth = maximumHealth;
    }


    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
        else if (currentHealth < 0) 
        {
            currentHealth = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            isDead = true;
        }


    }
}
