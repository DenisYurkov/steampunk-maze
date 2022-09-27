using System;
using Steampunk.Code.Logic;
using UnityEngine;
using Zenject;

namespace Steampunk.Code.Infrastructure
{
    public class UIHelperInstaller : MonoInstaller
    {
        [SerializeField] private UIHelperView _uiHelperView;
        [SerializeField] private UIHelperConfig _uiHelperConfig;
        
        public override void InstallBindings() => 
            UIHelperBind();

        private void UIHelperBind()
        {
            IUIHelperView uiHelperView = Instantiate(_uiHelperView);
            IUIHelperModel uiHelperModel = new UIHelperModel(this, _uiHelperConfig, uiHelperView);

            Container
                .Bind(typeof(IUIHelperModel))
                .FromInstance(uiHelperModel)
                .AsSingle();
        }
    }
}