using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void decreaseHealth() {
        health -= 20f;
        if (health <= 0) {    
            GetComponent<DeathHandler>().handleDeath();
        }
    }
}
