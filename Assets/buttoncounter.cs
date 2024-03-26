using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class buttoncounter : MonoBehaviour
{
    public static buttoncounter instance;
    public TMP_Text buttonText;
    public int currentButtons = 0;


    // Start is called before the first frame update
    void Awake() {
        instance = this;
    }
    void Start()
    {
        buttonText.text = "Buttons:" + currentButtons.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    if (currentButtons == 4)
    {
      print("You win!");
      SceneManager.LoadScene(2);
    }
    }

    public void increaseButtons( int v)
    {
        currentButtons += v;
        buttonText.text= "Buttons:" + currentButtons.ToString();
    }
}
