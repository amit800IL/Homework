using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnCollision;
    [SerializeField] GameObject player;
    private Vector3 StartingPosition;
    [SerializeField] DragManager dragManager;
    bool IsColliding;
    [SerializeField] Transform[] goal;
    [SerializeField] AudioSource CoinCollecting;
    int currentGoal;
 
    private void Start()
    {
        StartingPosition = transform.position;
        IsColliding = false;
        currentGoal = 0;
        
       
        
        
      
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (IsColliding)
        {
            return;
            
        }

        if (collision.gameObject.CompareTag("Gate"))
        {
            StartCoroutine(GateRoutine());
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            ScoreSaver.Coins++;
            ScoreSaver.Score++;
            Destroy(collision.gameObject);
            OnCollision.Invoke();
            CoinCollecting.Play();
            
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ScoreSaver.Score -= 10;
            ScoreSaver.Coins = 0;
            ScoreSaver.collisionNum++;

            IsColliding = true;

            
            OnCollision.Invoke();

           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



        }
    }

    IEnumerator GateRoutine()
    {
        dragManager.canDrag = false;
        transform.position = goal[currentGoal].position;
        yield return new WaitForSeconds(1);
        dragManager.canDrag = true;
        currentGoal++;
        if (currentGoal > goal.Length - 1)
        {
           currentGoal = goal.Length - 1;   
        }
    }
}



