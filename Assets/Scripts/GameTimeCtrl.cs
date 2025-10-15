using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameCtrl : MonoBehaviour
{
    [Header("Time Setting")]
    [SerializeField] private float timeLimit = 60f;
    private float _timeRemaining;

    [Header("UI")]
    [SerializeField] private Slider timeBar;
    [SerializeField] private TMP_Text timerText;

    [Header("Links to other scripts")]
    [SerializeField] private GameMenuController gameMenuController;

    [Header("Blinking")]
    [SerializeField] private float blinkInterval = 0.5f;
    [SerializeField] private float blinkTimer = 0f;
    private bool isBlinkVisible = true;
    private bool isGameOver = false;
    private Image fillImage;

    void Start()
    {
        _timeRemaining = timeLimit;

        if (timeBar != null)
        {
            timeBar.maxValue = timeLimit;
            timeBar.value = timeLimit;

            fillImage = timeBar.fillRect.GetComponent<Image>();
        }
        UpdateUI();
    }

    void Update()
    {
        if (isGameOver) return;
        //Time reduction
        _timeRemaining -= Time.deltaTime;

        //Limit on 0
        if (_timeRemaining < 0)
        {
            _timeRemaining = 0;
            GameOverByTime();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timeBar != null)
        {
            timeBar.value = _timeRemaining;
            Color barColor = Color.Lerp(Color.red, Color.green, _timeRemaining / timeLimit);

            if (_timeRemaining <= 10f)
            {
                blinkTimer += Time.deltaTime;
                if (blinkTimer >= blinkInterval)
                {
                    blinkTimer = 0f;
                    isBlinkVisible = !isBlinkVisible;
                }

                if (!isBlinkVisible)
                    barColor = Color.red;
            }

            if (fillImage != null)
                fillImage.color = barColor;
        }

        if (timerText != null)
            timerText.text = Mathf.Ceil(_timeRemaining).ToString() + "s";

        if (_timeRemaining <= 10f)
            timerText.enabled = isBlinkVisible;
        else
            timerText.enabled = true;
    }

    void GameOverByTime()
    {
        isGameOver = true;
        
        if (gameMenuController != null)
            gameMenuController.GameOver();
    }
}
