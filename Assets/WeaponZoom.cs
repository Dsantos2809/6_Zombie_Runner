using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Canvas recticle;
    [SerializeField] float zoomedFOV = 30;
    float normalFOV = 75;
    bool zoomed = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ZoomWeapon();
        }
        
    }

    void ZoomWeapon()
    {
        zoomed = !zoomed;
        recticle.enabled = !zoomed;
        GetComponentInChildren<Animator>().SetBool("zoomed", zoomed);

        if (zoomed) mainCamera.fieldOfView = zoomedFOV;
        else mainCamera.fieldOfView = normalFOV;
    }
}
