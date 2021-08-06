using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;
    Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity -= lightDecay * Time.deltaTime;
        light.spotAngle = light.spotAngle > minAngle ? light.spotAngle - (angleDecay * Time.deltaTime) : minAngle;
    }

    public void restoreIntensity(float resInt) {
        light.intensity = resInt;
    }
    public void restoreAngle(float resAngle) {
        light.spotAngle = resAngle;
    }
}
