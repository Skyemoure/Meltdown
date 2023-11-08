using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public static gameController instance;
    public static gameController[] existo;
    public GameObject player;

    public Scene start;

    static public int vidas;
    static public int nivel;

    Scene onScreen;
    static public bool isOn;
    static public bool pause;
    static public bool dead;
    static public bool win;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        existo = FindObjectsOfType<gameController>();
        if (existo.Length > 1)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        onScreen = SceneManager.GetActiveScene();
        start = SceneManager.GetSceneByName("1");
        player = GameObject.Find("Player");
        vidas = 5;
        nivel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
