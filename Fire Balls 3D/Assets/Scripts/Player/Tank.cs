using UnityEngine;
using Weapons;

namespace Player
{
  public class Tank : MonoBehaviour
  {
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Weapon[] _weapons;
    private Weapon _weapon;

    private float _shotTime;

    private void Start()
    {
      _weapon = _weapons[Random.Range(0, _weapons.Length)];
      _weapon.Prepare(_shotPoint);
    }

    private void Update()
    {
      _shotTime += Time.deltaTime;

      if (!Input.GetKey(KeyCode.Space))
        return;
      
      if (_shotTime < _weapon.DelayBetweenShots)
        return;

      _weapon.Shoot();
      _weapon.CallRecoil(transform);
      
      _shotTime = 0;
    }
  }
}