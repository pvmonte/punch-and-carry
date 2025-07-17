using UnityEngine;

namespace PunchAndCarry.Scripts
{
    public class InteractionEmitParticle : InteractionParticle
    {
        [SerializeField] private int _emissionAmount = 1;
        
        protected override void Dispatcher_OnInteraction()
        {
            _particle.Emit(_emissionAmount);
        }
    }
}