using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    DisplayDamage displayDamage;
    Transform target;
    [SerializeField] float damage = 40f;
    PlayerHealth playerHealth;
    AudioSource source;
    [SerializeField] AudioClip clipA;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        target = playerHealth.transform;
        displayDamage = FindObjectOfType<DisplayDamage>();
        source = GetComponent<AudioSource>();
    }

    public void AttackEnemy() {
        if (target == null) return;
        source.PlayOneShot(clipA);
        displayDamage.showCanvas();
        playerHealth.decreaseHealth();

    }
}
