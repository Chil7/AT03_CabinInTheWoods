using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipText : MonoBehaviour
{
    [SerializeField] private Text tooltipText;
    [SerializeField] private GameObject popUpDisplay;

    private MouseLook mouseLook;

    private int currentScore;

    private void Awake()
    {
        mouseLook = FindObjectOfType<MouseLook>();
    }

    private void Start()
    {
        UpdateToolTipDisplay(0);

        if(popUpDisplay.activeSelf == true)
        {
            TogglePopUp();
        }
    }

    //Enables Mouse cursor on screen
    public bool CursorEnabled
    {
        set
        {
            Cursor.visible = value;
            if (value == true)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public bool ToggleMouseLook()
    {
        mouseLook.enabled = !mouseLook.enabled;
        return mouseLook.enabled;
    }

    public bool TogglePopUp()
    {
        popUpDisplay.SetActive(!popUpDisplay.activeSelf);
        CursorEnabled = popUpDisplay.activeSelf;
        return popUpDisplay.activeSelf;
    }

    public void UpdateToolTipDisplay(int score)
    {
        currentScore += score;
        tooltipText.text = currentScore + "/6 Tooltip";
        if(currentScore == 6)
        {
            TogglePopUp();
            ToggleMouseLook();
        }
    }

    public void TogglePopUpDisplay()
    {
        TogglePopUp();
        ToggleMouseLook();
    }
}

