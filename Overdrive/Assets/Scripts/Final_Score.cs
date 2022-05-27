using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Final_Score : MonoBehaviour
{
    TextMeshProUGUI Score;
    public Score currentScore;
    
        
    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            //set new score if different from current one
            if (currentScore.PlayerScore.ToString() != Score.text)
            {
                Score.text = currentScore.PlayerScore.ToString("0.0");
            }
        }        
    }
}
