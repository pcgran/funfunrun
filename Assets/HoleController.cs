using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleController : MonoBehaviour {

    public GameObject player;
    public GameObject dialogFrame;
    public GameObject rubbishWithCassette;
    public GameObject cape;
    public Animator ramonchuAnimator;
    public GameObject rubbishParent;

    private PlayerController playerController;
    private CassetteController cassetteController;
    private DialogController dialogController;

    // Use this for initialization
    void Start () {        
        playerController = player.GetComponent<PlayerController>();
        cassetteController = rubbishWithCassette.GetComponent<CassetteController>();
        dialogController = dialogFrame.GetComponent<DialogController>();
    }
	
	private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogController.ActivateDialog("Has caído por un agujero y has muerto. Vuelve a intentarlo!");
        playerController.hasCassette = false;
        playerController.hasCape = false;
        playerController.cassetteDelivered = false;
        playerController.capeDelivered = false;
        player.transform.position = playerController.startPosition;
        cassetteController.hasCassette = true;
        cape.SetActive(true);
        ramonchuAnimator.SetBool("cape_delivered", false);

        foreach (Transform rubbish in rubbishParent.transform)
        {
            var casseteController = rubbish.gameObject.GetComponent<CassetteController>();
            casseteController.updateSpriteToClosed();
        }
    }
}
