using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public float knockbackForce;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                Vector2 diff = enemy.transform.position - transform.position;
                diff = diff.normalized * knockbackForce;
                Debug.Log("this is knocked back with " + diff + " force");
                enemy.AddForce(diff, ForceMode2D.Impulse);
                Debug.Log("some force");
                StartCoroutine(KnockingBack(enemy));   
            }
        }
    }

    private IEnumerator KnockingBack(Rigidbody2D enemy)
    {
        Debug.Log("coroutine starts");
        if (enemy != null)
        {
            Debug.Log("it works?");
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            Debug.Log("enemy's velocity is " + enemy.velocity);
        }
    }
}
