using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public GameObject score_object = null;
    public static int result =0;
    // Start is called before the first frame update
    void Start()
    {
        int result = ScoreManager.score_num;
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "Score:"+ result;
        ScoreManager.score_num=0;
    }

// Update is called once per frame
void Update()
{
    
}
}