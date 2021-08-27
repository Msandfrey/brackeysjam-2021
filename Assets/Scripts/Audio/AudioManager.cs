using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource sfxAudioSource;
    [SerializeField]
    AudioClip explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayShipExplosionSound()
    {
        sfxAudioSource.PlayOneShot(explosionSound);
    }
}
