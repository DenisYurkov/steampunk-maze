using System.Collections;
using DG.Tweening;
using Steampunk.Code.Services;
using UnityEngine;

namespace Steampunk.Code.Logic
{
    public class Enemy : Movable
    {
        [SerializeField] private HeroSettings _heroSettings;
        private InputService _inputService;

        private void Awake() => 
            _inputService = new InputService();

        public override IEnumerator Move()
        {
            if (TryGetCellAtDirection(out var cell, _inputService.Axis, _heroSettings.RayDistance * 2)) 
            {
                var updatePos = new Vector3(cell.Center.position.x, transform.position.y, cell.Center.position.z);
                transform.DOMove(updatePos, _heroSettings.MoveSpeed / 2);
                yield return null; 
            }
            else {
                Destroy(gameObject);
            }
        }
        
        private void Update()
        {
            Debug.DrawRay(transform.position, _inputService.Axis * _heroSettings.RayDistance, Color.cyan);
        }
    }
}