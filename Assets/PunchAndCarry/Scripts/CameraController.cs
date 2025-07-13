using UnityEngine;

namespace PunchAndCarry.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Vector3 _offset;

        private void OnValidate()
        {
            _offset = transform.position;
        }

        void Update()
        {
            transform.position = _player.position + _offset;
        }
    }
}
