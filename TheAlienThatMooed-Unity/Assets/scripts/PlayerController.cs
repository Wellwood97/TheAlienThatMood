using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
     
    public float speed;             //Floating point variable to store the player's movement speed.
    public float rocketspeed;
    private float currentspeed;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public Text countText;
    public Text winText;            //Store a reference to the UI Text component which will display the 'You win' message.
    private int count;                //Integer to store the number of pickups collected so far
    public GameObject heart1, heart2, heart3;
    public static int health;
    // Use this for initialization
    void Start()
    {


        {
            health = 3;
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
        }
        { //Get and store a reference to the Rigidbody2D component so that we can access it.
            rb2d = GetComponent<Rigidbody2D>();

            currentspeed = speed;

            //Initialize count to zero.
            count = 0;

            //Initialze winText to a blank string since we haven't won yet at beginning.
            winText.text = "YOU WON";

            //Call our SetCountText function which will update the text with the current value for count.
            SetCountText();
        }
        }


    private void Update() {
        if (health > 3)
            health = 3;

      switch (health)  {
         case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
         case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
         case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
         case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                Time.timeScale = 0;
                break;



        }
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * currentspeed);

    }











    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider. for (rocketfuel) sprite
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Fuel"))
        {
            other.gameObject.SetActive(false);
            currentspeed = rocketspeed;
            StartCoroutine(changespeedback());
        }
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("HP"))
        {
            other.gameObject.SetActive(false);
            PlayerController.health += 1;
        }
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("cow"))
        {
            other.gameObject.SetActive(false);

            //Add one to the current value of our count variable.
            count = count + 1;

            //Update the currently displayed count by calling the SetCountText function.
            SetCountText();
        }





    
}

    IEnumerator changespeedback()
    {
        yield return new WaitForSeconds(5);
        currentspeed = speed;

    }


    //This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
    void SetCountText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        countText.text = "Count: " + count.ToString();

        //Check if we've collected all 12 pickups. If we have...
        if (count >= 12)
            //... then set the text property of our winText object to "You win!"
            winText.text = "You win!";

    }
}

