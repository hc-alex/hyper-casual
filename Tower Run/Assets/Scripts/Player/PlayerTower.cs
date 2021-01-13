using System;
using System.Collections.Generic;
using Towers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
  public class PlayerTower : MonoBehaviour
  {
    [SerializeField] private Human _humanPrefab;
    [SerializeField] private Transform _checker;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private float _maxDistance;

    [SerializeField] private float _timeToWave;
    private float _timer;

    private List<Human> _humans;
    private float _baseCheckerOffsetY = 1.35f;

    public event Action HumansFinished;
    public event Action<int> HumanCountChanged;


    private void Start()
    {
      _humans = new List<Human> { Instantiate(_humanPrefab, transform.position, Quaternion.identity, transform) };
      _humans[0].Run();
      HumanCountChanged?.Invoke(_humans.Count);
    }

    private void Update()
    {
      TryWaveByTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (!other.gameObject.TryGetComponent(out Human human))
        return;

      Tower tower = human.GetComponentInParent<Tower>();

      if (!tower)
        return;

      List<Human> collectedHumans = tower.CollectHumans(_checker, _maxDistance);

      if (collectedHumans != null)
      {
        _humans[0].StopRun();
        
        for (int i = collectedHumans.Count - 1; i >= 0; i--)
        {
          _humans.Insert(0, collectedHumans[i]);
          InsertHuman(collectedHumans[i]);
          MoveTriggers(-1 * collectedHumans[i].transform.localScale.y);
        }
        
        _humans[0].Run();
        HumanCountChanged?.Invoke(_humans.Count);
      }

      tower.Break();
    }

    public void Explode(int humanCount)
    {
      int humanToDestroyCount;
      bool areHumansFinished;
      
      _humans[0].StopRun();
      
      if (humanCount >= _humans.Count)
      {
        humanToDestroyCount = _humans.Count;
        areHumansFinished = true;
      }
      else
      {
        humanToDestroyCount = humanCount;
        areHumansFinished = false;
      }

      for (int i = 0; i < humanToDestroyCount; i++)
      {
        if(!areHumansFinished)
          MoveTriggers(_humans[i].transform.localScale.y);
        
        _humans[i].Explode();
      }

      _humans.RemoveRange(0, humanToDestroyCount);

      if (areHumansFinished)
      {
        HumansFinished?.Invoke();
      }
      else
      {
        _humans[0].Run();
        HumanCountChanged?.Invoke(-1 * humanToDestroyCount);
      }
    }

    private void MoveTriggers(float checkerOffsetY)
    {
      Vector3 newChekerPosition = _checker.transform.position;
      newChekerPosition.y += checkerOffsetY * _baseCheckerOffsetY;
      _checker.transform.position = newChekerPosition;
      _collider.center = _checker.localPosition;
    }

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

    private void InsertHuman(Human human)
    {
      human.transform.parent = transform;
      human.transform.localPosition = new Vector3(0, human.transform.localPosition.y, 0);
      human.transform.localRotation = Quaternion.identity;
    }
  }
}