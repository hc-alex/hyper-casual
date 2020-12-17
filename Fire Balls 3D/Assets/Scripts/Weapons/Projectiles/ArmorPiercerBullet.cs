using Towers.Obstacles;
using UnityEngine;

namespace Weapons.Projectiles
{
    public class ArmorPiercerBullet : Bullet
    {
        protected override void MeetObstacle(Obstacle obstacle)
        {
            obstacle.Explode();
            MoveDirection = Vector3.zero;
            Destroy(gameObject);
        }
    }
}
