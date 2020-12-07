using UnityEngine;

namespace Trash
{
  public class CollisionDetector : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      Destroy(other.gameObject, 2f);
    }
  }
}