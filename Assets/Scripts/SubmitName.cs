using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubmitName : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button submitButton;

    public FirebaseInit firebaseManager;

    public void SubmitClicked()
    {
        string name = nameInput.text;
        int score = Score.GetCurrentScore();

        firebaseManager.AddScore(name, score);

        nameInput.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
    }
}
