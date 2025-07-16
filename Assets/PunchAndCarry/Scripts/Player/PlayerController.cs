using PunchAndCarry.Scripts.MoneySystem;
using PunchAndCarry.Scripts.Player;
using PunchAndCarry.Scripts.UpgradeSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public PlayerAnimation Animation { get; private set; }
    [field: SerializeField] public EnemyStack EnemyStack { get; private set; }
    [field: SerializeField] public LevelBag Bag { get; private set; }
    [field: SerializeField] public PlayerLevelController LevelController { get; private set; }
    
    void Start()
    {
        
    }
}
