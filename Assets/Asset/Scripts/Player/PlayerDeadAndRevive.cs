﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadAndRevive : MonoBehaviour {

    public PlayerStats playerStats;
    public PlayerVariableManager playerVariable;
    public float reviveAnimationTimer;
    public Color originalColour;
	// Use this for initialization
	void Start ()
    {
        originalColour = GetComponentInChildren<SpriteRenderer>().color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerStats = GetComponent<PlayerStats>();
        playerVariable = GetComponent<PlayerVariableManager>();
        if (playerStats.health <= 0 && playerStats.knockedOut == false)
        {
            playerVariable.statusList.Clear();
            GetComponent<PlayerStatusList>().statusIcon.Clear();
            GetComponent<actionTimeBar>().timeRequired = 3f;
            playerStats.Reset();
            playerStats.knockedOut = true;
            playerStats.reviveAction = 3;
            playerVariable.GetComponent<PlayerScrollSkill>().enabled = false;
            playerVariable.GetComponent<PlayerSkillChooseTarget>().enabled = false;
            playerVariable.GetComponent<PlayerSkillExecution>().enabled = false;
            playerVariable.GetComponent<PlayerTakeDamage>().enabled = false;
            playerVariable.GetComponent<PlayerStatusUpdate>().enabled = false;
            GetComponent<PlayerSkillExecution>().CancelInvoke();
            GetComponent<PlayerTakeDamage>().CancelInvoke();
            GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(GetComponent<PlayerVariableManager>().deathAnimation);
        }
        if(playerStats.knockedOut == true && (playerStats.reviveAction <=0 || playerStats.autoRevive))
        {
            playerStats.knockedOut = false;
            playerStats.reviveAction = 0;
            playerStats.autoRevive = false;
            playerStats.health = playerStats.baseHealth;
            playerVariable.statusList.Clear();
            GetComponent<PlayerStatusList>().statusIcon.Clear();
            playerVariable.GetComponent<actionTimeBar>().startSelection = 0;
            playerVariable.GetComponent<PlayerScrollSkill>().enabled = true;
            playerVariable.GetComponent<PlayerSkillChooseTarget>().enabled = true;
            playerVariable.GetComponent<PlayerSkillExecution>().enabled = true;
            GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(GetComponent<PlayerVariableManager>().reviveAnimation);
            playerVariable.GetComponent<PlayerStatusUpdate>().enabled = true;
            Invoke("ResetAnimation", reviveAnimationTimer);
        }
	}

    void ResetAnimation()
    {
        this.GetComponent<PlayerVariableManager>().anim.GetComponent<Animator>().Play(this.GetComponent<PlayerVariableManager>().idleAnimation);
    }
}
