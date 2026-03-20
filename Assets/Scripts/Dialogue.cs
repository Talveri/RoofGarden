using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index = 0;
    public PlayerInput playerInput;
    public bool inDialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
    }
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            // if the text still loads than it appears instantly
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            inDialogue = false;
            textComponent.text = string.Empty;
            playerInput.SwitchCurrentActionMap("Player");
            gameObject.SetActive(false);
        }
    }
    public void StartDialogue()
    {
        inDialogue = true;
        playerInput.SwitchCurrentActionMap("UI");
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        yield return null;
        textComponent.text = string.Empty;
        
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void UpdateText(string[] script)
    {
        lines = script;
    }
}
