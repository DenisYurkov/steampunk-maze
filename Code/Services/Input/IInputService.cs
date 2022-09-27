using UnityEngine;

namespace Steampunk.Code.Services
{
    public interface IInputService
    {
        public PlayerInputAction.PlayerActions PlayerAction { get; set; }
        public PlayerInputAction.UIActions UIAction { get; set; }
        Vector3 Axis { get; }
        void ReverseAxis(bool reverseInput);
    }
}