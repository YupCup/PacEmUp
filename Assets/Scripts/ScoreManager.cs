using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject scoreAdd;
    int score = 0;

    public void IncreaseScore(int increase) {
        AddScoreToQueue(increase);
    }

    float timeUntilNextScore = 0;
    void AddScoreToQueue(int increase) {
        StartCoroutine(AddScore(increase, timeUntilNextScore));
        timeUntilNextScore += 0.1f;
    }

    IEnumerator AddScore(int increase, float waitTime) {
        yield return new WaitForSeconds(waitTime) ;
        timeUntilNextScore -= 0.1f;

        score += increase;
        UpdateScoreDisplay();

        TMP_Text scoreAddText = Instantiate(scoreAdd, scoreText.transform.parent).GetComponent<TMP_Text>();
        scoreAddText.text = "+" + increase.ToString();
        scoreAddText.transform.eulerAngles = Vector3.forward * Random.Range(-25f, 25f);
        scoreAddText.rectTransform.anchoredPosition = scoreAddText.transform.up * Random.Range(-25f, -75f);
        Destroy(scoreAddText.gameObject, .3f);
    }

    void UpdateScoreDisplay() {
        scoreText.text = score.ToString();
    }

    public static ScoreManager Instance;
    void Awake()
    {
        Instance = this;
    }
}
