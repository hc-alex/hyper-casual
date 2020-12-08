using UnityEngine;

namespace Flight
{
  public class Spawner : MonoBehaviour
  {
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;
    
    [SerializeField] private int frequency;
    private float _timer;

    private void Update()
    {
      Spawn();
    }
    
    private void Spawn()
    {
      _timer += Time.deltaTime;

      if (!(_timer > frequency))
        return;

      Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
      
      _timer = 0;
    }
  }
}