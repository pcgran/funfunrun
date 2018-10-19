using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

    private float seconds;

	// Use this for initialization
	void Start () {
        seconds = 0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (gameObject.active)
        {
            if ((seconds * Time.deltaTime) > 1.5)
            {
                gameObject.SetActive(false);
                seconds = 0f;
            }
            else
            {
                seconds += 1;
            }

        }

    }

    public void ActivateDialog(string text)
    {
        gameObject.SetActive(true);
        gameObject.transform.GetChild(0).GetComponent<Text>().text = text;
    }
}
