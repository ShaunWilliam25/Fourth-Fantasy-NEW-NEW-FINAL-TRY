﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour {

    public List<int> enemyIndexStage;
    public List<Transform> enemySpawnPoints;
    public List<GameObject> allEnemyList;
    public SceneManager sceneManager;
    public int indexInList;
    [SerializeField] bool isEnemySpawn = false;

    private void Awake()
    {
        isEnemySpawn = false;       
        
    }

    // Use this for initialization
    void Start ()
    {
        //! Increase the wave index
        AudioManager.instance.waveIndex++;

        //! Fill the enemy index stage list
        enemyIndexStage = sceneManager.waveDetails[AudioManager.instance.waveIndex].enemiesToSpawn;

        //! Random skeletons for skeleton wave(wave 2)
        if(AudioManager.instance.waveIndex == 2)
        {
            for(int i=0;i<3;i++)
            {
                enemyIndexStage[i] = Random.Range(1,4);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(!isEnemySpawn)
        {
            //! Background
            Instantiate(sceneManager.waveDetails[AudioManager.instance.waveIndex].background, Vector3.zero, Quaternion.identity);

            //! Instantiating enemies on specific spawn points based on the size of the enemyIndexStage list.
            indexInList = 0;
            if (enemyIndexStage.Count == 1)
            {
                sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[0]], new Vector2(enemySpawnPoints[1].position.x, enemySpawnPoints[1].position.y), Quaternion.identity, enemySpawnPoints[1]));
                sceneManager.enemyList[0].GetComponent<EnemyStats>().index = 1;
            }
            else if (enemyIndexStage.Count == 2)
            {
                for (int i = 0; i < enemyIndexStage.Count; i++)
                {
                    sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[i]], new Vector2(enemySpawnPoints[i * 2].position.x, enemySpawnPoints[i * 2].position.y), Quaternion.identity, enemySpawnPoints[i * 2]));
                    sceneManager.enemyList[i].GetComponent<EnemyStats>().index = i * 2;
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

            //! Special location for the spirit door
            //! Checking if its the wave that spawns the spirit door
            if (AudioManager.instance.waveIndex == 3)
            {
                //! Setting the position of the spirit door
                sceneManager.enemyList[0].transform.position = new Vector3(4.2f, 1.0f, 0f);
            }

            //! Special location for the knight
            //! Checking if its the wave that spawns the knight
            if (AudioManager.instance.waveIndex == 4)
            {
                //! Setting the position of the knight
                sceneManager.enemyList[0].transform.position = new Vector3(3.896104f, -3f, 0f);
            }

            //! Instantiating the skill for the enemies
            for (int j = 0; j < sceneManager.enemyList.Count; j++)
            {
                for (int i = 0; i < sceneManager.enemyList[j].GetComponent<EnemyVariableManager>().skillsPrefab.Count; i++)
                {
                    sceneManager.enemyList[j].GetComponent<EnemyVariableManager>().skillList.Add(Instantiate(sceneManager.enemyList[j].GetComponent<EnemyVariableManager>().skillsPrefab[i], sceneManager.enemyList[j].transform));
                }
            }
            isEnemySpawn = true;
        }
	}
}
