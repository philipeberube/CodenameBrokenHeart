using UnityEngine;

public class BuffHealth : BuffItem
{
    public override void ApplyBuff()
    {
        this.gameObject.GetComponent<Health>().maximumHealth += 1;
        this.gameObject.GetComponent<Health>().currentHealth += 1;
    }
}
