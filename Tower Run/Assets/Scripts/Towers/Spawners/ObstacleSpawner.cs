namespace Towers.Spawners
{
  public class ObstacleSpawner : Spawner<Obstacle>
  {
    protected override void OnTowerReached(int towerNumber)
    {
      if (towerNumber == 0)
        return;
      
      Spawn(CalculateDistance(towerNumber));
    }
  
    protected override float CalculateDistance(int towerNumber) => 
      (towerNumber + 1 - 0.5f) * _distanceBetweenTower;
  }
}