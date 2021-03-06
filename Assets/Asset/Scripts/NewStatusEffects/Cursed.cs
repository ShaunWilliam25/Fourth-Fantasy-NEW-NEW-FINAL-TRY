﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursed : StatusDetail
{
    private void Awake()
    {
        isActive = true;
        secondDuration = 3;
        type = "Bad";
        ID = 10;
    }

    public override void DoEffect()
    {
        if (secondDuration == 3)
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
        }
       
        secondDuration-=Time.deltaTime;

    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStatusList>().statusIcon.Remove(user.GetComponent<PlayerStatusList>().statusIcon.Find(x => x == this.icon));
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStatusList>().statusIcon.Remove(user.GetComponent<EnemyStatusList>().statusIcon.Find(x => x == this.icon));
        }
    }
}
