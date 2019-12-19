using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyWeapon : MonoBehaviour
{
    // [SerializeField] GameObject deathFX;
    public ParticleSystem gun;
    [SerializeField] flyShip player;

    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other);
            player.score += (int) (3 * Mathf.Max(other.transform.localScale.x, Mathf.Max(other.transform.localScale.y, other.transform.localScale.z)));
        }
    }


    void Update()
    {
        AudioSource audioClip;
        if (GetComponent<ParticleSystem>().emission.enabled)
        {
            audioClip = GetComponent<AudioSource>();
            audioClip.Play(0);
        }else if (!GetComponent<ParticleSystem>().emission.enabled)
        {
            audioClip = GetComponent<AudioSource>();
            audioClip.Pause();
        }


    }
}
