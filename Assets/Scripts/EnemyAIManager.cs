using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIManager : MonoBehaviour
{
    public GameObject[] enemyAiManager;
    void Start()
    {
        
    }

    void Update()
    {
        if(ThrowBall.isExitFriend == true)
        {
            for (int i = 0; i < enemyAiManager.Length; i++)
            {
                enemyAiManager[i].GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }
}
