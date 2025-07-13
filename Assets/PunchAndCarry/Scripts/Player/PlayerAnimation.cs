using UnityEngine;
using UnityEngine.Serialization;

namespace PunchAndCarry.Scripts.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Animator _animator;
        private static readonly int Move = Animator.StringToHash("move");

        void Update()
        {
            _animator.SetFloat(Move, playerMovement.MoveVector.magnitude);
        }
    }
}