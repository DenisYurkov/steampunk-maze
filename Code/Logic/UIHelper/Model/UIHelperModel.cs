using UnityEngine;

namespace Steampunk.Code.Logic
{
    public class UIHelperModel : IUIHelperModel
    {
        private readonly float _timeForHide;
        private readonly float _animationSpeed;
        private readonly IUIHelperView _uiHelperView;
        private readonly MonoBehaviour _behaviour;
        
        public UIHelperModel(MonoBehaviour behaviour, UIHelperConfig uiHelperConfig, IUIHelperView uiHelperView)
        {
            _behaviour = behaviour;
            _timeForHide = uiHelperConfig.TimeForHide;
            _animationSpeed = uiHelperConfig.AnimationSpeed;
            _uiHelperView = uiHelperView;
        }

        public void Visualize() => 
            _behaviour.StartCoroutine(_uiHelperView.ShowUI(_timeForHide, _animationSpeed));
    }
}