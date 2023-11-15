using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
[SerializeField]
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
    float x = Random.Range(-7f, 7f);

            Vector2 pos = new Vector2(x, 5.5f);

            transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
    Vector2 movement = Vector2.down;

        transform.Translate(movement * speed * Time.deltaTime);

                if (transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
            

        } 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           Destroy(this.gameObject);

        }
    }
}

