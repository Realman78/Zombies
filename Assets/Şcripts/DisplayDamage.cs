using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    private void Start() {
        impactCanvas.enabled = false;
    }
    IEnumerator enableCanvas() {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(.7f);
        impactCanvas.enabled = false;
    }
    public void showCanvas() {
        StartCoroutine("enableCanvas");
    }
}
