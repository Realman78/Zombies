using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginAudioPlayer : MonoBehaviour {
    [SerializeField] AudioSource source;

    private void Start() {
        StartCoroutine("releaseAudio");
    }
    public IEnumerator releaseAudio() {
        yield return new WaitForSeconds(1.4f);
        source.PlayOneShot(source.clip);
    }
}
