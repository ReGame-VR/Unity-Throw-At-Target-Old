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
    // Start is called before the first frame update
    void Start()
    {
        startHeight = platform.transform.localScale.y;
        startYpos = platform.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (! (this.GetComponent<RecalibrateHeight>().IsCalibrationComplete()))
        {
            AdjustTarget();
            AdjustPlatform();
        }
        else
        {
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
        platform.transform.localScale = new Vector3(platform.transform.localScale.x, startHeight + this.GetComponent<RecalibrateHeight>().GetHeight(), platform.transform.localScale.z);
        platform.transform.position = new Vector3(platform.transform.position.x, startYpos + (platform.transform.localScale.y / 2), platform.transform.position.z);
    }
}
