using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
  public GameObject uiTitle;
  public GameObject uiGameover;

  public bool IsReady { get; private set; }

  private void Start() {
    uiGameover.SetActive(false);
    uiTitle.SetActive(true);
    IsReady = false;
  }

  public void ShowGameOver() {
    uiGameover.SetActive(true);
    IsReady = false;
  }

  public void RestartGame() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void StartGame() {
    IsReady = true;
    uiTitle.SetActive(false);
  }
}