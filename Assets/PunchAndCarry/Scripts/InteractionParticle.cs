using System;
using UnityEngine;

namespace PunchAndCarry.Scripts
{
    public class InteractionParticle : MonoBehaviour
    {
        protected ParticleSystem _particle;
        protected IInteractionDispatcher _dispatcher;
    
        protected void Start()
        {
            _particle = GetComponent<ParticleSystem>();
            _dispatcher = GetComponentInParent<IInteractionDispatcher>();
            _dispatcher.OnInteraction += Dispatcher_OnInteraction;
        }

        protected virtual void Dispatcher_OnInteraction()
        {
            _particle.Play();
        }

        protected void OnDestroy()
        {
            _dispatcher.OnInteraction -= Dispatcher_OnInteraction;
        }
    }
}
