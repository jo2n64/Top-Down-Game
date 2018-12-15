using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    Rigidbody2D myRigidbody2D;
    Animator myAnimator;
    BoxCollider2D playerCollider;
    public VectorValue startPos;
    public GameObject bullet;
    public float moveSpeed;
    public float shootSpeed;
    public float jumpHeight;
    public float jumpDepth;
    public float respawnTime;
    public bool isAlive;
    public int health, coinCount;
    public Text healthText, coinText;

	// Use this for initialization
	void Start () {
        transform.position = startPos.initialValue;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
        healthText.text = "Health: " + health.ToString();
        coinText.text = "Coins: " + coinCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        Run();
        Shoot();
        Jump();
        healthText.text = "Health: " + health.ToString();
        coinText.text = "Coins: " + coinCount.ToString();
    }

    void Run() {
        float controlThrowX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float controlThrowY = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Vector2 playerVelocity = new Vector2(controlThrowX * moveSpeed, controlThrowY * moveSpeed);
        if (controlThrowY != 0 || controlThrowX != 0)
        {
            myAnimator.SetFloat("moveX", controlThrowX);
            myAnimator.SetFloat("moveY", controlThrowY);
            myAnimator.SetBool("moving", true);
        }
        else { myAnimator.SetBool("moving", false); }
        myRigidbody2D.velocity = playerVelocity;
    }
    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpVelocity = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z + jumpDepth);

        }
    }
    void Shoot() {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            if(myAnimator.GetFloat("moveX") != 0) bul.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * myAnimator.GetFloat("moveX"), 0);
            if (myAnimator.GetFloat("moveY") != 0) bul.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shootSpeed * myAnimator.GetFloat("moveY"));

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Enemy")) && isAlive == true)
        {
            health -= 1;
            if (health <= 0)
            {
                health = 0;
                Destroy(gameObject);
                isAlive = false;
                StartCoroutine(Respawn());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coinCount += 1;
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator Respawn()
    {
        if (isAlive == false)
        {
            yield return new WaitForSeconds(respawnTime);
            Instantiate(this, startPos.initialValue, Quaternion.identity);
            isAlive = true;
        }
    }

}
