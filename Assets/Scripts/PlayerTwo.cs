using UnityEngine;
using UnityEngine.UI;

public class PlayerTwo : MonoBehaviour
{
    public float speed = 10f;
    public GameObject ball;
    public GameObject multiplayerMode;
    public GameObject sceneWraper;

    private bool modeType = true;
    private Text multiplayerText;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        multiplayerText = multiplayerMode.GetComponent<Text>();
        multiplayerMode.SetActive(false);
        sceneWraper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!modeType) {
            if (Input.GetKey(KeyCode.Keypad8))
            {
                movement =  new Vector2(0, 0.5f);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                movement = new Vector2(0, -0.5f);
            }
        }
        else
        {
            if (ball.transform.position.y > transform.position.y + 0.5f)
            {
                movement = new Vector2(0, 1);
            }
            else if (ball.transform.position.y < transform.position.y - 0.5f)
            {
                movement = new Vector2(0, -1);
            }
            else
            {
                movement = new Vector2(0, 0);
            }
        }


    }
    public void IsBot()
    {
        if (modeType)
        {
            modeType = false;
            multiplayerMode.SetActive(true);
            multiplayerText.text = "Multiplayer mode is on. Click for continue.";
        }
        else
        {
            modeType = true;
            multiplayerMode.SetActive(true);
            multiplayerText.text = "Multiplayer mode is off. Click for continue.";
        }
        Pause();
    }
    private void Pause()
    {
        sceneWraper.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        multiplayerMode.SetActive(false);
        sceneWraper.SetActive(false);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }
}
