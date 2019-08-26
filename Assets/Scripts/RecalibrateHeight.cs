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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightShift))
        {

        }
    }
}
