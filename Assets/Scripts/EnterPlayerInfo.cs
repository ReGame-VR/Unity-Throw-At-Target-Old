 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPlayerInfo : MonoBehaviour
{
    public TextMeshProUGUI test;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeText()
    {
        test.text = "Success!";
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Calibration");
    }
}
