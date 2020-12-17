using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Towers
{
    [RequireComponent(typeof(TowerBuilder))]
    public class Tower : MonoBehaviour
    {
        private TowerBuilder _towerBuilder;
        private List<Pipe> _pipes;

        public event UnityAction<int> SizeUpdated;
        public event UnityAction GameOver;

        private void Start()
        {
            _towerBuilder = GetComponent<TowerBuilder>();
            _pipes = _towerBuilder.Build();

            foreach (var pipe in _pipes)
            {
                pipe.ProjectileHit += OnProjectileHit;
            }
            
            SizeUpdated?.Invoke(_pipes.Count);
        }

        private void OnProjectileHit(Pipe hitPipe)
        {
            hitPipe.ProjectileHit -= OnProjectileHit;
            _pipes.Remove(hitPipe);
            
            foreach (var pipe in _pipes)
            {
                Vector3 newPosition = pipe.transform.position;
                newPosition.y -= hitPipe.transform.localScale.y;
                pipe.transform.position = newPosition;
            }
            
            if(_pipes.Count > 0)
                SizeUpdated?.Invoke(_pipes.Count);
            else
                GameOver?.Invoke();
        }
    }
}
