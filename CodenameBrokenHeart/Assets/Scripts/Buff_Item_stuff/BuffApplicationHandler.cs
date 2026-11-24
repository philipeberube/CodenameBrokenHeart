using NUnit.Framework;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BuffApplicationHandler : MonoBehaviour
{

    [SerializeField] List<BuffItem> appliedBuffs = new List<BuffItem>();
    [SerializeField] Player player;
    [SerializeField] int healthBonusTotal;
    [SerializeField] float speedBonusTotal;
    [SerializeField] int damageBonusTotal;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetBonuses();
        player = GetComponent<Player>();

        

    }



    void SetBonuses()
    {

        //checking inventory for any plates that were recently changed to active
        foreach (BuffItem item in player.plateInventory)
        {
            if (item.isApplied && !appliedBuffs.Find(x => x.id == item.id))
            {
                appliedBuffs.Add(item);
            }
        }

        //verifying that all the bonuses applied are actually declared as active
        foreach (BuffItem item in appliedBuffs)
        {
            item.isAlreadyAdded = false;
            if (!item.isApplied)
            {
                switch (item.type)
                {
                    case BuffItemType.HealthBuff:
                        healthBonusTotal -= Convert.ToInt32(item.buffAmt);
                        break;
                    case BuffItemType.SpeedBuff:
                        speedBonusTotal -= item.buffAmt;
                        break;
                    case BuffItemType.DamageBuff:
                        damageBonusTotal += Convert.ToInt32(item.buffAmt);
                        break;
                }
                appliedBuffs.Remove(item);
            }
        }

        //applying the remaining bonuses whhile verifying they arent already there
        foreach (BuffItem b in  appliedBuffs)
        {
            if (!b.isAlreadyAdded)
            {
                switch (b.type)
                {
                    case BuffItemType.HealthBuff:
                        healthBonusTotal += Convert.ToInt32(b.buffAmt);
                        break;
                    case BuffItemType.SpeedBuff:
                        speedBonusTotal += b.buffAmt;
                        break;
                    case BuffItemType.DamageBuff:
                        damageBonusTotal += Convert.ToInt32(b.buffAmt);
                        break;
                }
            }

        }
    }

    void ApplyBonusToStats()
    {
        player.health.maxHealthTotal += healthBonusTotal;
        player.speed += speedBonusTotal;
        //player.attack.damage += damageBonusTotal;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
