using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SystemsLibrary.Runtime
{
    public class Economy : MonoBehaviour
    {
        private float money = 0;

        public UnityEvent OnMoneyChanged;

        public void SetMoney(float _newMoneyAmount)
        {
            money = _newMoneyAmount;
            OnMoneyChanged?.Invoke();
        }

        public void AddToMoney(float _amountToAdd)
        {
            money += _amountToAdd;
            OnMoneyChanged?.Invoke();
        }


    }
}
