﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : StatusDetail {

    private void Awake()
    {
        effect = false;
        isActive = true;
        secondDuration = 10;
        type = "Good";
        ID = 6;
    }

    public override void DoEffect()
    {
        if (secondDuration == 10)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStatusList>().statusIcon.Add(this.icon);
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStatusList>().statusIcon.Add(this.icon);
            }
        }
        else if (secondDuration <= 0)
        {
            isActive = false;
            RemoveStatus();
        }
        if (!effect)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<actionTimeBar>().timeRequired -= 1f;
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyVariableManager>().maxCooldown -= 1f;
            }
            effect = true;
        }
        secondDuration-=Time.deltaTime;
        
    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<actionTimeBar>().timeRequired += 1f;
            user.GetComponent<PlayerStatusList>().statusIcon.Remove(user.GetComponent<PlayerStatusList>().statusIcon.Find(x => x == this.icon));
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStatusList>().statusIcon.Remove(user.GetComponent<EnemyStatusList>().statusIcon.Find(x => x == this.icon));
            user.GetComponent<EnemyVariableManager>().maxCooldown += 1f;
        }
        effect = false;
    }
}
