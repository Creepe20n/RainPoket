using UnityEngine;
using UnityEngine.UI;
public class GUIManager : MonoBehaviour,I_Manager
{

    [SerializeField] private Image pauseButtonImage;
    [SerializeField] private Sprite pauseGameIcon;
    [SerializeField] private Sprite unPauseGameIcon;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator[] fadeAni;
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
        for (int i = 0; i < fadeAni.Length; i++)
        {
            fadeAni[i].Play("FadeIn");
        }
    }


}
