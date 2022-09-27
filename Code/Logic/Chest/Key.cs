using DG.Tweening;
using UnityEngine;

namespace Steampunk.Code.Logic
{
    public class Key : MonoBehaviour, ITakable, IRotate
    {
        [SerializeField] private Chest _chest;

        private void Start() => 
            Rotate();

        public void PickUp()
        {
            _chest.Key = this;
            Destroy(gameObject);
        }

        public void Rotate() => 
            transform.DORotate(new Vector3(0, 1, 0), 1f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Hero hero)) 
                PickUp();
        }
    }

    public interface IRotate
    {
        void Rotate();
    }
}