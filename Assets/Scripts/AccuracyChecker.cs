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
    public TextMeshProUGUI missCounter;
    public TextMeshProUGUI distanceFromTarget;

    // Start is called before the first frame update
    void Start()
    {
        numHit = 0;
        numMiss = 0;
    }

    // Update is called once per frame
    void Update()
    {
        hitCounter.text = "Hit: " + numHit;
        missCounter.text = "Miss: " + numMiss;
        distanceFromTarget.text = "You missed by: " + distAway;
    }

    // When another object 
    private void OnTriggerEnter(Collider other)
    {
        // 
        if (other.CompareTag("Projectile"))
        {
            numHit += 1;
        }
    }

    public void Miss(Vector3 pos)
    {
        numMiss += 1;
        distAway = Math.Abs(Vector3.Distance(pos, this.transform.position));
    }
}
