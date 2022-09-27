using System.Collections;
using Steampunk.Code.Extensions;
using UnityEngine;

namespace Steampunk.Code.Logic
{
    public abstract class Movable : MonoBehaviour, IMovable
    {
        public abstract IEnumerator Move();

        public bool TryGetCellAtDirection(out Cell cell, Vector3 axis, float rayDistance)
        {
            if (Physics.Raycast(transform.position, axis, out var raycastHit, rayDistance, Constants.CellLayer))
            {
                if (raycastHit.collider.TryGetComponent(out Cell cellComponent))
                {
                    cell = cellComponent;
                    return true;
                }
            }
            cell = null;
            return false;
        }
    }
}