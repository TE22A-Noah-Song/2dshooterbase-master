using System.Collections;
using
 System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;



    // Update is called once per frame
    void Update()
    {

        Vector2 movement = new Vector2(0, 1);
        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.y > 4.5f)
        {
            Destroy(this.gameObject);

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
        
           Destroy(this.gameObject);

        }
    }

}