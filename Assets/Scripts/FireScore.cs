using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FireScore : MonoBehaviour
{
    public TextMeshProUGUI FireScoreText;
    public int firescore = 0;
    public int maxfireScore = 0; 


    // Start is called before the first frame update
    void Start()
    {
        firescore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFireScore();
    }
    public void AddFireScore(int newFireScore) {
        firescore = newFireScore;
    }
    public void UpdateFireScore(){
        FireScoreText.text = "Score " + firescore;
    }
      public int getFireScore() {
        return firescore;
    }
}
