using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{
    public Text PointsText;
    public AudioSource sound;
    public AudioClip endgamesound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.PlayOneShot(endgamesound);
        PointsText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }
}
