using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlashFX;
    [SerializeField] GameObject bulletHitFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void Shoot() {
        muzzleFlashFX.Play();
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {
            var hitFX = Instantiate(bulletHitFX, hit.point, Quaternion.identity, this.transform);
            Destroy(hitFX, .2f);
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null) {
                enemyHealth.reduceHealth(damage);
                
            }
        }
    }
}
