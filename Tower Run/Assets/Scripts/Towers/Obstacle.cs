using Player;
using UnityEngine;

namespace Towers
{
  public class Obstacle : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      if (!other.TryGetComponent(out PlayerTower playerTower))
        return;

      playerTower.Explode(Random.Range(1, 3));
    }
  }
}