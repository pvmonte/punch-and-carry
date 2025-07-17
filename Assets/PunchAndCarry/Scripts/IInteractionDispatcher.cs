using System;

namespace PunchAndCarry.Scripts
{
    public interface IInteractionDispatcher
    {
        public event Action OnInteraction;
    }
}