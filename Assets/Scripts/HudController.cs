using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

    public GameObject player;

    private PlayerController playerController;
    private Image cassetteImage;
    private Image capeImage;

    // Use this for initialization
    void Start () {
        cassetteImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        cassetteImage.enabled = false;
        capeImage = gameObject.transform.GetChild(1).GetComponent<Image>();
        capeImage.enabled = false;
        playerController = player.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		if(playerController.hasCassette && !cassetteImage.enabled)
        {
            cassetteImage.enabled = true;
        }
        if(!playerController.hasCassette && cassetteImage.enabled)
        {
            cassetteImage.enabled = false;
        }
        if (playerController.hasCape && !capeImage.enabled)
        {
            capeImage.enabled = true;
        }
        if (!playerController.hasCape && capeImage.enabled)
        {
            capeImage.enabled = false;
        }
    }
}
