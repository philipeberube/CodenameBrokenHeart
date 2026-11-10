using UnityEngine;

public class BuffHealth : BuffItem
{
    public override void ApplyBuff()
    {
        this.gameObject.GetComponent<Health>().hp += 1;
    }
}
