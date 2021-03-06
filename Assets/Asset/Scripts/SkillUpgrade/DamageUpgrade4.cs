﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade4 : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = 130;
        effectDescription = "Damage and slow single enemy";
    }

    public override void Execute(GameObject targetedEnemy)
    {
        int totalDamage = (int)(damage * DamageMultiplier());
        targetedEnemy.GetComponent<EnemyTakeDamage>().EnemyDamage(totalDamage);
        targetedEnemy.GetComponent<EnemyVariableManager>().statusList.Add(Instantiate(status[0]));
    }
}
