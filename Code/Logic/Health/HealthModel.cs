using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Steampunk.Code.Logic
{
    public class HealthModel : MonoBehaviour, IHealthModel
    {
        [SerializeField] private IntVariable _health;

        public int GetValue => _health.Value;
        public bool IsDie() => _health.Value < 0;
        public bool EqualsZero() => _health.Value == 0;
        public void ResetToDefault() => _health.Value = _health.InitialValue;

        public void Decrease(int decreaseValue)
        {
            if (_health.Value < 0) return;
            _health.Value -= decreaseValue;
        }
        
        private void OnDisable() => 
            ResetToDefault();
    }
}