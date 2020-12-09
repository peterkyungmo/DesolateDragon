using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            int c = SceneManager.GetActiveScene().buildIndex;
            if (c < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(c + 1);
            }
        }
    }
}
