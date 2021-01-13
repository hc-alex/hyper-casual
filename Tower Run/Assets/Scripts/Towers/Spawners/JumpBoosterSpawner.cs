using UnityEngine;

namespace Towers.Spawners
{
  public class JumpBoosterSpawner : Spawner<JumpBooster>
  {
    [SerializeField] private float _distanceOffset;
    
    protected override void OnTowerReached(int towerNumber)
    {
      if (towerNumber % 2 == 0) 
        Spawn(CalculateDistance(towerNumber));
    }
    
    protected override float CalculateDistance(int towerNumber) => 
      (towerNumber + 1) * _distanceBetweenTower - _distanceOffset;
  }
}