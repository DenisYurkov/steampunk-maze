using System;
using Steampunk.Code.Extensions;
using Steampunk.Code.Services;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Zenject;

namespace Steampunk.Code.Logic
{
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private IntEvent _healthEvent;
        private ILoadingService _loadingService;

        [Inject]
        private void Construct(ILoadingService loadingService) => 
            _loadingService = loadingService;

        private void OnEnable() => 
            _healthEvent.Register(Death);

        private void Awake()
        {
            Debug.Log(_loadingService, this);
        }

        private void Death(int currentHealth)
        {
            if (currentHealth < 0) {
                _loadingService.LoadSingle(Constants.CurrentScene);
            }
        }

        private void OnDestroy() => 
            _healthEvent.Unregister(Death);
    }
}