﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceSkeletonChargeAttack : SkillEffect {

    private void Awake()
    {
        AssignEnemyUser();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        int totalDamage = (int)(damage * DamageMultiplier());
        targetedEnemy.GetComponent<PlayerTakeDamage>().PlayerDamage(totalDamage);
        if(!targetedEnemy.GetComponent<PlayerStats>().immune)
        {
            targetedEnemy.GetComponent<PlayerVariableManager>().statusList.Add(Instantiate(status[0]));
        }
    }
}
