using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLvl1 : MonoBehaviour
{

    public Canvas can;

    int timeInSeconds = 3;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Movement player = other.gameObject.GetComponentInParent<Movement>();
        if (player)
        {
            if (Wait())
            {
                SceneManager.LoadScene(1);      //2
            }
        }
    }

    public bool Wait()
    {
        int i;
        for (i = 0; i < 30; i++)
        {

        }
        if (i >= 30)
        {
            return true;
        }

        return false;
    }
}