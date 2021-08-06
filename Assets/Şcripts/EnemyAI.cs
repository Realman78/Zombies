using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    [SerializeField] float chaseTargetRange = 5f;

    float distanceToEnemy = Mathf.Infinity;
    NavMeshAgent navMeshAgent;

    bool isProvoked = false;
    Animator animator;
    EnemyHealth health;

    [SerializeField]AudioSource runAS;

    [SerializeField] AudioClip attackClip;
    AudioClip defClip;
    // Start is called before the first frame update
    void Start()
    {
        //runAS = GetComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        defClip = runAS.clip;
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
        if (health.isDead) {
            enabled = false;
            navMeshAgent.enabled = false;
            return;
        }

        distanceToEnemy = Vector3.Distance(transform.position, target.position);

        if (isProvoked)
            EngageTarget();
        else
            animator.SetTrigger("Idle");
        isProvoked = distanceToEnemy <= chaseTargetRange;
        
    }

    public void OnDamageTaken() {
        isProvoked = true;
    }

    private void EngageTarget() {
        faceTarget();
        

        if (distanceToEnemy > navMeshAgent.stoppingDistance) {
            animator.SetBool("Attack", false);
            navMeshAgent.SetDestination(target.position);
            animator.SetTrigger("move");
            if (!runAS.isPlaying) {
                runAS.PlayOneShot(defClip); 
            }
        }

        if (distanceToEnemy <= navMeshAgent.stoppingDistance) {
            animator.SetBool("Attack", true);
            
            if (runAS.clip == defClip) {
                runAS.Stop();
                runAS.clip = attackClip;
                runAS.PlayOneShot(runAS.clip);
            }
            if (!runAS.isPlaying) {
                runAS.PlayOneShot(runAS.clip);
            }
                
        }


    }

    private void playClip(AudioClip clip) {
        
    }
}
