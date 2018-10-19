using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour {

    public GameObject player;
    public SpriteRenderer radioBubble;
    public GameObject dialogFrame;   

    private PlayerController playerController;
    private DialogController dialogController;


    // Use this for initialization
    void Start () {
        radioBubble.enabled = false;        
        playerController = player.GetComponent<PlayerController>();
        dialogController = dialogFrame.GetComponent<DialogController>();
    }
	
	// Update is called once per frame
	void Update () {
        var dist = Vector2.Distance(this.transform.position, player.transform.position);
        //Debug.Log("Distance radio: " + dist);
        if (dist < 1.7f)
        {
            if (!radioBubble.enabled)
            {
                radioBubble.enabled = true;
            }
            if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {                
                if(playerController.hasCassette)
                {
                    dialogController.ActivateDialog("¡Eh, funciona! Se me van los pies con El Tamborilero");
                    playerController.cassetteDelivered = true;
                }
                else
                {
                    dialogController.ActivateDialog("Anda, una radio de las de antes! Mi tía siempre escuchaba a Raphael en Navidad, la echo de menos...");
                }
                               
            }
        }
        else if(dist >= 1.5f && radioBubble.enabled)
        {
            radioBubble.enabled = false;
        }
    }
}
