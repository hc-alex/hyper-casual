using UnityEngine;

namespace Platforms
{
  public class SpawnPlatform : Platform
  {
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Ball.Ball _ball;

    private void Start() => 
      Instantiate(_ball, _spawnPoint.position, Quaternion.identity);
  }
}