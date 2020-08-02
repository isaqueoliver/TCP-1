using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMax : MonoBehaviour {
    public Text scoreM;
    public Text pontos;

    int scoreMax;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void ScoreTotal()
    {
        if (scoreMax < int.Parse(pontos.text))
        {
            scoreMax = int.Parse(pontos.text);
            scoreM.text = scoreMax.ToString();
        }
    }
}
