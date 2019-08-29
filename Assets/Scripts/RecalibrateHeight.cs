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
    // gameObject reference to OVRCameraRig, part of OVRPlayerController
    public GameObject cameraRig;
    // gameObject references to controllers
    public GameObject leftHand, rightHand;
    // floats to track HMD height, as well as left and right arm lengths.
    float height, leftArmLength, rightArmLength;
    // Reference to text objects to display height and arm length
    public TextMeshProUGUI heightDisp, leftArmLengthDisp, rightArmLengthDisp;
    // Boolean to stop accepting new data for height and arm length
    public bool calibrationComplete;
    // Start is called before the first frame update
    void Start()
    {
        calibrationComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        heightDisp.text = "HMD Height = " + height;
        leftArmLengthDisp.text = "Left Arm Length = " + leftArmLength;
        rightArmLengthDisp.text = "Right Arm Length = " + rightArmLength;
        if (!calibrationComplete)
        {
            height = player.GetComponent<OVRPlayerController>().CameraHeight;
            leftArmLength = Mathf.Abs(Vector3.Distance(cameraRig.transform.position, leftHand.transform.position));
            rightArmLength = Mathf.Abs(Vector3.Distance(cameraRig.transform.position, rightHand.transform.position));
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            calibrationComplete = true;
        }
    }
}
