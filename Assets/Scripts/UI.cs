using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
  public GameObject uiTitle;
  public GameObject uiGameover;
  public GameObject uiWin;
  public GameObject uiPause;
  public PlayerMovement playerControls;

  public bool IsReady { get; private set; }
  public bool IsPaused = false;
  

  private void Start() {
    uiWin.SetActive(false);
    uiPause.SetActive(false);
    uiGameover.SetActive(false);
    uiTitle.SetActive(true);
    IsReady = false;
    Time.timeScale = 0f;
  }

  void Update() {
        if (playerControls.gpa == 0f){
            uiGameover.SetActive(true);
        }
    }

  public void ShowGameOver() {
    uiGameover.SetActive(true);
    IsReady = false;
    Time.timeScale = 0f;
  }

  public void RestartGame() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void StartGame() {
    IsReady = true;
    uiTitle.SetActive(false);
    Time.timeScale = 1f;
  }

  public void PauseGame() {
        uiPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnpauseGame() {
        uiPause.SetActive(false);
        Time.timeScale = 1f;
    }

  public void WinGame() {
        uiWin.SetActive(true);
        Time.timeScale = 0f;
    }
}