using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;

    public Player birdBek;

    public GameObject VolumeObject;
    public GameObject ObstaclesObject;
    public GameObject BackgroundObject;
    public AudioSource BackgroundAudio;

    public Text gameOverTxt;
    public float timerBack = 5;

    private Slider Volume;
    private float VolumeValue;
    private void Start(){
        BackgroundAudio.Play();
        gameOverTxt.gameObject.SetActive(false);
        Time.timeScale = 0f;
        Volume = VolumeObject.GetComponent<Slider>();
        Volume.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void Update(){
        ;
        if (birdBek.isDead){
            gameOverTxt.gameObject.SetActive(true);
            timerBack -= Time.unscaledDeltaTime;//start counting back
            GameOver();
        }

        gameOverTxt.text = "Restarting in " + (timerBack).ToString("0");

        if(timerBack < 0){
            RestartGame();
        }
    }

     public void ValueChangeCheck()
     {
        VolumeValue = Volume.value;
        Debug.Log(Volume.value);
     }

    public void StartGame(){
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver(){
        Time.timeScale = 0;
    }
    public void RestartGame(){
        EditorSceneManager.LoadScene(0);//reload the scene initial state
    }
}
