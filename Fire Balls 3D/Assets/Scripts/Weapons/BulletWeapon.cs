using DG.Tweening;
using UnityEngine;
using Weapons.Projectiles;

namespace Weapons
{
  public class BulletWeapon : Weapon
  {
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _recoilDistance;
    
    public override void Shoot() => 
      Instantiate(_bullet, ShotPoint.position, Quaternion.identity);

    public override void CallRecoil(Transform target) => 
      target.DOMoveZ(target.position.z - _recoilDistance, _delayBetweenShots / 2f).SetLoops(2, LoopType.Yoyo);
  }
}