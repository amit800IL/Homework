using UnityEngine;
using UnityEngine.UI;

public class GameSystems : MonoBehaviour
{
    public static GameSystems instance;
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
        playerMovement.transform.position = new Vector3(0, 0, 0);
    }



}
