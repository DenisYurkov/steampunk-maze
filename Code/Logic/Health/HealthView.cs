using System;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Steampunk.Code.Logic
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private IntEvent _healthChangedEvent;
        [SerializeField] private TextMeshProUGUI _hpText;

        private IHealthModel _healthModel;
        
        [Inject]
        private void Construct(IHealthModel healthModel) => 
            _healthModel = healthModel;
        
        private void OnEnable()
        {
            _healthChangedEvent.Register(UpdateText);
            UpdateText();
        }

        private void Awake()
        {
            Debug.Log(_healthModel, this);
        }

        private void OnDisable() => 
            _healthChangedEvent.Unregister(UpdateText);

        private void UpdateText()
        {
            if (_healthModel.IsDie()) return;
            _hpText.text = _healthModel.EqualsZero() ? "X" : _healthModel.GetValue.ToString();
        }
    }
}