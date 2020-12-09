using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lifeCounterBehaviour : MonoBehaviour
{

    public GameObject[] lives;
    
    public static int life;

    public Text humansText;

    void Start()
    {
        life = 6;
    }
  
    void Update()
    {
        if (life < 1)
        {
            Destroy(lives[0].gameObject);
            SceneManager.LoadScene("Game_Over");
        }
        else if (life < 2)
        {
            Destroy(lives[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(lives[2].gameObject);
        }
        else if (life < 4)
        {
            Destroy(lives[3].gameObject);
        }
        else if (life < 5)
        {
            Destroy(lives[4].gameObject);
        }
        else if (life < 6)
        {
            Destroy(lives[5].gameObject);
        }
    }

    void LateUpdate()
    {
        humansText.text = life.ToString();
    }
}
