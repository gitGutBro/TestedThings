using System;
using UnityEngine;

[Serializable]
public class Shooter
{
    [SerializeField][Range(0.1f, 0.4f)] private float _bulletSpawnDelay;
    [SerializeField] private MyBullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private float _cooldown;
    private ObjectsPool _bulletsPool;

    private bool CanShoot => Time.time >= _cooldown;

    public void Shoot()
    {
        if (CanShoot == false)
            return;

        _cooldown = Time.time + _bulletSpawnDelay;

        MyBullet bullet = _bulletsPool.Get<MyBullet>();
        bullet.Transform.position = _firePoint.position;
        bullet.SetDirection(_firePoint.forward);
    }

    public void Init() =>
        _bulletsPool = new ObjectsPool(new BulletsFactory(_bulletPrefab));
}