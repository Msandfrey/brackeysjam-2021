using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource sfxAudioSource;
    [SerializeField]
    AudioClip shootingSound1;
    [SerializeField]
    AudioClip shootingSound2;
    [SerializeField]
    AudioClip explosionSound;
    [SerializeField]
    AudioClip transformationSound;
    [SerializeField]
    AudioClip hitIntoCircleSound;
    [SerializeField]
    AudioClip playerHitSound;
    [SerializeField]
    AudioClip playerHealSound;
    

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

    public void ShootingSound1() //It's here, but i think the shooting2 is easier on the ears
    {
        sfxAudioSource.PlayOneShot(shootingSound1);
    }

    public void ShootingSound2()
    {
        sfxAudioSource.PlayOneShot(shootingSound2);
    }

    public void PlayTransformationSound()
    {
        sfxAudioSource.PlayOneShot(transformationSound);
    }

    public void PlayHitInCircleSound()
    {
        sfxAudioSource.PlayOneShot(hitIntoCircleSound);
    }

    public void PlayHealingSound()
    {
        sfxAudioSource.PlayOneShot(playerHealSound);
    }

    public void PlayPlayerHitSound()
    {
        sfxAudioSource.PlayOneShot(playerHitSound);
    }
}
