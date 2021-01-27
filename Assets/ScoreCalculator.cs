using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    private GameObject scoreText;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision other)
    {
        // タグによって得られる点数を変える
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 1;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }
        else if(other.gameObject.tag == "SmallCloudTag")
        {
            score += 5;
        }
        else if(other.gameObject.tag == "LargeCloudTag")
        {
            score += 3;
        }

        this.scoreText.GetComponent<Text>().text = "score: " + score;
    }
}
