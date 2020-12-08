using UnityEngine;

namespace Conveyor
{
  public class Spawner : MonoBehaviour
  {
    [SerializeField] private Transform _initialPoint;
    public GameObject prefab;

    private void Start()
    {
      Spawn();
      PlaceOnInitialPoint();
    }

    private void Spawn() => 
      Instantiate(prefab, _initialPoint.position, Quaternion.identity);

    private void PlaceOnInitialPoint()
    {
      CollisionDetector.ObjectCollisionExit += o => 
        o.transform.position = _initialPoint.position;
    }
  }
}