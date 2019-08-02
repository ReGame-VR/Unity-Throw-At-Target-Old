using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private GameObject[] projectiles;
    private Vector3[] transforms;
    private Quaternion[] rotations;
    public TextMeshProUGUI distAwayText;
    
    // Start is called before the first frame update
    void Start()
    {
        projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        Debug.Log(projectiles.Length);
        transforms = new Vector3[projectiles.Length];
        rotations = new Quaternion[projectiles.Length];
        for (int i = 0; i < projectiles.Length; i++)
        {
            transforms[i] = projectiles[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            ResetPositions();
        }
    }

    public void ResetPositions() {
        for (int i = 0; i < projectiles.Length; i++)
        {
            projectiles[i].transform.position = transforms[i];
            projectiles[i].transform.rotation = rotations[i];
            projectiles[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            projectiles[i].SendMessage("hasReset");
            projectiles[i].GetComponent<GroundChecker>().target.SendMessage("resetDistText");
        }

    }
}
