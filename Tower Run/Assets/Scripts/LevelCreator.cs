using System;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
  [SerializeField] private int _towerCount;

  public int TowerCount => _towerCount;

  public event Action<int> TowerReached; 
  
  private void Start()
  {
    for (int i = 0; i < _towerCount; i++) 
      TowerReached?.Invoke(i);
  }
}