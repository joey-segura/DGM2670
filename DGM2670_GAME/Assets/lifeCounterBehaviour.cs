﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeCounterBehaviour : MonoBehaviour
{

    public GameObject[] lives;
    
    public static int life;

    void Start()
    {
        life = 6;
    }
    
    void Update()
    {
        if (life < 1)
        {
            Destroy(lives[0].gameObject);
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
}
