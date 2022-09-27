using UnityEngine.InputSystem;

namespace Steampunk.Code.Logic
{
    public interface IMagnet
    {
        void Attraction(InputAction.CallbackContext context);
    }
}