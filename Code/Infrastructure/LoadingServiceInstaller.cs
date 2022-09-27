using Steampunk.Code.Services;
using UnityEngine;
using Zenject;

namespace Steampunk.Code.Infrastructure
{
    public sealed class LoadingServiceInstaller : MonoInstaller
    {
        [SerializeField] private LoadingService _loadingService;
        
        public override void InstallBindings() => 
            LoadingServiceBind();

        private void LoadingServiceBind()
        {
            Container
                .Bind(typeof(ILoadingService))
                .FromComponentInNewPrefab(_loadingService)
                .AsCached();
        }
    }
}