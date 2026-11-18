using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public Collider2D dmgCol;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        health.TakeDamage(damage);
    }
}
