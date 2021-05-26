using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Canvas recticle;
    [SerializeField] float zoomedFOV = 17f;
    [SerializeField] float zoomOutSens = 2f;
    [SerializeField] float zoomInSens = 0.5f;

    [SerializeField] RigidbodyFirstPersonController fpsController;

    [SerializeField] float zoomedFOV2 = 30f;

    float normalFOV = 47f;
    bool zoomed = false;

    private void OnDisable()
    {
        zoomed = false;
        ZoomOut();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ZoomWeapon();
        }
        
    }
    

    void ZoomWeapon()
    {
        zoomed = !zoomed;
        recticle.enabled = !zoomed;
        GetComponentInChildren<Animator>().SetBool("zoomed", zoomed);

        if (zoomed)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        mainCamera.fieldOfView = normalFOV;
        fpsController.mouseLook.XSensitivity = zoomOutSens;
        fpsController.mouseLook.YSensitivity = zoomOutSens;
    }

    private void ZoomIn()
    {
        mainCamera.fieldOfView = zoomedFOV;
        fpsController.mouseLook.XSensitivity = zoomInSens;
        fpsController.mouseLook.YSensitivity = zoomInSens;
    }
}
