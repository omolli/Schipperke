using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int health;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public bool isDead()
    {
        return health <= 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
