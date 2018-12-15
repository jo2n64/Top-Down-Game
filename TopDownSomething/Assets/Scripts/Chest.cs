using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool readyToOpen;
    public SpriteRenderer spriteRenderer;
    public Sprite open, closed;
    public GameObject drop;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (readyToOpen && Input.GetKeyDown(KeyCode.Space))
        {
            spriteRenderer.sprite = open;
            Instantiate(drop, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToOpen = false;
        }
    }
}
