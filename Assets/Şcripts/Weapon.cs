using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] TextMeshProUGUI ammoTextMesh;
    AudioSource source;
    bool canShoot = true;

    private void OnEnable() {
        canShoot = true;
    }
    private void Start() {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            
            if (!(ammo.getAmount(ammoType) <= 0) && canShoot) {
                StartCoroutine("Shoot");
            }
            
        }
        displayAmmo();
    }

    void displayAmmo() {
        ammoTextMesh.text = ammo.getAmount(ammoType).ToString();
    }


    private IEnumerator Shoot() {
        canShoot = false;
        source.PlayOneShot(source.clip);
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
