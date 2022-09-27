using Steampunk.Code.Services;
using UnityEngine;
using Zenject;

namespace Steampunk.Code.Infrastructure
{
    public sealed class RestartServiceInstaller : MonoInstaller
    {
        [SerializeField] private RestartService _restartService;
        
        public override void InstallBindings() => 
            RestartServiceBind();

        private void RestartServiceBind()
        {
            Container
                .Bind(typeof(RestartService))
                .FromComponentInNewPrefab(_restartService)
                .AsSingle()
                .NonLazy();
        }
    }
}