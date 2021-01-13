using System.Collections.Generic;
using Towers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
  [RequireComponent(typeof(PlayerTower))]
  public class WaveAnimationPlayer : MonoBehaviour
  {
    [SerializeField] private PlayerTower _playerTower;
    
    [SerializeField] private float _timeToWave;
    private float _timer;
    
    private List<Human> _humans;

    private void Start() => 
      _humans = _playerTower.Humans;

    private void Update() => 
      TryWaveByTimer();

    private void TryWaveByTimer()
    {
      if (_humans.Count <= 1)
        return;

      _timer += Time.deltaTime;

      if (_timer < _timeToWave)
        return;

      _timer = 0;
      _humans[Random.Range(1, _humans.Count)].Wave();
    }
  }
}