using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public GameObject target;
    private bool tracking;

    // Start is called before the first frame update
    void Start()
    {
        tracking = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tracking && collision.gameObject.CompareTag("Ground"))
        {
            target.SendMessage("Miss", this.transform.position);
            landed();
        }
    }

    public bool getTracking()
    {
        return tracking;
    }

    private void landed()
    {
        tracking = false;
    }

    private void hasReset()
    {
        tracking = true;
    }
}
