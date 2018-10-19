using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject dialogFrame;
    public GameObject player;
    public AudioSource audioSource;
    public AudioSource audioSourceVictory;

    private PlayerController playerController;
    private Text victoryText;

    private bool winMusicPlaying = false;

    // Use this for initialization
    void Start () {
        audioSourceVictory.Stop();
        audioSource.loop = true;
        audioSource.Play();
        dialogFrame.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
        victoryText = dialogFrame.transform.GetChild(1).GetComponent<Text>();
        victoryText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            //Application.Quit();
        }

        if(playerController.cassetteDelivered && playerController.capeDelivered)
        {
            if(!winMusicPlaying)
            {
                audioSource.Stop();
                audioSourceVictory.Play();
                winMusicPlaying = true;
            }            
            victoryText.text = "HAS SALVADO LA NAVIDAD";
            dialogFrame.SetActive(true);
            victoryText.enabled = true;            
        }
    }
}
