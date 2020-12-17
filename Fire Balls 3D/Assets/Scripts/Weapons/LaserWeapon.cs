using DG.Tweening;
using UnityEngine;
using Weapons.Projectiles;

namespace Weapons
{
  public class LaserWeapon : Weapon
  {
    [SerializeField] private Laser _laserPrefab;
    [SerializeField] private float _recoilStrength;
    private Laser _laser;

    public override void Prepare(Transform shotPoint)
    {
      base.Prepare(shotPoint);
      _laser = Instantiate(_laserPrefab, shotPoint.position, Quaternion.identity);
    }

    public override void Shoot() => 
      _laser.Enable();

    public override void CallRecoil(Transform target) => 
      target.DOShakePosition(_delayBetweenShots / 2f, _recoilStrength).SetLoops(2, LoopType.Yoyo);
  }
}