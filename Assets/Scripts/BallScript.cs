using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public float initSpeed = 10f;
    public float speedInc = 0.4f;
    public Text playerOne;
    public Text playerTwo;
    public AudioSource onHit;
    public AudioSource onTrigger;

    private int hitCounter;
    private Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 1f);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, initSpeed + (speedInc * hitCounter));
    }
    // Update is called once per frame
    private void StartBall()
    {
        rb.linearVelocity = new Vector2(-1,0)*(initSpeed+speedInc*hitCounter);
    }
    private void RestartBall()
    {
        rb.linearVelocity = new Vector2(0, 0);
        transform.position = new Vector2(0,0);
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }
    private void PlayerBounce(Transform obj)
    {
        hitCounter++;

        Vector2 ballPosition = transform.position;
        Vector2 playerPosition = obj.position;

        float xDirection;
        float yDirection;

        if (transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }
        yDirection = (ballPosition.y - playerPosition.y) / obj.GetComponent<Collider2D>().bounds.size.y;
        
        if(yDirection == 0)
        {
            yDirection = 0.25f;
        }
        if(Time.timeScale != 0)
        {
            rb.linearVelocity = new Vector2(xDirection, yDirection) * (initSpeed + (speedInc * hitCounter));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name =="PlayerOne" || collision.gameObject.name == "PlayerTwo")
        {
            onHit.Play();
            PlayerBounce(collision.transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTrigger.Play();
        if(transform.position.x > 0)
        {
            RestartBall();
            playerOne.text = (int.Parse(playerOne.text)+1).ToString();
        }
        else if(transform.position.x < 0)
        {
            RestartBall();
            playerTwo.text = (int.Parse(playerTwo.text) + 1).ToString();
        }
    }

}
