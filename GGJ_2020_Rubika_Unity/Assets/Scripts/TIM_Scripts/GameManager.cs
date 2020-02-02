using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    bool gameHasEnded = false;
    public Text Perdu;
    public Text Gagne;
    public GameObject vignette;
    public float restartDelay = 5f;
    private AudioManager audioManager;
    public string spawnSoundName;

    void Start()
    {
        vignette.SetActive(false);
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager found in the scene");
        }
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Perdu.text = "Better Luck Next Time!";
            vignette.SetActive(true);
            Invoke("Restart", restartDelay);
        }
    }
    public void WinGame()
    {
        if (gameHasEnded == false)
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

    // Update is called once per frame
    void Update()
    {

    }
    //pour jouer un son: audioManager.PlaySound("Gas");
}
