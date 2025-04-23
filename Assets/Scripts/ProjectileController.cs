using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("HIT " + other.gameObject.name);
        //Debug.Log(other.gameObject.tag);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("enemy");
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                if (enemyHealth.isDead())
                {
                    Destroy(other.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
