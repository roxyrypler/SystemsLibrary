using UnityEngine;
using UnityEngine.Events;

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
