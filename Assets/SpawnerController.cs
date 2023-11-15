using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField]
    GameObject EnemyPrefab;

    [SerializeField]
    GameObject Spawner;

    [SerializeField]
    float CooldownBetween = 0.2f;
    float CooldownBetweenLast = 0;
    
    void Update()
    {
        CooldownBetweenLast += Time.deltaTime;

        if (CooldownBetweenLast > CooldownBetween)
        {
            Instantiate(EnemyPrefab);
            CooldownBetweenLast = 0;
        }

    }
}