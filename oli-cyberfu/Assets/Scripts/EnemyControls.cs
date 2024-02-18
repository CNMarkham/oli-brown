using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public float speed = 2;
    public float attackingDistance = 1;
    public Vector3 direction;

    private Animator animatorEnemy;
    private Rigidbody rigidbodyEnemy;
    private Transform target;
    public bool isFollowingTarget;
    public bool isAttackingTarget;
    private float chasingPlayer = 0.01f;
    public float currentAttackingTime;
    public float maxAttackingTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        isFollowingTarget = true;
        currentAttackingTime = maxAttackingTime;
        animatorEnemy = GetComponentInChildren<Animator>();
        rigidbodyEnemy = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void FollowTarget()
    {
        if (!isFollowingTarget)
        {
            rigidbodyEnemy.isKinematic = true;
        }

        if (Vector3.Distance(transform.position, target.position) >= attackingDistance)
        {
            rigidbodyEnemy.isKinematic = false;
            direction = target.position - transform.position;
            direction.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 100);

            if (rigidbodyEnemy.velocity.sqrMagnitude != 0)
            {
                rigidbodyEnemy.velocity = transform.forward * speed;
                animatorEnemy.SetBool("Walk", true);
            }
        }
        else if (Vector3.Distance (transform.position, target.position) <= attackingDistance)
        {
            rigidbodyEnemy.isKinematic = false;
            rigidbodyEnemy.velocity = Vector3.zero;
            animatorEnemy.SetBool("Walk", false);
            isFollowingTarget = false;
            isAttackingTarget = true;
        }

        
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    void Attack()
    {
        if (!isAttackingTarget)
        {
            return;
        }

        currentAttackingTime += Time.deltaTime;

        if(currentAttackingTime > maxAttackingTime)
        {
            EnemyAttack(Random.Range(1, 6));
            currentAttackingTime = 0f;
            
        }

        if(Vector3.Distance(transform.position, target.position) > attackingDistance + chasingPlayer)
        {
            isAttackingTarget = false;
            isFollowingTarget = true;
        }
    }

    public void EnemyAttack(int attack)
    {
        if(attack == 1)
        {
            animatorEnemy.SetTrigger("Attack1");
            Debug.Log("1");
        }

        if(attack == 2)
        {
            animatorEnemy.SetTrigger("Attack2");
            Debug.Log("2");
        }

        if(attack == 3)
        {
            animatorEnemy.SetTrigger("Attack3");
            Debug.Log("3");
        }

        if (attack == 4)
        {
            animatorEnemy.SetTrigger("Attack4");
            Debug.Log("4");
        }

        if (attack == 5)
        {
            animatorEnemy.SetTrigger("Attack5");
            Debug.Log("5");
        }

        if (attack == 6)
        {
            animatorEnemy.SetTrigger("Attack6");
            Debug.Log("6");
        }
    }
}
