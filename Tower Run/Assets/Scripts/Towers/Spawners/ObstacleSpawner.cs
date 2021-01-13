namespace Towers.Spawners
{
  public class ObstacleSpawner : Spawner<Obstacle>
  {
    protected override float CalculateDistance(int towerNumber) => 
      (towerNumber + 1 - 0.5f) * _distanceBetweenTower;
  }
}