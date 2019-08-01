using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject[] projectiles;
    public Vector3[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        Debug.Log(projectiles.Length);
        spawns = new Vector3[projectiles.Length];
        for (int i = 0; i < projectiles.Length; i++)
        {
            spawns[i] = projectiles[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            ResetPositions();
        }
    }

    public void ResetPositions() {
        for (int i = 0; i < projectiles.Length; i++)
        {
            projectiles[i].transform.position = spawns[i];
        }
    }
}
