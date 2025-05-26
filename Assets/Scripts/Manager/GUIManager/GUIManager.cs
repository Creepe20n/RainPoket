using UnityEngine;
using UnityEngine.UI;
public class GUIManager : MonoBehaviour,I_Manager
{

    [SerializeField] private Image pauseButtonImage;
    [SerializeField] private Sprite pauseGameIcon;
    [SerializeField] private Sprite unPauseGameIcon;
    [SerializeField] private GameManager gameManager;
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

    }


}
