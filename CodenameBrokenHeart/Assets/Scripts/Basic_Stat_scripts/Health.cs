using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{


    [SerializeField] public int maximumHealth = 5; //for player: this will be used as a baseline as default health amt
    [SerializeField] public int currentHealth;
    [SerializeField] public bool isDead = false;
    [SerializeField] UnityEvent onDeath;
    [SerializeField] UnityEvent onTakeDamage;


    void Start()
    {
        currentHealth = maximumHealth;
    }

    /*
    public void RegenerateHealth(int amount)
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
    }*/

    public void TakeDamage(int dmg)
    {
        this.currentHealth -= dmg;
        onTakeDamage.Invoke();

    }
    protected virtual void Die()
    {
        onDeath.Invoke();
        Destroy(this.gameObject);
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
