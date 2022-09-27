using System.Collections;
using DG.Tweening;
using Steampunk.Code.Services;
using UnityEngine;

namespace Steampunk.Code.Logic
{
    public class Block : Movable, IMagnetic
    {
        [SerializeField] private HeroSettings _heroSettings;
        
        private InputService _inputService;
        private Rigidbody _rb;
        
        private void Awake()
        {
            _inputService = new InputService();
            _rb = GetComponent<Rigidbody>();
        }

        public void Magnetize(Vector3 heroPos, float magnetForce) =>
            _rb.velocity = (heroPos - (transform.position + _rb.centerOfMass)) * (magnetForce * Time.deltaTime);
        
        public override IEnumerator Move()
        {
            if (TryGetCellAtDirection(out var cell, _inputService.Axis, _heroSettings.RayDistance)) 
            {
                var updatePos = new Vector3(cell.Center.position.x, transform.position.y, cell.Center.position.z);
                transform.DOMove(updatePos, _heroSettings.MoveSpeed / 2);
            }
            yield return null;
        }

        private void Update() => 
            Debug.DrawRay(transform.position, _inputService.Axis * _heroSettings.RayDistance, Color.cyan);
    }
}