using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShipController : MonoBehaviour

{
    [SerializeField]
    float speed = 5.5f;

    [SerializeField]
    GameObject boltPrefab;

    [SerializeField]
    GameObject gun;

    [SerializeField]
    float timeBetweenShots = 0.5f;
    float timeSinceLastShot = 0;

    [SerializeField]
    GameObject explosionPrefab;

    AudioSource speaker;

    [SerializeField]
    int healthMax = 3;
    int healthCurrent;

    [SerializeField]
    Slider healthBar;

    //PowerUps
    [SerializeField]
    float PowerUpSpeed = 7f;

    [SerializeField]
    float PowerUpFireRate = 0.2f;

    [SerializeField]
    float PowerUpHeal = 3;

    [SerializeField]
    float PowerUpMaxHealth = 5;

    int previousIndex = -1;

    void Start()
    {
        speaker = GetComponent<AudioSource>();
        healthCurrent = healthMax;
        healthBar.maxValue = healthMax;
        healthBar.value = healthCurrent;



    }

    // Update is called once per frame
    void Update()
    // kod till styrning
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movementX = new Vector2(moveX, 0);
        Vector2 movementY = new Vector2(0, moveY);

        Vector2 movement = movementX + movementY;

        transform.Translate(movement * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 9.7f)
        {
            transform.Translate(-movementX * speed * Time.deltaTime);
        }

        if (Mathf.Abs(transform.position.y) > 4f)
        {
            transform.Translate(-movementY * speed * Time.deltaTime);
        }

        // Skjut kod under

        timeSinceLastShot += Time.deltaTime;


        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)
        {
            Instantiate(boltPrefab, gun.transform.position, Quaternion.identity);
            timeSinceLastShot = 0;
        }




    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            healthCurrent--;
            healthBar.value = healthCurrent;
            if (healthCurrent == 0)
            {
                Destroy(this.gameObject);

                SceneManager.LoadScene(2);
            }
        }
        else if (other.gameObject.tag == "PowerUp")
        {
            float[] PowerAbilities = { PowerUpSpeed, PowerUpFireRate, PowerUpHeal, PowerUpMaxHealth };
            int randomIndex = Random.Range(0, PowerAbilities.Length);
            while (randomIndex == previousIndex)
        {
            randomIndex = Random.Range(0, PowerAbilities.Length);
        }
            float randomElement = PowerAbilities[randomIndex];
            Debug.Log("random siffra" + randomElement);
            previousIndex = randomIndex;

            if (Mathf.Approximately(randomElement, 7f))
            {
                speed = 11f;
            }

            else if (Mathf.Approximately(randomElement, 0.2f))
            {
                timeBetweenShots = 0.2f;
            }

            else if (Mathf.Approximately(randomElement, 5))
            {
                healthMax = 5;
                healthBar.maxValue = healthMax;
                
                
                
            }

            else if (Mathf.Approximately(randomElement, 3))
            {
                healthCurrent = healthMax;
                healthBar.value = healthCurrent;
            }

           



        }
    
    

    }
}



