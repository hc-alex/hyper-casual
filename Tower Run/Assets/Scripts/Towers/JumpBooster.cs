using Player;
using UnityEngine;

namespace Towers
{
  public class JumpBooster : MonoBehaviour
  {
    [SerializeField] private float _jumpMultiplicator;

    private void OnTriggerEnter(Collider other) => 
      TryModifyJumper(other, _jumpMultiplicator);

    private void OnTriggerExit(Collider other) => 
      TryModifyJumper(other, 1 / _jumpMultiplicator);

    private void TryModifyJumper(Collider other, float modificator)
    {
      if (!other.TryGetComponent(out Jumper jumper))
        return;

      jumper.ModifyJumpForce(modificator);
    }
  }
}