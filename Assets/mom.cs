using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mom : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            print("gameover!");
            SceneManager.LoadScene(1);

        }
    }

}
