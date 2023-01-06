using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUpdater : MonoBehaviour
{
    
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int[] highScores = HighScore.getHighScores();
        text1.GetComponent<Text>().text = "1. "+highScores[0].ToString();
        text2.GetComponent<Text>().text = "2. "+highScores[1].ToString();
        text3.GetComponent<Text>().text = "3. "+highScores[2].ToString();
        text4.GetComponent<Text>().text = "4. "+highScores[3].ToString();
        text5.GetComponent<Text>().text = "5. "+highScores[4].ToString();
    }
}
