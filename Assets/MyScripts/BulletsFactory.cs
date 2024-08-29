using UnityEngine;

public class BulletsFactory : IPoolObjectFactory
{
    private readonly MyBullet _prefab;

    public BulletsFactory(MyBullet prefab) =>
        _prefab = prefab;

    public IPoolObject Create() =>
        GameObject.Instantiate(_prefab);
}