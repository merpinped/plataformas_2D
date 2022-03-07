using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start: " + name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Paso de nivel!" + collision.gameObject.name);
        if (collision.gameObject.name == "PinkGuy")
        {
            Debug.Log("entro al trigger2D!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
