using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;
    public statManager player;
    public bool isActive;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<statManager>();

		if(textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableText();
        }
        else
        {
            DisableText();
        }
    }
	
	// Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine += 1;
        }

        if(currentLine > endAtLine)
        {
            DisableText();
        }
    }

    public void EnableText()
    {
        textBox.SetActive(true);
        isActive = true;
    }

    public void DisableText()
    {
        textBox.SetActive(false);
        isActive = false;
    }

    public void reload(TextAsset textfile)
    {
        if (textfile != null)
        {
            textLines = new string[1];
            textLines = (textfile.text.Split('\n'));

        }
    }
}