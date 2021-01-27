using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    private GameObject scoreText;

    private int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
        this.currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision other)
    {
        int getScore = 0;//test
        // タグによって得られる点数を変える
        if (other.gameObject.tag == "SmallStarTag")
        {
            getScore = 1;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            getScore = 20;
        }
        else if(other.gameObject.tag == "SmallCloudTag")
        {
            getScore = 5;
        }
        else if(other.gameObject.tag == "LargeCloudTag")
        {
            getScore = 3;
        }

        this.currentScore += getScore;

        this.scoreText.GetComponent<Text>().text = currentScore.ToString();
    }
}
