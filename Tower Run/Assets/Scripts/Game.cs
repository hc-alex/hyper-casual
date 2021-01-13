using Player;
using UnityEngine;

public class Game : MonoBehaviour
{
  [SerializeField] private PlayerTower _playerTower;

  private void Start()
  {
    _playerTower.HumansFinished += HumansFinished;
  }

  private void HumansFinished()
  {
    Debug.Log("Game Over!");
    Destroy(_playerTower.gameObject);
  }

  private void OnDestroy() => 
    _playerTower.HumansFinished -= HumansFinished;
}