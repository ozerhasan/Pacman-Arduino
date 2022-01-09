using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour
{

    public Text PointsText;
    public AudioSource sound;
    public AudioClip gameoversound;


    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.PlayOneShot(gameoversound);
        PointsText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }
}
