using Steampunk.Code.Extensions;
using Steampunk.Code.Services;
using UnityEngine;
using Zenject;

namespace Steampunk.Code.Logic
{
    public class Win : MonoBehaviour
    {
        private ILoadingService _loadingService;
        private IHealthModel _healthModel;
        
        [Inject]
        private void Construct(ILoadingService loadingService, IHealthModel healthModel)
        {
            _loadingService = loadingService;
            _healthModel = healthModel;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Hero hero) && !_healthModel.IsDie()) { 
                _loadingService.LoadSingle(Constants.CorrectIndex);
            }
        }
    }
}
