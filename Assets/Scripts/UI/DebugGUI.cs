using UnityEngine;
using FastDebug;
using UnityEngine.UI;
public class DebugGUI : MonoBehaviour
{
    [SerializeField] private Canvas debugCanvas;
    [SerializeField] private Image visibilityButtonImage;
    [SerializeField] private Sprite visibleIcon;
    [SerializeField] private Sprite unVisibleIcon;

    private D_text gameVersionTxT;
    private D_text fpsTxt;
    private int fps;
    void Start()
    {
        gameVersionTxT = new(1, 1, debugCanvas, name: "VersionTxt", allowedRows: 20, fontSize: 80);
        fpsTxt = new(2, 1, debugCanvas, name: "fpsTxt", allowedRows: 20, fontSize: 80);

        gameVersionTxT.SetText("Game Version: " + Application.version);

        debugCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        fps = (int)(1 / Time.deltaTime);
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
