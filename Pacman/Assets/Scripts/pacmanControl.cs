using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using UnityEngine.UI;


public class pacmanControl : MonoBehaviour
{
    public Rigidbody rb;
    public LayerMask walls;

    public int Score;
    public Text ScoreText;

    GameObject[] ghosts;
    GameObject[] dots;

    int dotAmount;

    public float forwardForce = 1f;
    public float sidewaysForce = 1f;

    //joystick
    public int CMD;
    public SerialPort sp = new SerialPort("COM3", 57600);

    //sounds
    public AudioSource Sounds;
    public AudioClip dotsound;
    public AudioClip fruitsound;


    private void Start()
    {
        //joystick
        sp.Open();
        sp.ReadTimeout = 1;
        Debug.Log(sp.IsOpen);
        //-------------------

        Sounds = GetComponent<AudioSource>();

        Score = 0;
        SetScoreText();

        rb = GetComponent<Rigidbody>();
        ghosts = GameObject.FindGameObjectsWithTag("ghost");
        dots = GameObject.FindGameObjectsWithTag("sdot");
        dotAmount = dots.Length;        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="sdot")
        {
            Destroy(collision.gameObject);
            Sounds.PlayOneShot(dotsound);
            Score = Score + 10;
            SetScoreText();
            dotAmount--;
            Debug.Log(dotAmount);

            if (dotAmount==0)
            {
                PlayerPrefs.SetInt("Score", Score);
                SceneManager.LoadScene("Scenes/EndGameScene");
            }
        }

        if (collision.gameObject.tag=="bdot")
        {
            Destroy(collision.gameObject);
            Sounds.PlayOneShot(fruitsound);
            foreach (GameObject ghost in ghosts)
            {
                ghost.GetComponent<ghostControl>().TurnBlue();
            }
        }
    }

    void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();
    }

    void Move()
    {
        
        if (CMD == 6)
        {
            if (rb.velocity.z < -0.1 || rb.velocity.z > 0.1)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
            rb.AddForce(sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        else if (CMD == 4)
        {
            if (rb.velocity.z < -0.1 || rb.velocity.z > 0.1)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
            rb.AddForce(-sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        else if (Input.GetKey("w") || CMD == 8)
        {
           
            if (rb.velocity.x<-0.1 || rb.velocity.x > 0.1)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
            rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

        else if (Input.GetKey("s") || CMD == 2)
        {
            if (rb.velocity.x < -0.1 || rb.velocity.x > 0.1)
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
            rb.AddForce(0, 0, -forwardForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

       
    }
    
    void FixedUpdate()
    {
        if (sp.IsOpen)
        {
            try
            {
                ReadCom();
                Move();
            }
            catch (System.Exception)
            {
                
            }
        }
        else
        {
            Move();
        }

    }

    void ReadCom()
    {
        CMD = sp.ReadByte();
    }

    public void CloseCom()
    {
        sp.Close();
        Debug.Log("mclose");
    }




}
