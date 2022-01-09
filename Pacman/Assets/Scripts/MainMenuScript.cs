using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip intro;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.PlayOneShot(intro);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
