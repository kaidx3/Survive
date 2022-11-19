using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Melee : MonoBehaviour
{
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() == true)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(100);
        }
    }
}
