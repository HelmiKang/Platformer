using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralineController : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

     [SerializeField]
    float JumpForce = 3000;


    Rigidbody2D RBody;
    bool hasJumped = false;

    void Awake()
        {
            RBody = GetComponent<Rigidbody2D>();
        }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

   float moveX = Input.GetAxisRaw("Horizontal");
    float moveY = Input.GetAxisRaw("Vertical");

    Vector2 movement = new Vector2(moveX, 0).normalized * speed * Time.deltaTime;

    transform.Translate(movement);

    if(Input.GetAxisRaw("Jump")>0 && hasJumped == true)
    {
        hasJumped = false;
        RBody.AddForce(Vector2.up*JumpForce);
    }
    if (Input.GetAxisRaw("Jump") == 0)
    {
        hasJumped = true;
    }
    }


}
