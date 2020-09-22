using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] AmmoType ammoType;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player)
            HandlePickup();
    }

    private void HandlePickup() {
        FindObjectOfType<AmmoScript>().increaseAmmo(ammoType, amount);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
