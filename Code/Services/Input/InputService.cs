using UnityEngine;

namespace Steampunk.Code.Services
{
    public class InputService : IInputService
    {
        public PlayerInputAction.PlayerActions PlayerAction { get; set; }
        public PlayerInputAction.UIActions UIAction { get; set; }

        public InputService()
        {
            PlayerAction = new PlayerInputAction().Player;
            PlayerAction.Enable();

            UIAction = new PlayerInputAction().UI;
            UIAction.Enable();
        }

        public Vector3 Axis
        {
            get => new(PlayerAction.Movement.ReadValue<Vector2>().x, 0, PlayerAction.Movement.ReadValue<Vector2>().y);
            set {}
        }

        public void ReverseAxis(bool reverseInput) => 
            Axis = reverseInput ? -Axis : Axis;
    }
}