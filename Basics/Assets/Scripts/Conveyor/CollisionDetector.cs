using System;
using UnityEngine;

namespace Conveyor
{
  public class CollisionDetector : MonoBehaviour
  {
    public static event Action<GameObject> ObjectCollisionExit;
    
    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.TryGetComponent(out Mover mover))
        mover.StartMoving();
    }

    private void OnCollisionExit(Collision other)
    {
      if (!other.gameObject.TryGetComponent(out Mover mover)) 
        return;
      
      mover.StopMoving();
      ObjectCollisionExit?.Invoke(other.gameObject);
    }
  }
}