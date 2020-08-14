using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public IWeapon selectedWeapon = null;
    private Camera cam;
    private Ray ray;
    private RaycastHit[] hitBuffer;
    private Vector3 projectileSpawnpoint = Vector3.zero;
    private Vector3 lookAt;

    private const int GROUND_MASK = 1 << 8;

    private void Awake()
    {
        cam = Camera.main;
        hitBuffer = new RaycastHit[2];
    }

    private void Update()
    {
        if (Physics.RaycastNonAlloc(
            cam.ScreenPointToRay(Input.mousePosition),
            hitBuffer,
            50f,
            GROUND_MASK) <= 0) return;

        if (Input.GetButtonDown("Fire1"))
        {
            BeginFire();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            OnFire();
        }
    }

    private void LateUpdate()
    {
        // TODO: Look using gamepad
        lookAt = hitBuffer[0].point;
        lookAt.y = 0f;
        projectileSpawnpoint = this.transform.position +
                           this.transform.forward +
                           1.5f * this.transform.up;
    }

    private void FixedUpdate()
    {
        this.transform.LookAt(lookAt);
    }

    public void SetWeapon(IWeapon toSet)
    {
        selectedWeapon = toSet;
    }

    private void BeginFire()
    {
        selectedWeapon?.BeginFire(projectileSpawnpoint);
    }

    private void OnFire()
    {
        selectedWeapon?.OnFire(projectileSpawnpoint);
    }
}