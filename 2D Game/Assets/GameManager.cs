using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;

    public void EndGame()
    {
        if (gameOver == false)
        {
            gameOver = true;

            Invoke("Restart", 2f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
