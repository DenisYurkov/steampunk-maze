using UnityEngine;

namespace Steampunk.Code.Logic
{
    public class HeroPushing : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IMovable movable) && _hero.IsMoving())
            {
                other.rigidbody.isKinematic = true;
                StartCoroutine(movable.Move());
                other.rigidbody.isKinematic = false;
            }
        }
    }
}