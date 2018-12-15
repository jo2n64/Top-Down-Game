using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{

    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePos;
    public Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        health = maxHealth.initialValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius
            && (currentState == EnemyState.idle || currentState == EnemyState.walk))
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(temp);
            changeAnimator(temp - transform.position);
            ChangeState(EnemyState.walk);
            myAnimator.SetBool("hasWokenUp", true);
        }
        else { 
            ChangeState(EnemyState.idle);
            myAnimator.SetBool("hasWokenUp", false);
        }
    }

    void ChangeState(EnemyState state)
    {
        if(currentState != state)
        {
            currentState = state;
        }
    }

    void changeAnimator(Vector2 direction) {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0) myAnimator.SetFloat("moveX", 1f);
            else if (direction.x < 0) myAnimator.SetFloat("moveX", -1f);
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0) myAnimator.SetFloat("moveY", 1f);
            else if (direction.y < 0) myAnimator.SetFloat("moveY", -1f);
        }
    }
    
}
