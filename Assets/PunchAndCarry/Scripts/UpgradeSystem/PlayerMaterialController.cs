using UnityEngine;

namespace PunchAndCarry.Scripts.UpgradeSystem
{
    public class PlayerMaterialController : MonoBehaviour
    {
        [SerializeField] private Material _playerMaterial;

        public void ChangeToRandomColor()
        {
            _playerMaterial.color = Random.ColorHSV(0, 1, 0, 1, 1, 1);
        }
    }
}