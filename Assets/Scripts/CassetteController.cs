using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CassetteController : MonoBehaviour {

    public GameObject player;
    public SpriteRenderer cassetteBubble;
    public GameObject dialogFrame;
    public Sprite rubbishOpen;
    public Sprite rubbishClosed;
        
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private DialogController dialogController;

    public bool hasCassette;


    // Use this for initialization
    void Start () {
        cassetteBubble.enabled = false;        
        playerController = player.GetComponent<PlayerController>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        dialogController = dialogFrame.GetComponent<DialogController>();
    }
	
	// Update is called once per frame
	void Update () {
        var dist = Vector2.Distance(this.transform.position, player.transform.position);
        //Debug.Log("Distance: " + dist);
        if (dist < 1.7f)
        {
            if (!cassetteBubble.enabled)
            {
                cassetteBubble.enabled = true;
            }
            if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                if(hasCassette)
                {
                    dialogController.ActivateDialog("Aquí hay una cinta!");
                    hasCassette = false;
                    playerController.hasCassette = true;
                }
                else
                {
                    dialogController.ActivateDialog("Solo hay basura...");
                }
               
                updateSpriteToOpened();
            }
        }
        else if(dist >= 1.5f && cassetteBubble.enabled)
        {
            cassetteBubble.enabled = false;
        }
    }

    public void updateSpriteToClosed()
    {
        spriteRenderer.sprite = rubbishClosed;
    }

    public void updateSpriteToOpened()
    {
        spriteRenderer.sprite = rubbishOpen;
    }
}
