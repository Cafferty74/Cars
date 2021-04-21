using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public Player player;


    Score score = new Score();


    public void HandleCollision(GameObject gameObject)
    {
        if (gameObject.tag == "Bonus")
            TakeBonus(gameObject);

        else if (gameObject.tag == "Obstacle")
            StopGame();
            
    }
    void TakeBonus(GameObject gameObject)
    {
        var bonus = gameObject.GetComponent<Bonus>();
        score.points += bonus.points;
        Destroy(gameObject);
        uiManager.RefreshUI(score);

    } 
   
    void StopGame()
    {
        uiManager.StopGame();
        player.GameOver = true;
    }

    void Update()
    {
    }
}
