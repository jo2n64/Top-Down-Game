using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletDmg;

    public float GetDmg() {
        return bulletDmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Enemy")) || GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Colliding Ground")))
        {
            StartCoroutine(WaitToDestroy());
        }
       
    }

    IEnumerator WaitToDestroy() {
        yield return new WaitForSeconds(0.001f);
        Destroy(gameObject);
    }

}

