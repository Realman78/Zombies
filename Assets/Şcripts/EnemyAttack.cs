using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void AttackEnemy() {
        if (target == null) return;
        playerHealth.decreaseHealth();
    }
}
