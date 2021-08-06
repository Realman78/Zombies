using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] Flashlight flashlight;

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            flashlight.restoreAngle(85);
            flashlight.restoreIntensity(10.5f);
            Destroy(gameObject);
        }
    }
}
