using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private int _scoreNumber;
    public int scoreNumber
    {
        get => _scoreNumber;
        set
        {
            _scoreNumber = value;
        }
    }

    public static Score S;
    private void Awake()
    {
        if (S == null)
            S = this;
    }

    private void Start()
    {
        scoreNumber = 0;
        _scoreText.text = scoreNumber.ToString();
    }

    public void AddScore(int number)
    {
        scoreNumber += number;
        StartCoroutine(SmoothAddition(number));

        //scoreNumber += number;
    }

    private IEnumerator SmoothAddition(int newNumber)
    {
        int startNumber = scoreNumber - newNumber;
        int endNumber = scoreNumber;
        while (startNumber < endNumber)
        {
            startNumber++;
            _scoreText.text = startNumber.ToString();
            yield return new WaitForFixedUpdate();
        }
    }
}
