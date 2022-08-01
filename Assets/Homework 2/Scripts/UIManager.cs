using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lastCoinText;
    [SerializeField] TextMeshProUGUI lastScoreText;
    [SerializeField] TextMeshProUGUI ColiisionNum;
    [SerializeField] TextMeshProUGUI lastCollisionNum;
 




    private void Start()
    {
        UpdateScore();
        UpdateCoins();
        UpdateLastScore();
        UpdateLastCoins();
        UpdateCollisionNumber();
        UpdateLastCollisionNumber();

    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + ScoreSaver.Score;
    }

    public void UpdateCoins()
    {
        coinsText.text = "coins : " + ScoreSaver.Coins;
    }

    public void UpdateLastScore()
    {
        lastScoreText.text = "Last Score : " + ScoreSaver.lastScore;
    }

    public void UpdateLastCoins()
    {
        lastCoinText.text = "Last Coin Amount : " + ScoreSaver.lastCoins;
    }

    public void UpdateCollisionNumber()
    {
        ColiisionNum.text = "Collisions : " + ScoreSaver.collisionNum;
    }

    public void UpdateLastCollisionNumber()
    {
        lastCollisionNum.text = "Last Collision Amount : " + ScoreSaver.lastCollisionNum;
    }


}
