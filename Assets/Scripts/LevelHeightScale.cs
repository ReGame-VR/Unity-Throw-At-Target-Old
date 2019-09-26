using System.Collections;
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
    private float startHeight, startYpos;
    // floats to track the original z-position of the target
    private float startZpos;
    // float to scale platform down to have room for projectile to rest on top of it
    private float offset;
    // float to scale the target position back by as the height scales
    private float multiplier;
    // bool to prevent multiple projectile spawns
    private bool projectileSpawned;
    // gameObject reference to the scene's ProjectileManager
    public GameObject projectileManger;
    // Start is called before the first frame update
    void Start()
    {
        startHeight = platform.transform.localScale.y;
        startYpos = platform.transform.position.y;
        offset = 0.13f;
        multiplier = 2.0f;
        if (this.GetComponent<RecalibrateHeight>().isRightHanded)
        {
            platform.transform.position = new Vector3(platform.transform.position.x * -1f, platform.transform.position.y, platform.transform.position.z);
        }
        projectileSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (! (this.GetComponent<RecalibrateHeight>().IsCalibrationComplete()))
        {
            AdjustTarget();
            AdjustPlatform();
        }
        if ((this.GetComponent<RecalibrateHeight>().IsCalibrationComplete()) && !projectileSpawned)
        {
            SpawnProjectile();
            Debug.Log("Calibration complete");
        }
    }

    void AdjustTarget()
    {
        targetField.transform.position = new Vector3(targetField.transform.position.x, targetField.transform.position.y, startZpos + (this.GetComponent<RecalibrateHeight>().GetHeight() * multiplier));
        targetObj.transform.position = new Vector3(targetObj.transform.position.x, targetObj.transform.position.y, startZpos + (this.GetComponent<RecalibrateHeight>().GetHeight() * multiplier));
    }

    void AdjustPlatform()
    {
        Debug.Log("Adjusting Platform");
        platform.transform.localScale = new Vector3(platform.transform.localScale.x, startHeight + this.GetComponent<RecalibrateHeight>().GetArmLength() - offset, platform.transform.localScale.z);
        platform.transform.position = new Vector3(platform.transform.position.x, startYpos + (platform.transform.localScale.y / 2), platform.transform.position.z);
    }

    void SpawnProjectile()
    {
        projectileSpawned = true;
        projectileInstance = (GameObject)Instantiate(projectilePrefab, new Vector3(platform.transform.position.x, 
            platform.transform.localScale.y + projectilePrefab.transform.localScale.y, platform.transform.position.z), Quaternion.identity);
        GameObject[] newProjectiles = new GameObject[projectileManger.GetComponent<ProjectileManager>().projectiles.Length + 1];
        int i;
        for (i = 0; i < projectileManger.GetComponent<ProjectileManager>().projectiles.Length; i++)
        {
            newProjectiles[i] = projectileManger.GetComponent<ProjectileManager>().projectiles[i];
        }
        newProjectiles[i] = projectileInstance;
        projectileManger.GetComponent<ProjectileManager>().projectiles = newProjectiles;
        projectileManger.GetComponent<ProjectileManager>().AdditionalArrays();
    }
}
