using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots;

    [SerializeField] bool isAuto = false;

    bool canShoot = true;


    private void OnEnable()
    {
        canShoot = true;
    }
    void Update()
    {

        if (isAuto)
        {
            if (Input.GetMouseButton(0) && ammoSlot.GetAmmo(ammoType) > 0)
            {
                if(canShoot) StartCoroutine(Shoot());

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && ammoSlot.GetAmmo(ammoType) > 0)
            {
                if (canShoot) StartCoroutine(Shoot());

            }
        }
            
        

        
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        GetComponent<Animator>().SetTrigger("shoot");
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.ReduceAmmoAmount(ammoType);
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        yield return new WaitForSeconds(timeBetweenShots);
        FindObjectOfType<WeaponSwitcher>().enabled = true;
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
