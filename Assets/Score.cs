using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public GameObject UIScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Marquer()
    {
        score += 1;
        UIScore.GetComponent<TextMeshProUGUI>().SetText("Score : " + score);
    }
}
