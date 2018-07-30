﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour {

    public List<int> enemyIndexStage;
    public List<Transform> enemySpawnPoints;
    public List<GameObject> allEnemyList;
    public SceneManager sceneManager;
    public int indexInList;    

    private void Awake()
    {
        //! Increase the wave index
        AudioManager.instance.waveIndex++;

        //! Fill the enemy index stage list
        enemyIndexStage = sceneManager.waveDetails[AudioManager.instance.waveIndex].enemiesToSpawn;
        //! Background
        Instantiate(waveDetails[AudioManager.instance.waveIndex].background, Vector3.zero, Quaternion.identity);

        //! Instantiating enemies on specific spawn points based on the size of the enemyIndexStage list.
        indexInList = 0;
        if (enemyIndexStage.Count == 1)
        {
            sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[0]], new Vector2(enemySpawnPoints[1].position.x, enemySpawnPoints[1].position.y), Quaternion.identity, enemySpawnPoints[1]));
            sceneManager.enemyList[0].GetComponent<EnemyStats>().index = 1;
        }
        else if (enemyIndexStage.Count == 2)
        {
            for(int i=0;i<enemyIndexStage.Count;i++)
            {
                sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[i]], new Vector2(enemySpawnPoints[i*2].position.x, enemySpawnPoints[i * 2].position.y), Quaternion.identity, enemySpawnPoints[i * 2]));
                sceneManager.enemyList[i].GetComponent<EnemyStats>().index = i*2;
            }
        }
        else if (enemyIndexStage.Count == 3)
        {
            for (int i = 0; i < enemyIndexStage.Count; i++)
            {
                sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[i]], new Vector2(enemySpawnPoints[i].position.x, enemySpawnPoints[i].position.y), Quaternion.identity, enemySpawnPoints[i]));
                sceneManager.enemyList[i].GetComponent<EnemyStats>().index = i;
            }
        }

        for(int j=0;j<sceneManager.enemyList.Count;j++)
        {
            for (int i = 0; i < sceneManager.enemyList[j].GetComponent<EnemyVariableManager>().skillsPrefab.Count; i++)
            {
                sceneManager.enemyList[j].GetComponent<EnemyVariableManager>().skillList.Add(Instantiate(sceneManager.enemyList[j].GetComponent<EnemyVariableManager>().skillsPrefab[i],sceneManager.enemyList[j].transform));
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        for(int i=0;i<sceneManager.enemyList.Count;i++)
        {
            //sceneManager.enemyList[i].GetComponent<EnemyVariableManager>().audioManager = 
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
