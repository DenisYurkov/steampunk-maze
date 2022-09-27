using Steampunk.Code.Logic;
using UnityEngine;
using Zenject;

namespace Steampunk.Code.Infrastructure
{
    public sealed class HealthModelInstaller : MonoInstaller
    {
        [SerializeField] private HealthModel _healthModel;
        
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(IHealthModel))
                .FromInstance(_healthModel)
                .AsSingle().NonLazy();
        }
    }
}