using System;
using UnityEngine;

namespace Conveyor
{
  public class CollisionDetector : MonoBehaviour
  {
    public static event Action<GameObject> OnObjectCollisionExit;
    
    private void OnCollisionEnter(Collision other)
    {
      if(other.gameObject.TryGetComponent(out Mover mover)) 
        mover.IsMoving = true;
    }

    private void OnCollisionExit(Collision other)
    {
      if (!other.gameObject.TryGetComponent(out Mover mover)) 
        return;
      
      mover.Stop();
      OnObjectCollisionExit?.Invoke(other.gameObject);
    }
  }
}