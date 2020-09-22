using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField]int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        setWeaponActive();
    }

    private void setWeaponActive() {
        int currentIndex = 0;
        foreach (Transform weapon in transform) {
            weapon.gameObject.SetActive(currentIndex == currentWeapon);
            if (weapon.GetComponent<WeaponZoom>() != null) {
                weapon.GetComponent<WeaponZoom>().setZoom(60);
            }
            
            currentIndex++;
        }
    }


    // Update is called once per frame
    void Update()
    {
        int previous = currentWeapon;

        ProcessKeyPress();
        ProcessScroll();

        if (previous != currentWeapon) {
            setWeaponActive();
        }
    }

    private void ProcessScroll() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            currentWeapon = ++currentWeapon % transform.childCount;
        }else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            if (currentWeapon <= 0) {
                currentWeapon = transform.childCount - 1;
            } else {
                currentWeapon--;
            }
        }
    }

    private void ProcessKeyPress() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            currentWeapon = 2;
        }
    }
}
