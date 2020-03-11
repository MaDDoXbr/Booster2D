using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IFX : IEventSystemHandler
{
    IEnumerable Play();
    IEnumerable Stop();
    ParticleSystem GetParticle();
    AudioSource GetAudio();
}
