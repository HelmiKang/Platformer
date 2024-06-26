using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CoralineController : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
  float speed = 5;

  [SerializeField]
  float jumpForce = 3000;

  [SerializeField]
  LayerMask groundLayer;

  Rigidbody2D rBody;
  bool hasReleasedJumpButton = true;



  void Awake()
  {
    rBody = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    // Debug.DrawLine(Vector2.zero, Vector2.down * 8, Color.green);

    float moveX = Input.GetAxisRaw("Horizontal");

    Vector2 movement = new Vector2(moveX, 0) * speed * Time.deltaTime;

    transform.Translate(movement);

    // bool isGrounded = Physics2D.OverlapCircle(GetFootPosition(), groundRadius, groundLayer);
    bool isGrounded = Physics2D.OverlapBox(GetFootPosition(), GetFootSize(), 0, groundLayer);
    // print(isGrounded);

    if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton == true && isGrounded)
    {
      rBody.AddForce(Vector2.up * jumpForce);
      hasReleasedJumpButton = false;
    }

    if (Input.GetAxisRaw("Jump") == 0)
    {
      hasReleasedJumpButton = true;
    }

    animator.SetFloat("speed", moveX);

    if (transform.position.y < -40)
    {
      print("gameover!");
      SceneManager.LoadScene(1);
    }

  }

  private Vector2 GetFootPosition()
  {
    float height = GetComponent<Collider2D>().bounds.size.y;
    return transform.position + Vector3.down * height / 2;
  }

  private Vector2 GetFootSize()
  {
    return new Vector2(GetComponent<Collider2D>().bounds.size.x * 0.9f, 0.1f);
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.DrawWireCube(GetFootPosition(), GetFootSize());

    
  }
}
