using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;
    public int startLine;
    public int endLine;

    public TextImporter theTextBox;
    private bool waitForPress;
    public bool requireButtonPress;
    public bool destroywhenActive;
    // Use this for initialization
    void Start () {
        theTextBox = FindObjectOfType<TextImporter>();
  	}
	
	// Update is called once per frame
	void Update () {
		if(waitForPress && Input.GetKeyDown(KeyCode.J))
        {
            theTextBox.reload(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableText();

            if (destroywhenActive)
            {
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            theTextBox.reload(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableText();

            if(destroywhenActive)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            waitForPress = false;
        }
    }
}
