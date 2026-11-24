using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] public int maxHealthTotal; //Max health + buffs

    public void Heal(int healingAmt)
    {
        currentHealth += healingAmt;
    }

    protected override void Die()
    {
        base.Die();

    }
}
