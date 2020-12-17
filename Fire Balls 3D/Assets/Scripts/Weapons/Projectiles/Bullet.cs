using Towers;
using Towers.Obstacles;
using UnityEngine;

namespace Weapons.Projectiles
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        protected Vector3 MoveDirection = Vector3.forward;
        
        private void Update() => 
            Move();

        private void Move() => 
            transform.Translate(MoveDirection * (_speed * Time.deltaTime));

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Obstacle obstacle))
                MeetObstacle(other.gameObject.GetComponent<Obstacle>());

            if (other.TryGetComponent(out Pipe pipe))
            {
                pipe.Break();
                Destroy(gameObject);
            }
        }

        protected virtual void MeetObstacle(Obstacle obstacle)
        {
        }
    }
}
