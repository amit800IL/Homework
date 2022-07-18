using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public Text scoreText;
    //public int scoreNum = 0;
    public Transform player;
    public PlayerMovement playerMovement;
    private float PlayerStartingZ;
    private void Start()
    {
        playerMovement.OnFailure.AddListener(OnPlayerDeath);
        PlayerStartingZ = player.position.z;
        instance = this;
    }

    public void ResetScore()
    {
        //scoreNum = 0;
    }
    public void OnPlayerDeath()
    {
        ResetScore();
        playerMovement.transform.position = new Vector3(0, 0, 0);
    }


    private void Update()
    {
        //if (playerMovement.isGrounded == true)
        //{
        //    scoreNum = Mathf.RoundToInt(PlayerStartingZ - player.position.z);
        //    scoreText.text = "Score: " + scoreNum.ToString();
        //}

    }

}
