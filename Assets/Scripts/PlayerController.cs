using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 2f;
    public Weapon weapon;
    Rigidbody2D rb;
    GameObject meleeC2D;
    bool melee;
    float time;
    public TMP_Text meleeAbility;
    public bool playerDead = false;

    Vector2 moveDirection;
    Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        meleeC2D = GameObject.Find("MeleeWeapon");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        melee = Input.GetButtonDown("Fire2");

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        meleeCheck();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = aimDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            health -= collision.gameObject.GetComponent<Enemy>().damage;
            Destroy(collision.gameObject);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            playerDead = true;
        }
    }

    private void meleeCheck()
    {
        if (time > 1)
        {
            meleeC2D.SetActive(false);
        }
        if (melee && time > 3)
        {
            meleeC2D.SetActive(true);
            time = 0;
        }
        if (time > 3)
        {
            meleeAbility.text = "Melee Attack:\nReady";
        }
        else
        {
            time += Time.deltaTime;
            meleeAbility.text = $"Melee Attack:\n{time:f2}/{3}";
        }
    }
}
