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
    [SerializeField] AmmoScript ammo;
    [SerializeField] float shootDelay = 1f;
    [SerializeField] AmmoType ammoType;
    bool canShoot = true;

    private void OnEnable() {
        canShoot = true;
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            if (!(ammo.getAmount(ammoType) <= 0) && canShoot) {
                StartCoroutine("Shoot");
            }
            
        }
    }



    private IEnumerator Shoot() {
        canShoot = false;
        ammo.reduceAmmo(ammoType);
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
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
