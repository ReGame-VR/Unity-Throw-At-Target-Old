using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccuracyChecker : MonoBehaviour
{
    private int numHit;
    private int numMiss;
    public TextMeshProUGUI hitCounter;
    public TextMeshProUGUI missCounter;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            numHit += 1;
        }
    }
}
