﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUpgrade : MonoBehaviour
{
    private int progressIndex;
    public GameObject heal1;
    public GameObject heal2;
    public GameObject heal3;
    public GameObject heal4;
    public GameObject damage1;
    public GameObject damage2;
    public GameObject damage3;
    public GameObject damage4;
    public GameObject support1;
    public GameObject support2;
    public GameObject support3;
    public GameObject support4;
    public GameObject support5;

    public GameObject randomHeal()
    {
        int rand = Random.Range(1, 101);
        GameObject upgrade = new GameObject();
        if(progressIndex == 1)
        {
            if (rand > 0 && rand <= 50)
            {
                upgrade = heal1;
            }
            else if (rand > 50 && rand <= 90)
            {
                upgrade = heal2;
            }
            else if (rand > 90 && rand <= 100)
            {
                upgrade = heal3;
            }
        }
        if (progressIndex == 2)
        {
            if (rand > 0 && rand <= 50)
            {
                upgrade = heal1;
            }
            else if (rand > 50 && rand <= 75)
            {
                upgrade = heal2;
            }
            else if (rand > 75 && rand <= 80)
            {
                upgrade = heal3;
            }
            else if(rand > 80 && rand <= 100)
            {
                upgrade = heal4;
            }
        }
        return upgrade;
    }

    public GameObject randomAttack()
    {
        int rand = Random.Range(1, 101);
        GameObject upgrade = new GameObject();
        if(rand > 0 && rand <= 30)
        {
            upgrade = damage1;
        }
        else if (rand > 30 && rand <= 60)
        {
            upgrade = damage2;
        }
        else if(rand > 60 && rand <= 80)
        {
            upgrade = damage3;
        }
        else if (rand > 80 && rand <= 100)
        {
            upgrade = damage4;
        }
        return upgrade;
    }

    public GameObject randomSupport()
    {
        int rand = Random.Range(1, 101);
        GameObject upgrade = new GameObject();
        if (rand > 0 && rand <= 30)
        {
            upgrade = support1;
        }
        else if (rand > 30 && rand <= 50)
        {
            upgrade = support2;
        }
        else if (rand > 50 && rand <= 70)
        {
            upgrade = support3;
        }
        else if (rand > 70 && rand <= 90)
        {
            upgrade = support4;
        }
        else if(rand > 90 && rand <= 100)
        {
            upgrade = support5;
        }
        return upgrade;
    }
}