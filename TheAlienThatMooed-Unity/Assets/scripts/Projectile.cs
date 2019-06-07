using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{

    public float speed;


    private Transform player;
    private Vector2 target;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            DestroyProjectile();

            PlayerController.health -= 1;
            if (PlayerController.health <=0)
            {
                SceneManager.LoadScene("EndGameScreen");

            }

        }

        

    }
    void DestroyProjectile()
    {

        Destroy(gameObject);
        


    }

}


