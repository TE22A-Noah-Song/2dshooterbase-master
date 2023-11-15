using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
 [SerializeField]
    GameObject PowerUpPrefab;

     [SerializeField]
    GameObject Spawner;

     [SerializeField]
    float CooldownBetween = 0.2f;
    float CooldownBetweenLast = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      CooldownBetweenLast += Time.deltaTime;

        if (CooldownBetweenLast > CooldownBetween)
        {
            Instantiate(PowerUpPrefab);
            CooldownBetweenLast = 0;
        }   
    }
}
