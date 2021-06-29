using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private Text _endScoreText;

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

    public static EndGame S;

    private void Awake()
    {
        if (S == null)
            S = this;
    }

    public void Death()
    {
        _deathPanel.SetActive(true);
        _deathPanel.GetComponent<Animation>().Play();
        StartCoroutine(ScoringPoints());
    }

    private IEnumerator ScoringPoints()
    {
        while (endScore < Score.S.scoreNumber)
        {
            endScore++;
            yield return new WaitForFixedUpdate();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
