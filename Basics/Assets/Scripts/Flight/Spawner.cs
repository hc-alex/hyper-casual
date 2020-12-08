using UnityEngine;

namespace Flight
{
  public class Spawner : MonoBehaviour
  {
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;
    
    [SerializeField] private int _frequency;
    private float _timer;

    private void Update()
    {
      TrySpawnByTimer();
    }

    private void TrySpawnByTimer()
    {
      _timer += Time.deltaTime;

      if (!(_timer > _frequency))
        return;
      
      Spawn();
      
      _timer = 0;
    }

    private void Spawn() => 
      Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
  }
}