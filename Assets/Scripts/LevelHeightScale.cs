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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (! this.GetComponent<RecalibrateHeight>().IsCalibrationComplete())
        {
            AdjustTarget();
            AdjustPlatform();
        }
    }

    void AdjustTarget()
    {
        //targetField.position =
    }

    void AdjustPlatform()
    {
        // IT JUST GOES uP, FIX IT
        platform.transform.localScale = new Vector3(platform.transform.localScale.x, platform.transform.localScale.y + this.GetComponent<RecalibrateHeight>().GetHeight(), platform.transform.localScale.z);
        platform.transform.position = new Vector3(platform.transform.position.x, 0 + (platform.transform.localScale.y / 2), platform.transform.position.z);
    }
}
