using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EndingCollider : MonoBehaviour
{

    [SerializeField] GameDataManager gameDataManager;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameDataManager.WriteToJson();
            StartCoroutine(ReloadScene());

        }
    }

    public IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

