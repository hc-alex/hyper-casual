using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Towers
{
  public class Obstacle : MonoBehaviour
  {
    [SerializeField] private float _humanHeight;
    private int _humanCount;

    private bool _isCollisionEntered;

    private void Start()
    {
      _humanCount = SetHumanCount;
      Vector3 newScale = SetScale();
      SetPosition(newScale);
    }

    private void OnCollisionEnter(Collision other)
    {
      if (_isCollisionEntered)
        return;
      
      if (!other.gameObject.TryGetComponent(out PlayerTower playerTower))
        return;

      _isCollisionEntered = true;
      
      playerTower.Explode(_humanCount);
    }

    private int SetHumanCount =>
      Random.Range(1, 3);

    private void SetPosition(Vector3 newlocalScale)
    {
      Vector3 newPosition = transform.position;
      newPosition.y += newlocalScale.x / 2;
      transform.position = newPosition;
    }

    private Vector3 SetScale()
    {
      Vector3 newScale = transform.localScale;
      newScale.x = _humanHeight * _humanCount;
      transform.localScale = newScale;
      return newScale;
    }
  }
}