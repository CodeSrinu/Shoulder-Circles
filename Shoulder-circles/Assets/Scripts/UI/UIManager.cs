using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject menuPanel, diffSelectPanel, hudPanel, pauseMenu, settingsMenu, leaderboard, analyticsPanel, graphPanel, gameOverPanel, levelCompletedPanel;
    [SerializeField] private Button startButton, beginnerBtn, moderateBtn, expertBtn,pauseBtn, resumeBtn, pauseMenuExitBtn, pauseMenuRestartBtn, settingsBtn, leaderboardNxtBtn, analyticsNxtBtn, graphNxtBtn, gameOverNextBtn, gameOverRestartBtn, levelCompleteNxtBtn, levelCompleteRestartBtn;
    // [SerializeField] private AudioManager audioManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    private void Start()
    {
        // if (startButton) startButton.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowDifficultySelection(); });
        // if (beginnerBtn) beginnerBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowHUD(); audioManager.StartMusic(); });
        // if (moderateBtn) moderateBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowHUD(); audioManager.StartMusic(); });
        // if (expertBtn) expertBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowHUD(); audioManager.StartMusic(); });
        // if (leaderboardNxtBtn) leaderboardNxtBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowAnalyticsStats(); });
        // if (analyticsNxtBtn) analyticsNxtBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowAnalyticsGraph(); });
        // if (graphNxtBtn) graphNxtBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); Restart(); });
        // if (gameOverNextBtn) gameOverNextBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowLeaderboard(); });
        // if (gameOverRestartBtn) gameOverRestartBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); Restart(); });
        // if (settingsBtn) settingsBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowSettings(); });
        // if (pauseMenuRestartBtn) pauseMenuRestartBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); Restart(); });
        // if (pauseBtn) pauseBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowPause(); beatManager.Pause(); playerControl.Pause();});
        // if (resumeBtn) gameOverRestartBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowHUD(); beatManager.Resume(); playerControl.Resume(); });
        // if (levelCompleteNxtBtn) levelCompleteNxtBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); ShowLeaderboard(); });
        // if (levelCompleteRestartBtn) levelCompleteRestartBtn.onClick.AddListener(() => { audioManager.PlayButtonClick(); Restart();});

        ShowMenu();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && hudPanel.activeSelf) ShowSettings();
    }

    public void UpdateScore(float score)
    {
        scoreText.text = "Score: " + score;
    }

    private void HideAll()
    {
        menuPanel.SetActive(false);
        diffSelectPanel.SetActive(false);
        hudPanel.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverPanel.SetActive(false);
        levelCompletedPanel.SetActive(false);
        settingsMenu.SetActive(false);
        leaderboard.SetActive(false);
        analyticsPanel.SetActive(false);
        graphPanel.SetActive(false);
    }


    public void ShowMenu()
    {
        HideAll();
        menuPanel.SetActive(true);
    }

    public void ShowDifficultySelection()
    {
        HideAll();
        diffSelectPanel.SetActive(true);
    }

    public void ShowHUD()
    {
        HideAll();
        hudPanel.SetActive(true);
    }

    public void ShowPause()
    {
        pauseMenu.SetActive(true);
    }

    public void HidePause()
    {
        pauseMenu.SetActive(false);
    }

    public void ShowGameOver()
    {
        HideAll();
        gameOverPanel.SetActive(true);
    }

    public void ShowLevelComplete()
    {
        HideAll();
        levelCompletedPanel.SetActive(true);
    }

    public void ShowSettings()
    {
        settingsMenu.SetActive(true); 
    }

    public void HideSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void ShowLeaderboard()
    {
        HideAll();
        leaderboard.SetActive(true);
    }

    public void ShowAnalyticsStats()
    {
        HideAll();
        analyticsPanel.SetActive(true);
    }

    public void ShowAnalyticsGraph()
    {
        HideAll();
        graphPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


