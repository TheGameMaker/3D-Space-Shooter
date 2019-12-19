using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class flyShip : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] GameObject[] guns;
    [SerializeField] private float Maxhealth = 100f;
    [SerializeField] private float health = 100f;
    [SerializeField] public int score = 0;
    [SerializeField] BarScript healthbar;

    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject UIH;
    [SerializeField] private GameObject UIS;
    [SerializeField] private Text scoreVAl;

    private bool collision = false;
    

    void Start()
    {
        // Debug.Log("fly ship script added to: " + gameObject.name);
        //  controller = GetComponent<CharacterController>();
        healthbar.MaxVal = Maxhealth;
        healthbar.Val = health;
        scoreVAl.text = score.ToString();
        UIH.SetActive(true);
        UIS.SetActive(true);
        deathScreen.SetActive(false);
    }

    void Update()
    {
        //Flight Controls
        transform.position += transform.forward * Time.deltaTime * speed;
        transform.Rotate((-Input.GetAxis("Vertical") * Time.deltaTime * 90), 0.0f, (-Input.GetAxis("Horizontal") * Time.deltaTime * 90));
        speed -= transform.forward.y * Time.deltaTime * 45f;

        //update score
        scoreVAl.text = score.ToString();

        //Boost
        if (Input.GetMouseButton(1))
        {
            speed += 10f;
        }  //Breaks
        else if (Input.GetMouseButton(2))
        {
            speed -= 10f;
            //Minimum speed;
            if (speed < 25f)
            {
                speed = 25f;
            }
        }
        else
        {
            if(speed > 100f)
            {
                speed -= 10f;
            }else if(speed < 100f)
            {
                speed += 10f;
            }
            else
            {
                speed = 100f;
            }
        }

      

        //GetButton("fire") for cross platform
        //Gun controls
        if (Input.GetMouseButton(0))
        {
            FireGuns(true);
        }
        else
        {
            FireGuns(false);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            if(score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (Input.GetKey(KeyCode.U) || collision)
        {
            health -= 5f;
            score += 5;
            scoreVAl.text = score.ToString();
        }

        if (collision)
        {
            health -= 10f;
        }

        //update health
        if (health <= Maxhealth)
        {
            updateHealth();
            health += 0.1f;
        } else if(Maxhealth > healthbar.MaxVal){
            healthbar.MaxVal = Maxhealth;
        }

        if(health <= 0)
        {
            UIH.SetActive(false);
            UIS.SetActive(false);
            Mesh nullMesh = null;
            this.gameObject.GetComponent<MeshFilter>().mesh = nullMesh;
            deathScreen.SetActive(true);
        }
    }

    private void FireGuns(bool isActive)
    {
        foreach(GameObject Gun in guns)
        {
            var emissionMod = Gun.GetComponent<ParticleSystem>().emission;
            emissionMod.enabled = isActive;
        }
    }

    private void updateHealth()
    {
        healthbar.Val = health;
    }


    //Collison
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.health -= 10f;
            this.score += 5;
            Destroy(other.gameObject);
        }
       // Debug.Log("player");
    }
}
