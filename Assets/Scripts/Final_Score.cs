using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_Score : MonoBehaviour
{

    Text final_score;
    // Start is called before the first frame update
    void Start()
    {
        final_score = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        final_score.text = "Tvoje finalni score je: " + ScoreScript.Scorevalue;
    }


}
