using System;
using PunchAndCarry.Scripts.UpgradeSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace PunchAndCarry.Scripts.MoneySystem
{
    public class HudCanvas : MonoBehaviour
    {
        [SerializeField] private LevelUpController levelUpController;
        [SerializeField] private TMP_Text _moneyValue;
        [SerializeField] private TMP_Text _levelValue;

        private void Start()
        {
            Bag.OnChangeMoneyAmountEvent += Bag_OnChangeMoneyAmountEvent;
            levelUpController.OnLevelUp += LevelUpControllerOnLevelUpUp;
        }

        private void LevelUpControllerOnLevelUpUp(int level)
        {
            _levelValue.text = level.ToString();
        }

        private void Bag_OnChangeMoneyAmountEvent(int value)
        {
            _moneyValue.text = value.ToString();
        }

        private void OnDestroy()
        {
            Bag.OnChangeMoneyAmountEvent -= Bag_OnChangeMoneyAmountEvent;
            levelUpController.OnLevelUp -= LevelUpControllerOnLevelUpUp;
        }
    }
}
