using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float time = 0;
    public int damage;
    public bool isDestructable = true;

    private void Start()
    {
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject cGameObject = collision.gameObject;
        if (cGameObject.GetComponent<Enemy>() != null)
        {
            cGameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        if (cGameObject.GetComponent<Bullet>() == null && isDestructable)
        {
            Destroy(gameObject);
        }
    }
}
