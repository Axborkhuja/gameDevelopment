using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    //for other scripts so they can take info
    public GameObject StartButton;
    public GameObject SettingsButton;
    public GameObject SettingsPage;
    public AudioSource buttonClick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void onSettingButtonClick()
    {
        StartButton.SetActive(false);
        SettingsButton.SetActive(false);
        SettingsPage.SetActive(true);
    }

    public void onButtonClick()
    {
        buttonClick.Play();
    }

    public void onMenuButtonClick()
    {
        StartButton.SetActive(true);
        SettingsButton.SetActive(true);
        SettingsPage.SetActive(false);
    }
}
