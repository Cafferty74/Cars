using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text pointsLabel;
    

    public void RefreshUI(Score score)
    {
        pointsLabel.text = $"{score.points}";
    }

    public void StopGame()
    {
        pointsLabel.text = "lost";
    }
}
