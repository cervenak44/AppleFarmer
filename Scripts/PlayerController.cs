using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour { 

    private Rigidbody2D rb2d;
    private int count;

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    private bool gameOver = false;
    private bool timer = false;

    float currentTime = 0f;
    float startTime = 12f;


    public Text countdownText;

  
    

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        loseText.text = "";
        SetCountText();
        countText.text = "Count: " + count.ToString();
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
       rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            timer = true;
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "PickUp")
        {
            Destroy(coll.gameObject);
            count = count + 1;
            SetCountText();
            countText.text = "Count: " + count.ToString();
        }
    }

    void SetCountText()
    {
       
            countText.text = "Count: " + count.ToString();
            if (count > 5)
        {
            winText.text = "You Win!";
            Time.timeScale = 0;
        }
               

            if (count < 5)
        {
            gameOver = true;
        }
            
            if (gameOver == true && timer == true)
        {
            loseText.text = "You Lose, failed to collect within time frame";
            Time.timeScale = 0;
        }
        
    }
}

