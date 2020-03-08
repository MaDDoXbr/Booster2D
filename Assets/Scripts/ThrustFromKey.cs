using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ThrustFromKey : MonoBehaviour
{
    private Rigidbody2D _rb;
    //public Vector3 force; //(0,1,0)
    public AudioSource audioSource;
    public float thrustForce = 10f;
    public KeyCode actionKey = KeyCode.Space;
    private bool _hasAudioSource, _hasParticleSystem;
    public ParticleSystem particleSystem;

    private void Awake()
    {
        _hasAudioSource = audioSource != null;
        _hasParticleSystem = particleSystem != null;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //## THRUST
        if (Input.GetKey(actionKey))
        {
            _rb.AddRelativeForce(thrustForce * Vector3.up * Time.deltaTime);
            if (_hasAudioSource && !audioSource.isPlaying)
                audioSource.Play();
            if (_hasParticleSystem && !particleSystem.isPlaying)
                particleSystem.Play();
        } else {
            if (_hasParticleSystem && particleSystem.isPlaying)
                particleSystem.Stop();
            if (_hasAudioSource && audioSource.isPlaying)
                audioSource.Stop();            
        }
    }
}