﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseTargetRange = 5f;

    float distanceToEnemy = Mathf.Infinity;
    NavMeshAgent navMeshAgent;

    bool isProvoked = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void OnDrawGizmosSelected() {
        // Display the explosion radius when selected
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, chaseTargetRange);
    }

    private void faceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookDir = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, Time.deltaTime * 10f);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToEnemy = Vector3.Distance(transform.position, target.position);

        if (isProvoked)
            EngageTarget();
        else
            animator.SetTrigger("Idle");
        isProvoked = distanceToEnemy <= chaseTargetRange;
        
    }

    private void EngageTarget() {
        faceTarget();
        if (distanceToEnemy > navMeshAgent.stoppingDistance) {
            animator.SetBool("Attack", false);
            navMeshAgent.SetDestination(target.position);
            animator.SetTrigger("move");
        }
            

        if (distanceToEnemy <= navMeshAgent.stoppingDistance) {
            animator.SetBool("Attack", true);
        }
    }
}
