using System.Collections;
using DG.Tweening;
using Steampunk.Code.Extensions;
using Steampunk.Code.Services;
using UnityEngine;
using Zenject;

namespace Steampunk.Code.Logic
{
    public class Hero : Movable, IHero
    {
        [SerializeField] private HeroSettings _heroSettings;
        [SerializeField] private bool _reverseInput;
        
        private Rigidbody _rigidbody;
        private IHealthModel _healthModel;
        private Cooldown _cooldown;
        private InputService _inputService;

        [Inject]
        private void Construct(IHealthModel healthModel) => 
            _healthModel = healthModel;

        private void Awake()
        {
            _cooldown = new Cooldown(_heroSettings.CooldownTime);
            _inputService = new InputService();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start() => 
            _inputService.ReverseAxis(_reverseInput);

        private void OnDisable() => 
            _inputService.PlayerAction.Movement.Disable();

        public override IEnumerator Move()
        {
            if (!IsMoving() || _healthModel.IsDie()) {
                yield break;
            }
            
            if (TryGetCellAtDirection(out var cell, _inputService.Axis, _heroSettings.RayDistance)) 
            {
                transform.rotation = Quaternion.LookRotation(_inputService.Axis);
                _rigidbody.DOMove(cell.Center.position, _heroSettings.MoveSpeed);
            }
        }

        public bool IsMoving() => 
            _inputService.Axis.magnitude > 0;

        private void Update()
        {
            if (_cooldown.Wait()) {
                StartCoroutine(Move());
            }
        }
    }
}