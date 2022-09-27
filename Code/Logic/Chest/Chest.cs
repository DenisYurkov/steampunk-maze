using UnityEngine;

namespace Steampunk.Code.Logic
{
    public class Chest : MonoBehaviour, IOpenable
    {
        [SerializeField] private Cell _cell;
        public ITakable Key { get; set; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Hero hero) && Key != null) {
                Open();
            }
        }

        public void Open()
        {
            var list = _cell.GetComponentsInChildren<Collider>();
            foreach (var col in list) {
                col.enabled = true;
            }

            Destroy(gameObject);
        }
    }
}