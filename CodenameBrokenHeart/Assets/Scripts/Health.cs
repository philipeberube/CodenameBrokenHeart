using UnityEngine;

public class Health : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] public int hp;
=======

    [SerializeField] int maximumHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] bool isDead = false;

>>>>>>> Stashed changes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
