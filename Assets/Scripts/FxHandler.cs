using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FxHandler : MonoBehaviour, IFX
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
//        if (PlayOnStart)
//            //gameObject.Send<IFX>(_=>_.Play());
//            ((IFX) this).Play();
    }

    IEnumerable IFX.Play()
    {
        Debug.Log("Play");
        if (HasParticleSystem && !Particle.isPlaying)
            Particle.Play();
        if (HasAudioSource && Audio.gameObject.activeInHierarchy && !Audio.isPlaying)
            Audio.Play();
        yield return null;
    }

    IEnumerable IFX.Stop()
    {
        Debug.Log("Stop");
        if (HasParticleSystem && Particle.isPlaying)
            Particle.Stop();
        if (HasAudioSource && Audio.gameObject.activeInHierarchy && Audio.isPlaying)
            Audio.Stop();
        yield return null;
    }

    public ParticleSystem GetParticle()
    {
        return Particle;
    }

    public AudioSource GetAudio()
    {
        return Audio;
    }

}
