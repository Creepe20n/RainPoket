using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private RectTransform gameCanvasRect;
    // Sprites
    [SerializeField] private Sprite pauseGameIcon;
    [SerializeField] private Sprite unPauseGameIcon;
    // Managers
    [SerializeField] private GameManager gameManager;
    // State
    private bool blockPlayerDead = true;
    //HeartGUI
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Sprite emptySprite;
    [SerializeField] private GameObject heartIMG;
    private GameObject[] spawnedGUIHearts = new GameObject[0];
    private Image[] spawnedGUIHeartSR;
    //player data
    int lastHealth;

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
        RebuildHeartUI();
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

        for (int i = 0; i < spawnedGUIHeartSR.Length; i++)
        {
            spawnedGUIHearts[i].SetActive(false);
        }

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
        if (blockPlayerDead)
            return;

        scoreText.text = gameManager.Score.ToString();
        UpdateHeartGUI();


        if (gameManager.PlayerDied)
            PlayerIsDead();
    }

    private void UpdateHeartGUI()
    {
        if (gameManager.b_Player == null)
            return;

        if (gameManager.b_Player.maxHealth != spawnedGUIHearts.Length)
        {
            RebuildHeartUI();
            lastHealth = 0;
        }

        if (lastHealth == gameManager.b_Player.PlayerHealth)
            return;
        lastHealth = gameManager.b_Player.PlayerHealth;

        for (int i = 0; i < spawnedGUIHeartSR.Length; i++)
        {
            spawnedGUIHeartSR[i].sprite = i < lastHealth ? fullHeart : emptyHeart;
        }
    }
    private void RebuildHeartUI()
    {
        List<GameObject> spawnedHeartIMGS = new();
        spawnedHeartIMGS.AddRange(spawnedGUIHearts.ToList());
        spawnedGUIHeartSR = new Image[gameManager.b_Player.maxHealth];

        float startX = -(gameCanvasRect.rect.width / 2);
        float startY = gameCanvasRect.rect.height / 2;

        float plusX = gameCanvasRect.rect.width * fullHeart.bounds.extents.x * 0.4f;
        float minusY = plusX * 0.8f;

        startX += plusX / 2;

        float activeX = startX;
        float activeY = startY;

        for (int i = 0; i < gameManager.b_Player.maxHealth; i++)
        {
            if (i % 3 == 0)
            {
                activeX = startX;
                activeY -= minusY;
            }
            else
            {
                activeX += plusX;
            }

            if (i >= spawnedHeartIMGS.Count)
            {
                spawnedHeartIMGS.Add(Instantiate(heartIMG, gameCanvasRect));
            }

            spawnedHeartIMGS[i].transform.localPosition = new Vector2(activeX, activeY);
            spawnedGUIHeartSR[i] = spawnedHeartIMGS[i].GetComponent<Image>();
            spawnedHeartIMGS[i].SetActive(true);
        }

        for (int i = 0; i < (spawnedHeartIMGS.Count - gameManager.b_Player.maxHealth); i++)
        {
            Destroy(spawnedHeartIMGS[^(i + 1)]);
            spawnedHeartIMGS.RemoveAt(spawnedHeartIMGS.Count - (i + 1));
        }

        spawnedGUIHearts = spawnedHeartIMGS.ToArray();

        //Set Pattern in heart formatation
        #region Set pattern
        
        float lastY = spawnedHeartIMGS[^1].transform.localPosition.y;
        int onSameYLevel = 0;

        for (int i = 3; i > 0; i--)
        {
            if (lastY == spawnedHeartIMGS[^i].transform.localPosition.y)
                onSameYLevel++;
        }

        switch (onSameYLevel)
        {
            case 1:
                spawnedHeartIMGS[^1].transform.localPosition = new Vector2(
                    startX + plusX,
                    activeY
                );
                break;

            case 2:
                spawnedHeartIMGS[^1].transform.localPosition = new Vector2(
                   startX + plusX * 1.5f,
                   activeY
               );
                spawnedHeartIMGS[^2].transform.localPosition = new Vector2(
                    startX + plusX * 0.5f,
                    activeY
                );
                break;

            case 3:
                spawnedHeartIMGS[^1].transform.localPosition = new Vector2(
                    startX + plusX,
                    activeY - minusY
                );
                spawnedHeartIMGS[^2].transform.localPosition = new Vector2(
                    startX + plusX * 1.5f,
                    activeY
                );
                spawnedHeartIMGS[^3].transform.localPosition = new Vector2(
                    startX + plusX * 0.5f,
                    activeY
                );
                break;
        }
        #endregion

    }
}
