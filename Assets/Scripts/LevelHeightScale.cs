﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHeightScale : MonoBehaviour
{
    // gameObject references to the projectile prefab and the instantiated clone
    public GameObject projectilePrefab, projectileInstance;
    // gameObject reference to platform the projectile rests on
    public GameObject platform;
    // gameObject reference to target area and physical target object to throw projectile at
    public GameObject targetField, targetObj;
    // floats to track original height and y-position of platform
    private float startHeight, startYposPlatform;
    // floats for player height and arm length
    private float height, armLength;
    // floats to track the original z-position of the target field and object
    public float startZposField, startZposObject;
    // float to scale platform down to have room for projectile to rest on top of it
    private float offset;
    // float to scale the target position back by as the height scales
    private float multiplier;

    private float sub;
    // gameObject reference to the scene's ProjectileManager
    public GameObject projectileManager;

    void Awake()
    {
        startHeight = platform.transform.localScale.y;
        startYposPlatform = platform.transform.position.y;
        startZposField = targetField.transform.TransformPoint(Vector3.zero).z;
        startZposObject = targetObj.transform.TransformPoint(Vector3.zero).z;
        offset = GlobalControl.Instance.offset;
        multiplier = GlobalControl.Instance.multiplier;
        height = GlobalControl.Instance.height;
        armLength = GlobalControl.Instance.armLength;
        sub = GlobalControl.Instance.sub;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalControl.Instance.isRightHanded)
        {
            platform.transform.position = new Vector3(platform.transform.position.x + 1.056f, platform.transform.position.y, platform.transform.position.z);
        }
        AdjustPlatform();
        AdjustTarget();
        SpawnProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        height = GlobalControl.Instance.height;
        armLength = GlobalControl.Instance.armLength;
    }

    public void AdjustTarget()
    {
        Debug.Log("Adjusting Target");
        targetField.transform.position = new Vector3(targetField.transform.position.x, targetField.transform.position.y, startZposField + (height * multiplier - sub));
        targetObj.transform.position = new Vector3(targetObj.transform.position.x, targetObj.transform.position.y, startZposObject + (height * multiplier - sub));
    }

    public void AdjustPlatform()
    {
        Debug.Log("Adjusting Platform");
        platform.transform.localScale = new Vector3(platform.transform.localScale.x, startHeight + armLength - offset, platform.transform.localScale.z);
        platform.transform.position = new Vector3(platform.transform.position.x, startYposPlatform + (platform.transform.localScale.y / 2), platform.transform.position.z);
    }

    public void SpawnProjectile()
    {
        Debug.Log("Spawning " + projectilePrefab.name);
        projectileInstance = (GameObject)Instantiate(projectilePrefab, new Vector3(platform.transform.position.x, 
            platform.transform.localScale.y + projectilePrefab.transform.localScale.y, platform.transform.position.z), Quaternion.identity);
        GameObject[] newProjectiles = new GameObject[projectileManager.GetComponent<ProjectileManager>().projectiles.Length + 1];
        int i;
        for (i = 0; i < projectileManager.GetComponent<ProjectileManager>().projectiles.Length; i++)
        {
            newProjectiles[i] = projectileManager.GetComponent<ProjectileManager>().projectiles[i];
        }
        newProjectiles[i] = projectileInstance;
        projectileManager.GetComponent<ProjectileManager>().projectiles = newProjectiles;
        projectileManager.GetComponent<ProjectileManager>().AdditionalArrays();
    }
}
