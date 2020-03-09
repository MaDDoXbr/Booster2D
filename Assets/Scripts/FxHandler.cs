using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FxHandler : MonoBehaviour
{
    public ParticleSystem Particle;
    public AudioSource Audio;
    public bool PlayOnStart;
    [HideInInspector]public bool HasAudioSource;
    [HideInInspector]public bool HasParticleSystem;

    private void Awake()
    {
        HasAudioSource = Audio != null;
        HasParticleSystem = Particle != null;
    }

    void Start()
    {
        if (PlayOnStart)
            Play();
    }

    public void Play()
    {
        if (HasAudioSource && !Audio.isPlaying)
            Audio.Play();
        if (HasParticleSystem && !Particle.isPlaying)
            Particle.Play();
    }

    public void Stop()
    {
        if (HasParticleSystem && Particle.isPlaying)
            Particle.Stop();
        if (HasAudioSource && Audio.isPlaying)
            Audio.Stop();
    }
    
}
