using System.IO;
using UnityEngine;
using PoketAPI.Camera;
public class FileManager : MonoBehaviour
{
    [HideInInspector] public static FileManager fileManager;

    private string saveFilePath;
    private string saveGamesPath;
    void Start()
    {
        if (fileManager != null)
        {
            Destroy(gameObject);
            return;
        }

        fileManager = this;

        saveFilePath = Application.persistentDataPath;
        saveGamesPath = Path.Combine(saveFilePath, "SaveGames");

        Directory.CreateDirectory(saveGamesPath);

        LoadSaveFiles();
    }

    private void LoadSaveFiles()
    {
    }
}
