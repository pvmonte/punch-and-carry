using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PunchAndCarry.Scripts.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PunchCollider _punchCollider;
        [SerializeField] private Animator _animator;
        private static readonly int Move = Animator.StringToHash("move");
        private static readonly int Punch = Animator.StringToHash("punch");

        private void Start()
        {
            _punchCollider.OnPunchEvent += PunchCollider_OnPunchEvent;
        }

        private void PunchCollider_OnPunchEvent()
        {
            _animator.SetTrigger(Punch);
        }

        void Update()
        {
            _animator.SetFloat(Move, _playerMovement.MoveVector.magnitude);
        }
    }
}