using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Towers
{
  public class Tower : MonoBehaviour
  {
    [SerializeField] private Human[] _humans;
    [SerializeField] private Vector2Int _humanRange;

    private List<Human> _humansInTower;

    private void Start()
    {
      _humansInTower = new List<Human>();
      SpawnHumans(Random.Range(_humanRange.x, _humanRange.y));
    }
   
    private void SpawnHumans(int humanCount)
    {
      Vector3 spawnPoint = transform.position;

      for (int i = 0; i < humanCount; i++)
      {
        Human human = Instantiate(_humans[Random.Range(0, _humans.Length)], spawnPoint, Quaternion.identity, transform);
        _humansInTower.Add(human);

        spawnPoint.y = human.FixationPoint.position.y;
      }
    }

    public List<Human> CollectHumans(Transform checker, float maxDistanceToFixationPoint)
    {
      for (int i = 0; i < _humansInTower.Count; i++)
      {
        float distanceToFixationPoint = Mathf.Abs(checker.position.y - _humansInTower[i].FixationPoint.transform.position.y);

        if (distanceToFixationPoint > maxDistanceToFixationPoint)
          continue;

        List<Human> collectedHumans = _humansInTower.GetRange(0, i + 1);
        _humansInTower.RemoveRange(0, i + 1);
        return collectedHumans;
      }

      return null;
    }

    public void Break()
    {
      foreach (Human human in _humansInTower)
        human.Explode();

      Destroy(gameObject);
    }
  }
}