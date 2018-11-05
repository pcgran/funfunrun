using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        /*int DistanceAway = 10;
        Vector3 PlayerPOS = player.transform.transform.position;
        GameObject.Find("MainCamera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);*/
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
