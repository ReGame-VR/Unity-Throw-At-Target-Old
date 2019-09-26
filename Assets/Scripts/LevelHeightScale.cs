using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHeightScale : MonoBehaviour
{
    // gameObject reference to the projectile
    public GameObject projectile;
    // gameObject reference to platform the projectile rests on
    public GameObject platform;
    // gameObject reference to target area and physical target object to throw projectile at
    public GameObject targetField, targetObj;
    // floats to track original height and y-position of platform
    private float startHeight, startYpos;
    // float to scale platform down to have room for projectile to rest on top of it
    private float offset;
    // bool to prevent multiple projectile spawns
    private bool projectileSpawned;
    // Start is called before the first frame update
    void Start()
    {
        startHeight = platform.transform.localScale.y;
        startYpos = platform.transform.position.y;
        offset = 0.1f;
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
        //targetField.position =
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
        Instantiate(projectile, new Vector3(platform.transform.position.x, platform.transform.localScale.y + projectile.transform.localScale.y, platform.transform.position.z), Quaternion.identity);
    }
}
