using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Vymaz()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreScript.Scorevalue = 0;


    }
}
