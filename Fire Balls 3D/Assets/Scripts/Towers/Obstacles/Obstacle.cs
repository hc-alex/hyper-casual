using UnityEngine;

namespace Towers.Obstacles
{
  [RequireComponent(typeof(Rigidbody))]
  public class Obstacle : MonoBehaviour
  {
    public void Explode()
    {
      transform.parent = null;
      Rigidbody rigidbody = GetComponent<Rigidbody>();
      rigidbody.isKinematic = false;
      rigidbody.AddExplosionForce(500, transform.position, 100, 3);
      Destroy(gameObject, 2f);
    }
  }
}