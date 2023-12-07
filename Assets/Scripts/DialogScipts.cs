using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScipts : MonoBehaviour
{

    public Text dialogText;
    
    public Dialog[] dialogs;
    public GameObject[] gameObjects;
    private int currentDialogIndex;
    private bool isDisplayingText;


    [System.Serializable]
    public class Dialog
    {
        [TextArea(3, 10)]
        public string dialog;
        public bool[] gameObjectsToActivate;
    }

    private void Start()
    {
        currentDialogIndex = 0;
        isDisplayingText = false;
        DisplayNextDialog();
    }

    private void Update()
    {
        // Check for tap or click input
        if (Input.GetMouseButtonDown(0) && !isDisplayingText)
        {
            DisplayNextDialog();
        }
    }

    private void DisplayNextDialog()
    {
        for (int i = 0; i < gameObjects.Length; i++) {
            if (dialogs[currentDialogIndex].gameObjectsToActivate[i]) {
                gameObjects[i].SetActive(true);
            } else {
                gameObjects[i].SetActive(false);
            }
        }
        if (currentDialogIndex < dialogs.Length)
        {
            StartCoroutine(DisplayDialog(dialogs[currentDialogIndex].dialog));
            currentDialogIndex++;
        }
        else
        {
            // All dialogs displayed, you can perform any other actions here
            Debug.Log("End of dialogs");
        }
    }

    private IEnumerator DisplayDialog(string dialog)
    {
        isDisplayingText = true;
        dialogText.text = "";

        foreach (char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }

        isDisplayingText = false;
    }
}
