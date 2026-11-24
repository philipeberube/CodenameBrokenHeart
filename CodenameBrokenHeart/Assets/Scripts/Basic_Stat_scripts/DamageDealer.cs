using Assets.Scripts.Game_Management_Scripts;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] public int maxDmg;
    [SerializeField] public int minDmg;
    [SerializeField] public Collider2D dmgCol;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        health.TakeDamage(RNG.Instance.Next(minDmg, maxDmg + 1));
    }
}
