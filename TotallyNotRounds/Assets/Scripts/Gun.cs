using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject projectileObject;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float rotationOffset;

    float spread;
    float ammoMax = 30;
    float ammoLeft;
    float pPerShot;
    
    float shotsPerTrigger = 1;
    float timeBetweenShots;
    float timeBetweenShotsLeft;

    float reloadTime = 3;
    float reloadLeft = 0;
    float attackSpeed = 10f;
    float attackWaitLeft = 0;

    bool autoReload;

    ProjectileMod pMod;
    float pSpeed;
    float pDamage;
    float pGravity;
    float pLifetime;
    float pMaxDist;
    float pBounces;

    private void BuildGun(ProjectileMod _pMod)
    {
        pMod = _pMod;
    }

    private void Awake()
    {
        ammoLeft = ammoMax;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && ammoLeft > 0 && attackWaitLeft == 0)
        {
            Trigger();
        }

        if (attackWaitLeft - Time.deltaTime > 0)
        {
            attackWaitLeft -= Time.deltaTime;
        }
        else
        {
            attackWaitLeft = 0;
        }
        
        if(autoReload || ammoLeft == 0)
        {
            if (reloadLeft - Time.deltaTime > 0)
            {
                reloadLeft -= Time.deltaTime;
            }
            else
            {
                reloadLeft = 0;
                Reload();
            }
        }
    }

    private void Reload()
    {
        ammoLeft = ammoMax;
    }

    private void Trigger()
    {
        for(int i = 0; i < shotsPerTrigger; i++)
        {
            //add time between
            Shoot();
        }
        attackWaitLeft = 1 / attackSpeed;
    }

    private void Shoot()
    {
        Quaternion rot = Quaternion.Euler(0, 0, spawnPoint.rotation.eulerAngles.z + rotationOffset);
        //Instantiate(projectileObject, spawnPoint.position, rot).AddComponent<Projectile>().BuildProjectile(2, pMod);
        ProjectileBuilder.Standard(spawnPoint.position, rot).GetComponent<Projectile>().Fire();

        reloadLeft = reloadTime;
        ammoLeft--;
    }
}
