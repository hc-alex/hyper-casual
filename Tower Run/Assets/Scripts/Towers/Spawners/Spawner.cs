using PathCreation;
using UnityEngine;

namespace Towers.Spawners
{
  [RequireComponent(typeof(LevelCreator))]
  public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
  {
    [SerializeField] private T _prefab;

    private PathCreator _pathCreator;
    private LevelCreator _levelCreator;

    private float _pathOffset = 2f;

    protected float _distanceBetweenTower;

    private void Awake()
    {
      _pathCreator = FindObjectOfType<PathCreator>();
      _levelCreator = GetComponent<LevelCreator>();
      _levelCreator.TowerReached += OnTowerReached;

      float pathLength = _pathCreator.path.length - _pathOffset;
      _distanceBetweenTower = pathLength / _levelCreator.TowerCount;
    }
    
    protected virtual void OnTowerReached(int towerNumber) =>
      Spawn(CalculateDistance(towerNumber));

    protected virtual float CalculateDistance(int towerNumber) =>
      (towerNumber + 1) * _distanceBetweenTower;

    protected void Spawn(float distance)
    {
      Vector3 spawnPoint = _pathCreator.path.GetPointAtDistance(distance, EndOfPathInstruction.Stop);
      Quaternion quaternion = _pathCreator.path.GetRotationAtDistance(distance, EndOfPathInstruction.Stop);
      Instantiate(_prefab, spawnPoint, quaternion);
    }

    private void OnDisable() =>
      _levelCreator.TowerReached -= OnTowerReached;
  }
}