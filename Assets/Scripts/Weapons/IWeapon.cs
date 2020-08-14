using UnityEngine;

public interface IWeapon
{
    void BeginFire(Vector3 spawnpoint);
    void OnFire(Vector3 spawnpoint);
}