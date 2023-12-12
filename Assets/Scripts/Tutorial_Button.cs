using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Button : MonoBehaviour
{
    public GameObject First_Tutorial;
    public GameObject Second_Tutorial;
    public GameObject Third_Tutorial;
    public GameObject Forth_Tutorial;
    public GameObject Fifth_Tutorial;

    public void PreviousButton_Click()
    {
        if(First_Tutorial.activeSelf == true)
        {
            First_Tutorial.SetActive(false);
            Fifth_Tutorial.SetActive(true);
        }
        else if (Second_Tutorial.activeSelf == true)
        {
            Second_Tutorial.SetActive(false);
            First_Tutorial.SetActive(true);
        }
        else if (Third_Tutorial.activeSelf == true)
        {
            Third_Tutorial.SetActive(false);
            Second_Tutorial.SetActive(true);
        }
        else if (Forth_Tutorial.activeSelf == true)
        {
            Forth_Tutorial.SetActive(false);
            Third_Tutorial.SetActive(true);
        }
        else if (Fifth_Tutorial.activeSelf == true)
        {
            Fifth_Tutorial.SetActive(false);
            Forth_Tutorial.SetActive(true);
        }
    }

    public void NextButton_Click()
    {
        if (First_Tutorial.activeSelf == true)
        {
            First_Tutorial.SetActive(false);
            Second_Tutorial.SetActive(true);
        }
        else if (Second_Tutorial.activeSelf == true)
        {
            Second_Tutorial.SetActive(false);
            Third_Tutorial.SetActive(true);
        }
        else if (Third_Tutorial.activeSelf == true)
        {
            Third_Tutorial.SetActive(false);
            Forth_Tutorial.SetActive(true);
        }
        else if (Forth_Tutorial.activeSelf == true)
        {
            Forth_Tutorial.SetActive(false);
            Fifth_Tutorial.SetActive(true);
        }
        else if (Fifth_Tutorial.activeSelf == true)
        {
            Fifth_Tutorial.SetActive(false);
            First_Tutorial.SetActive(true);
        }
    }

}
