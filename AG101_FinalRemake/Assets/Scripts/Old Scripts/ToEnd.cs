﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEnd : MonoBehaviour
{

    public Canvas can;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Movement player = other.gameObject.GetComponentInParent<Movement>();


        if (player)
        {
            SceneManager.LoadScene(5);
        }
    }
}
