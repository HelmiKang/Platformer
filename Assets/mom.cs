using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mom : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.right * speed * Time.deltaTime;

        transform.Translate(movement);


    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "coraline")
        {
            print("gameover!");
            SceneManager.LoadScene(1);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }
}
