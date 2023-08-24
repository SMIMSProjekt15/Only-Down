using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    public RowUI rowUI;
    public ScoreManager scoreManager;

    private void Start()
    {
        scoreManager.AddScore(new Score("name", 6));
        scoreManager.AddScore(new Score("name2", 66));
        

        var scores = scoreManager.GetHighScores().ToArray();
        for(int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}
