using Towers.Obstacles;
using UnityEngine;

namespace Weapons.Projectiles
{
  [RequireComponent(typeof(Rigidbody))]
  public class SimpleBullet : Bullet
  {
    protected override void MeetObstacle(Obstacle obstacle)
    {
      MoveDirection = Vector3.back + Vector3.up;
      Rigidbody rigidbody = GetComponent<Rigidbody>();
      rigidbody.isKinematic = false;
      rigidbody.AddExplosionForce(100, transform.position + new Vector3(0, -1, 1), 100);
    }
  }
}
