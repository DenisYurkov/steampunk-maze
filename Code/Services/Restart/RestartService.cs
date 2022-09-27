using Steampunk.Code.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Steampunk.Code.Services
{
    public class RestartService : MonoBehaviour
    {
        private ILoadingService _loadingService;
        private InputService _inputService;

        [Inject]
        private void Construct(ILoadingService loadingService) => 
            _loadingService = loadingService;

        private void Awake()
        {
            _inputService = new InputService();
            _inputService.UIAction.Restart.performed += Restart;
        }

        private void OnDisable() => 
            _inputService.UIAction.Restart.performed -= Restart;

        private void Restart(InputAction.CallbackContext callbackContext) => 
            _loadingService.LoadSingle(Constants.CurrentScene);
    }
}