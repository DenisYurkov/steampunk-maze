using Steampunk.Code.Extensions;
using Steampunk.Code.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Steampunk.Code.Logic
{
    public class Magnet : MonoBehaviour, IMagnet
    {
        [SerializeField] private float _magnetRadius;
        [SerializeField] private float _magnetForce;
        [SerializeField] private int _maxMagnetedObject = 3;
            
        private InputService _inputService;
        private Collider[] _magnetizedObjects;
        private InputAction.CallbackContext _callbackContext;
        
        private void Awake()
        {
            _inputService = new InputService();
            _magnetizedObjects = new Collider[_maxMagnetedObject];
            _inputService.PlayerAction.MagnetButton.performed += Attraction;
            _inputService.PlayerAction.MagnetButton.canceled += RemoveBlocks;

        }

        private void OnDisable()
        {
            _inputService.PlayerAction.MagnetButton.performed -= Attraction;
            _inputService.PlayerAction.MagnetButton.canceled -= RemoveBlocks;
            _inputService.PlayerAction.MagnetButton.Disable();
        }

        private void FixedUpdate()
        {
            if (_callbackContext.performed)
            {
                foreach (var magnetized in _magnetizedObjects)
                {
                    var magnetizedSize = Physics.OverlapSphereNonAlloc(transform.position, _magnetRadius, _magnetizedObjects, Constants.BlockLayer);
                    if (magnetized is null) continue;
                    
                    if (magnetized.TryGetComponent(out IMagnetic magnetic))
                        magnetic.Magnetize(transform.position, _magnetForce);
                }    
            }
        }

        private void RemoveBlocks(InputAction.CallbackContext callbackContext)
        {
            Debug.Log("SDS");
            for (var index = 0; index < _magnetizedObjects.Length; index++)
            {
                _magnetizedObjects[index] = null;
            }
        }


        public void Attraction(InputAction.CallbackContext context)
        {
            _callbackContext = context;
            Debug.Log(context);
        }
            
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _magnetRadius);
        }
    }
}