using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class ghostControl : MonoBehaviour
{
    public NavMeshAgent follow;
    public Transform spawnpoint;
    public GameObject target;
    public MeshRenderer visibility;
    string color = "red";

    public AudioSource sound;
    public AudioClip deathsound;

    GameObject pacman;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        pacman = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && color == "red")
        {
            PlayerPrefs.SetInt("Score", pacman.GetComponent<pacmanControl>().Score);
            SceneManager.LoadScene("Scenes/GameOverScene");
        }

        else if (collision.gameObject.tag == "Player" && color == "blue")
        {
            TurnRed();
            target.transform.position = spawnpoint.position;
        }

        else if (collision.gameObject == target)
        {
            collision.gameObject.GetComponent<targets>().move();
        }        
    }

    void Update()
    {
        follow.destination = target.transform.position;
    }

    public void TurnBlue()
    {
        color = "blue";
    }

    public void TurnRed()
    {
        color = "red";
    }

}
