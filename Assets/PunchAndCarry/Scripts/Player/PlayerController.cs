using PunchAndCarry.Scripts.MoneySystem;
using PunchAndCarry.Scripts.Player;
using PunchAndCarry.Scripts.UpgradeSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public PlayerAnimation Animation { get; private set; }
    [field: SerializeField] public EnemyStack EnemyStack { get; private set; }
    [field: SerializeField] public LevelUpController LevelUpController { get; private set; }
}
