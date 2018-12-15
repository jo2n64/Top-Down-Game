using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    attack,
    walk
}

public class Enemy : MonoBehaviour {

    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseDmg;
    public float moveSpeed;
    public GameObject drop;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Bullet")))
        {

            health -= FindObjectOfType<Bullet>().GetDmg();
            if (health <= 0)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
