using System;
using PunchAndCarry.Scripts.UpgradeSystem;
using TMPro;
using UnityEngine;

namespace PunchAndCarry.Scripts.MoneySystem
{
    public class BagCanvas : MonoBehaviour
    {
        [SerializeField] private LevelBag _bag;
        [SerializeField] private PlayerLevelController _levelController;
        [SerializeField] private TMP_Text _moneyValue;
        [SerializeField] private TMP_Text _levelValue;

        private void Start()
        {
            _bag.OnChangeMoneyAmountEvent += Bag_OnChangeMoneyAmountEvent;
            _levelController.OnLevelUp += LevelControllerOn_LevelUp;
        }

        private void LevelControllerOn_LevelUp(int level)
        {
            _levelValue.text = level.ToString();
        }

        private void Bag_OnChangeMoneyAmountEvent(int value)
        {
            _moneyValue.text = value.ToString();
        }

        private void OnDestroy()
        {
            _bag.OnChangeMoneyAmountEvent -= Bag_OnChangeMoneyAmountEvent;
            _levelController.OnLevelUp -= LevelControllerOn_LevelUp;
        }
    }
}
