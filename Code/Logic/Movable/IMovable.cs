using System.Collections;
using UnityEngine;

namespace Steampunk.Code.Logic
{
    public interface IMovable
    {
        IEnumerator Move();
        bool TryGetCellAtDirection(out Cell cell, Vector3 axis, float rayDistance);
    }
}