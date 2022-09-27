using UnityEngine;
using Zenject;

namespace Steampunk.Code.Logic
{
    public class Cell : MonoBehaviour
    {
        public Transform Center;
        
        [SerializeField] private int _damage = 1;
        [SerializeField] private bool _isFirst;
        private IHealthModel _healthModel;

        [Inject]
        private void Construct(IHealthModel healthModelLogic) => 
            _healthModel = healthModelLogic;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IHero hero) && _isFirst == false) {
                _healthModel.Decrease(_damage);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IHero hero)) {
                _isFirst = false;
            }
        }
    }
}