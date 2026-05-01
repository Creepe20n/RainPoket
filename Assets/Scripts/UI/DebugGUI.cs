using UnityEngine;
using FastDebug;
using UnityEngine.UI;
public class DebugGUI : MonoBehaviour
{
    [SerializeField] private Canvas debugCanvas;
    [SerializeField] private Image visibilityButtonImage;
    [SerializeField] private Sprite visibleIcon;
    [SerializeField] private Sprite unVisibleIcon;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private StatisticManager statisticManager;

    private D_text gameVersionTxT;
    private D_text fpsTxt;
    private D_text scoreMultiplierTxT;
    private D_text testStatistic;
    private int fps;
    void Start()
    {
        gameVersionTxT = new(1, 1, debugCanvas, name: "VersionTxt", allowedRows: 20, fontSize: 80);
        fpsTxt = new(2, 1, debugCanvas, name: "fpsTxt", allowedRows: 20, fontSize: 80);
        scoreMultiplierTxT = new(3, 1, debugCanvas, name: "scoreMultiplier", allowedRows: 20, fontSize: 80);
        testStatistic = new(4, 1, debugCanvas, name: "test", allowedRows: 20, fontSize: 80);

        gameVersionTxT.SetText("Game Version: " + Application.version);

        debugCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        fps = (int)(1 / Time.deltaTime);
        scoreMultiplierTxT.SetText("Score Multiplier: "+gameManager.ScoreMultiplier.ToString());
        testStatistic.SetText("TS: "+statisticManager.GetStatisticData(E_StatisticEventType.Spawned, E_IETypes.Raindrop, E_StatisticData.Spawn));
    }
    void FixedUpdate()
    {
        Color fpsColor = Color.green;

        if (fps < 35)
            fpsColor = Color.yellow;

        if (fps < 25)
            fpsColor = Color.red;

        fpsTxt.SetText("Fps: " + fps.ToString(), fpsColor);
    }

    public void ChangeDebugGUIVisiblity()
    {
        debugCanvas.gameObject.SetActive(!debugCanvas.gameObject.activeSelf);

        visibilityButtonImage.sprite = !debugCanvas.gameObject.activeSelf ? visibleIcon : unVisibleIcon;
    }
}
