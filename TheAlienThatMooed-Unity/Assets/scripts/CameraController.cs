using UnityEngine;
using System.Collections; 

public class cameracontroller : MonoBehaviour {

    public GameObject player;   //Public variable to store a reference to the player game object

    private Vector3 offset;   //Private variable to store the offset distance between the player and camera

    //Use this for initialization
    void Start ()
    {
        //calculate and store the offset value by geting the distance between the player's position and the camera's position.
        offset = transform.position - player.transform.position;

    }

    //LateUpdate is called after Update each frame
    void LateUpdate ()
    {
        //Set the position of th ecamera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}