using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public int damage = 10;
    public float moveSpeed = 0.01f;
    public int xpGiven = 50;

    private Rigidbody2D rb;
    private Vector3 directionToPlayer;
    private GameObject player;
    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        game = GameObject.Find("GameScript").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (player != null)
        {
            directionToPlayer = (player.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            game.enemies.Remove(gameObject);
            game.Xp += xpGiven;
            game.LevelCheck();
        }
    }
}
