using Player;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
  [SerializeField] private PlayerTower _playerTower;
  [SerializeField] private float _moveSpeed;
  [SerializeField] private Vector3 _offsetPosition;
  [SerializeField] private Vector3 _offsetRotation;

  private Vector3 _targetOffsetPosition;

  private void FixedUpdate()
  {
    UpdatePosition();
    _offsetPosition = Vector3.MoveTowards(_offsetPosition, _targetOffsetPosition, _moveSpeed * Time.deltaTime);
  }

  private void OnEnable() => 
    _playerTower.HumanCountChanged += OnHumanCountChanged;

  private void OnDisable() => 
    _playerTower.HumanCountChanged += OnHumanCountChanged;

  private void UpdatePosition()
  {
    if(!_playerTower)
      return;
    
    transform.position = _playerTower.transform.position;
    transform.localPosition += _offsetPosition;
    
    transform.LookAt(_playerTower.transform.position + _offsetRotation);
  }

  private void OnHumanCountChanged(int count)
  {
    _targetOffsetPosition = _offsetPosition + (Vector3.back + Vector3.up) * count;
    UpdatePosition();
  }
}