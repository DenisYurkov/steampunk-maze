using UnityEngine;

namespace Steampunk.Code.Logic
{
    public interface IMagnetic
    {
        void Magnetize(Vector3 heroPos, float magnetForce);
    }
}