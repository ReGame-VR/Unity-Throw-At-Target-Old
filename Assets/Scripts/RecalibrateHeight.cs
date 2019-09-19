using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/* Script to help calibrate the game to better accomodate players of different
 * heights, based on the HMD height as well as the distance from the HMD to
 * the handheld contrllers.
 */ 
public class RecalibrateHeight : MonoBehaviour
{
    // gameObject reference to OVRPlayerController prefab
    public GameObject player;
    // gameObject reference to CenterEyeAnchor, part of OVRPlayerController
    public GameObject centerEyeAnchor;
    // gameObject references to left hand and right hand controllers
    public GameObject leftHand, rightHand;
    // Boolean representing whether the player is right handed or left handed
    public bool isRightHanded;
    // gameObject reference to dominant hand
    private GameObject handController;
    // floats to track HMD height, as well as dominant arm length.
    private float height, armLength;
    // Reference to text objects to display height and arm length
    public TextMeshProUGUI heightDisp, armLengthDisp;
    // Boolean to stop accepting new data for height and arm length
    public bool calibrationComplete;
    // Start is called before the first frame update
    void Start()
    {
        if (isRightHanded)
        {
            handController = rightHand;
        }
        else
        {
            handController = leftHand;
        }
        calibrationComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        heightDisp.text = "HMD Height = " + height;
        armLengthDisp.text = "Left Arm Length = " + armLength;
        if (!calibrationComplete)
        {
            //height = player.GetComponent<OVRPlayerController>().CameraHeight;
            //armLength = Mathf.Abs(Vector3.Distance(centerEyeAnchor.transform.position, handController.transform.position));
            height = centerEyeAnchor.transform.position.y;
            armLength = handController.transform.position.y;

        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            calibrationComplete = true;
        }
    }

    // Getter method for calibrationComplete boolean
    public bool IsCalibrationComplete()
    {
        return calibrationComplete;
    }

    // Getter method for height float
    public float GetHeight()
    {
        return height;
    }

    // Getter method for armLength float
    public float GetArmLength()
    {
        return armLength;
    }
}
