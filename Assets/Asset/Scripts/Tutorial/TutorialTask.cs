﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTask : MonoBehaviour {

    public Toggle taskCheck;
    public bool attackCheck;
    public PlayerSkillExecution skillExecution;
    public Transform playerSpawnPoint;
    public List<Toggle> toggleList;
    public TutorialAppear tutorialScript;

    public PlayerScrollSkill skillScroll;
    public int scrollTimes = 0;
    Text text;

    public SceneManager sceneManager;
    public List<actionTimeBar> playerAtbList;
    public List<EnemyActionTimeBar> enemyAtbList;
    public List<GameObject> enemyAimIcon;

    public float wolfDead = 0f;    

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        //skillExecution = playerSpawnPoint.GetChild(0).gameObject.GetComponent<PlayerSkillExecution>();
        skillExecution = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerSkillExecution>();

        if(gameObject.tag == "Player1Toggle")
        {
            //skillExecution = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerSkillExecution>();
            skillExecution = Player1.instance.GetComponent<PlayerSkillExecution>();
        }
        else if(gameObject.tag == "Player2Toggle")
        {
            //skillExecution = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerSkillExecution>();
            skillExecution = Player2.instance.GetComponent<PlayerSkillExecution>();
        }

        //skillScroll = playerSpawnPoint.GetChild(0).gameObject.GetComponent<PlayerScrollSkill>();

        if (gameObject.tag == "Player1Toggle")
        {
            //skillScroll = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScrollSkill>();
            skillScroll = Player1.instance.GetComponent<PlayerScrollSkill>();
        }
        else if (gameObject.tag == "Player2Toggle")
        {
            //skillScroll = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerScrollSkill>();
            skillScroll = Player2.instance.GetComponent<PlayerScrollSkill>();
        }

        text = GetComponentInChildren<Text>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        for(int i=0;i<sceneManager.playerList.Count;i++)
        {
            playerAtbList.Add(sceneManager.playerList[i].GetComponent<actionTimeBar>());
        }
        for (int i = 0; i < sceneManager.enemyList.Count; i++)
        {
            enemyAimIcon.Add(sceneManager.enemyList[i].GetComponent<EnemyVariableManager>().aimIcon);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(tutorialScript.tutorialStage == TutorialAppear.TUTORIAL_STAGE.STAGE_01)
        {
            //! Disabling atb of both enemies and players
            for (int i = 0; i < playerAtbList.Count; i++)
            {
                if(playerAtbList[i].enabled != false)
                {
                    playerAtbList[i].enabled = false;
                }                
            }
            for (int i = 0; i < sceneManager.enemyList.Count; i++)
            {
                if(sceneManager.enemyList[i].GetComponent<EnemyActionTimeBar>().enabled ==true)
                {
                    sceneManager.enemyList[i].GetComponent<EnemyActionTimeBar>().enabled = false;
                }
            }

            for (int i = 0; i < enemyAimIcon.Count; i++)
            {
                if (enemyAimIcon[i].activeInHierarchy == true)
                {
                    enemyAimIcon[i].SetActive(false);
                }
            }

            text.text = "Scroll through skill list " + skillScroll.isScroll.ToString() + "/3";
            if(skillScroll.isScroll >= 3)
            {
                taskCheck.isOn = true;                
            }
        }
        if (tutorialScript.tutorialStage == TutorialAppear.TUTORIAL_STAGE.STAGE_02)
        {
            //! Enabling atb of players
            for (int i = 0; i < playerAtbList.Count; i++)
            {
                if (playerAtbList[i].enabled != true)
                {
                    playerAtbList[i].enabled = true;
                }
            }

            text.text = "Use a skill " + skillExecution.isAttack.ToString() + "/1";
            if (skillExecution.isAttack >= 1)
            {
                taskCheck.isOn = true;
            }
        }

        if(tutorialScript.tutorialStage == TutorialAppear.TUTORIAL_STAGE.STAGE_06)
        {
            text.text = "Kill the wolf";

            if(sceneManager.enemyList.Count <= 0)
            {
                /*if(wolfDead <= 0)
                {
                    wolfDead++;
                    taskCheck.isOn = true;
                }*/
                taskCheck.isOn = true;
            }
        }
    }
}
