using UnityEngine;

public class BasicGun : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject chakraPrefab = null;


    public void BeginFire(Vector3 spawnpoint)
    {
        ;
    }

    public void OnFire(Vector3 spawnpoint)
    {
        Instantiate(chakraPrefab, spawnpoint, Quaternion.identity);
    }
}