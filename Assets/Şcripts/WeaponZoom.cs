using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] RigidbodyFirstPersonController rigidbodyFP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {

            camera.fieldOfView = camera.fieldOfView == 60 ? 35 : 60;
            rigidbodyFP.mouseLook.XSensitivity = camera.fieldOfView == 60 ? 2 : 1;
            rigidbodyFP.mouseLook.YSensitivity = rigidbodyFP.mouseLook.XSensitivity;


        }
    }
    public void setZoom(int fieldOfView) {
        camera.fieldOfView = fieldOfView;
    }
}
