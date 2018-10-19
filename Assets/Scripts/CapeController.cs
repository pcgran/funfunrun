using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapeController : MonoBehaviour {

    public GameObject player;
    public SpriteRenderer capeBubble;
    public GameObject dialogFrame;
        
    private PlayerController playerController;
    private DialogController dialogController;


    // Use this for initialization
    void Start () {
        capeBubble.enabled = false;
        playerController = player.GetComponent<PlayerController>();
        dialogController = dialogFrame.GetComponent<DialogController>();
    }
	
	// Update is called once per frame
	void Update () {
        var dist = Vector2.Distance(this.transform.position, player.transform.position);
        //Debug.Log("Distance: " + dist);
        if (dist < 1.5f)
        {
            if (!capeBubble.enabled)
            {
                capeBubble.enabled = true;
            }
            if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                dialogController.ActivateDialog("Tengo la capa de Ramonchu!");                  
                playerController.hasCape = true;
                gameObject.SetActive(false);
            }
        }
        else if(dist >= 1.5f && capeBubble.enabled)
        {
            capeBubble.enabled = false;
        }
    }
}
