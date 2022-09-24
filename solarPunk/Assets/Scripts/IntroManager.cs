using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class IntroManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI introText;
    [SerializeField] GameObject continueButton;

    [SerializeField] string[] introParagraphs;

    [SerializeField] float textSpeed;

    private int _index;
    
    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        //Activate continue button
        if (introText.text == introParagraphs[_index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in introParagraphs[_index].ToCharArray())
        {
            introText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void Game()
    {
        SceneManager.LoadScene(2);
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (_index < introParagraphs.Length - 1)
        {
            _index++;
            introText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

}
