using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameObject active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && active.gameObject == isActiveAndEnabled)
        {
            Application.Quit();
        }
    }

    public void Konec()
    {
     Application.Quit();
    }
}
