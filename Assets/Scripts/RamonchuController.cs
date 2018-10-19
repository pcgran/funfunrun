using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RamonchuController : MonoBehaviour {

    public GameObject player;
    public SpriteRenderer ramonchuBubble;
    public GameObject dialogFrame;    

    private PlayerController playerController;    
    private Animator animator;
    private DialogController dialogController;


    // Use this for initialization
    void Start () {
        ramonchuBubble.enabled = false;        
        playerController = player.GetComponent<PlayerController>();        
        animator = GetComponent<Animator>();
        dialogController = dialogFrame.GetComponent<DialogController>();
    }
	
	// Update is called once per frame
	void Update () {
        var dist = Vector2.Distance(this.transform.position, player.transform.position);
        //Debug.Log("Distance ramonchu: " + dist);
        if (dist < 1.7f)
        {
            if (!ramonchuBubble.enabled)
            {
                ramonchuBubble.enabled = true;
            }
            if(Input.GetKeyDown(KeyCode.X)|| Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Return))
            {                
                if(playerController.hasCape)
                {
                    dialogController.ActivateDialog("Feliz 1998!");
                    playerController.capeDelivered = true;
                    animator.SetBool("cape_delivered", true);                   
                }
                else
                {
                    dialogController.ActivateDialog("Hola moza, ¿has visto mi capa? Sin ella no puedo dar las campanadas... Como Anne se entere de que la he perdido me cruje.");
                }               
            }
        }
        else if(dist >= 1.5f && ramonchuBubble.enabled)
        {
            ramonchuBubble.enabled = false;
        }
       
    }
}
