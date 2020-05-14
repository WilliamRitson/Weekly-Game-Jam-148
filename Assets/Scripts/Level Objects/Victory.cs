using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public float clearOfEnemiesRadius;
    public string victorySceneName;
    public Transform messagePoint;

    // The player can win if the throne there are no enemies near the throne
    private bool CanWin()
    {
        var enemyExists = Physics2D.OverlapCircleAll(transform.position, clearOfEnemiesRadius)
            .FirstOrDefault(col => col.GetComponent<EnemyAI>() != null);
        return enemyExists == null;
    } 

    // When the player touches the throne, chceck if its clear of enemeis, if it is, they win
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (CanWin())
            {
                Win();

            }
            else
            {
                MovingTextManager.Instance.ShowMessage("Clear the room of enemies to claim the throne.", messagePoint.position, Color.white);
            }
        }
    }

    // Transition to victory scene
    void Win()
    {
        SceneManager.LoadScene(victorySceneName);
    }
}
