using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GUIManager : MonoBehaviour, I_Manager
{
    // Unity Components
    [SerializeField] private Image pauseButtonImage;
    [SerializeField] private Animator[] fadeAni;
    [SerializeField] private Animator DeathAni;
    [SerializeField] private TextMeshProUGUI scoreText;
    // Sprites
    [SerializeField] private Sprite pauseGameIcon;
    [SerializeField] private Sprite unPauseGameIcon;
    // Managers
    [SerializeField] private GameManager gameManager;
    // State
    private bool blockPlayerDead = false;
    public void OpenMenu()
    {
        gameManager.CanStartGame = false;
    }
    public void CloseMenu()
    {
        gameManager.CanStartGame = true;
    }

    public void GameStart()
    {
        blockPlayerDead = false;
        for (int i = 0; i < fadeAni.Length; i++)
        {
            fadeAni[i].Play("FadeOut");
        }
    }

    public void PauseGame()
    {
        pauseButtonImage.sprite = unPauseGameIcon;
    }
    public void UnPauseGame()
    {
        pauseButtonImage.sprite = pauseGameIcon;
    }
    public void GameEnd()
    {
        DeathAni.gameObject.SetActive(false);
        for (int i = 0; i < fadeAni.Length; i++)
        {
            fadeAni[i].Play("FadeIn");
        }
    }

    private void PlayerIsDead()
    {
        blockPlayerDead = true;

        DeathAni.gameObject.SetActive(true);
        DeathAni.Play("DeathStart");

    }

    void Update()
    {
        scoreText.text = gameManager.Score.ToString();

        if (gameManager.PlayerDied && !blockPlayerDead)
            PlayerIsDead();

    }
}
