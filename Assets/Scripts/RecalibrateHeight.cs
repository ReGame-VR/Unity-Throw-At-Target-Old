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
    // gameObject references to dominant hand controller
    public GameObject handController;
    // floats to track HMD height, as well as dominant arm length.
    float height, armLength;
    // Reference to text objects to display height and arm length
    public TextMeshProUGUI heightDisp, armLengthDisp;
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
        armLengthDisp.text = "Left Arm Length = " + armLength;
        if (!calibrationComplete)
        {
            height = player.GetComponent<OVRPlayerController>().CameraHeight;
            armLength = Mathf.Abs(Vector3.Distance(cameraRig.transform.position, handController.transform.position));

        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            calibrationComplete = true;
        }
    }
}
