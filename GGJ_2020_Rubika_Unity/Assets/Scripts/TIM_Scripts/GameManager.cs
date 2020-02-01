using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public Text Perdu;
    public Text Gagne;
    public float restartDelay = 5f;
    public void EndGame()
    {
        if (gameHasEnded==false)
        {
            gameHasEnded = true;
            Perdu.text = "Better Luck Next Time!";
            Invoke("Restart", restartDelay);
        }
    }
    public void WinGame()
    {
        if (gameHasEnded==false)
        {
            gameHasEnded = true;
            Gagne.text = "GG EZ";
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
