using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private Text _endScoreText;
    [SerializeField] private Text _bestScoreText;


    private int _endScore;
    private int endScore
    {
        get => _endScore;
        set
        {
            _endScore = value;
            _endScoreText.text = _endScore.ToString();
        }
    }

    private int _bestScore
    {
        get => PlayerPrefs.GetInt("bestScore", 0);
        set
        {
            PlayerPrefs.SetInt("bestScore", value);
            _bestScoreText.text = _bestScore.ToString();
        }
    }

    public static EndGame S;

    private void Awake()
    {
        if (S == null)
            S = this;

        _bestScoreText.text = _bestScore.ToString();
        Cursor.visible = false;
    }

    public void Death()
    {
        Cursor.visible = true;
        _deathPanel.SetActive(true);
        _deathPanel.GetComponent<Animation>().Play();
        StartCoroutine(ScoringPoints());
    }

    private IEnumerator ScoringPoints()
    {
        while (endScore < Score.S.scoreNumber)
        {
            endScore += 10;
            yield return new WaitForFixedUpdate();
        }
        if (_bestScore < Score.S.scoreNumber)
            _bestScore = Score.S.scoreNumber;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
