using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    Destroy  (this.gameObject, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
