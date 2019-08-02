using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * Script tied to Target objects for tracking how many times a projectile
 * hits a target, and if it missed, how much it missed by.
 */
public class AccuracyChecker : MonoBehaviour
{
    private int numHit;
    private int numMiss;
    private float distAway;
    public TextMeshProUGUI hitCounter;
    //private String hitCounterText;
    public TextMeshProUGUI missCounter;
    //private String missCounterText;
    public TextMeshProUGUI distanceFromTarget;
    private String distanceFromTargetText;

    // Start is called before the first frame update
    void Start()
    {
        numHit = 0;
        numMiss = 0;
        distAway = 0;
        //hitCounter.text = "Hit: " + numHit;
        //missCounter.text = "Missed: " + numMiss;
        distanceFromTargetText = "Please throw the projectile to begin.";
    }

    // Update is called once per frame
    void Update()
    {
        hitCounter.text = "Hit " + numHit;
        missCounter.text = "Missed: " + numMiss;
        distanceFromTarget.text = distanceFromTargetText;
    }

    // Called when another object enters the trigger area of this target object.
    private void OnTriggerEnter(Collider other)
    {
        // If a projectile-tagged object hits the trigger, update the hit counter.
        if (other.gameObject.GetComponent<GroundChecker>().getTracking() && other.gameObject.CompareTag("Projectile"))
        {
            numHit += 1;
            other.gameObject.SendMessage("landed");
            distanceFromTargetText = "Target successfully hit!";
        }
    }

    public void Miss(Vector3 pos)
    {
        numMiss += 1;
        distAway = Math.Abs(Vector3.Distance(pos, this.transform.position));
        distanceFromTargetText = "You missed by: " + distAway;
    }

    private void resetDistText()
    {
        distanceFromTargetText = "Please throw the projectile to begin.";
    }
}
