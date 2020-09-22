using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    public bool isDead = false;

    public void reduceHealth(float damage) {
        health -= damage;
        BroadcastMessage("OnDamageTaken");
        if (health <= 0) {
            if (!isDead) {
                isDead = true;
                GetComponent<Animator>().SetTrigger("Die");
            }
        }
    }
    
}
