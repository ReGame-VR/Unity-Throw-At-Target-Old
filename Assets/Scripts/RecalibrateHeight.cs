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
        if (!calibrationComplete)
        {
            heightDisp.text = "HMD Height = " + player.GetComponent<OVRPlayerController>().CameraHeight;
            armLengthDisp.text = "Arm Length = " + player.GetComponent<OVRPlayerController>().CameraHeight;
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            calibrationComplete = true;
        }
    }
}
