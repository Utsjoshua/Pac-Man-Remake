using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public AudioSource Title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFirstlevel(){
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
        Title.Pause();
        Title.Stop();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.buildIndex == 0){
            Title.Play();
        }
        if (scene.buildIndex == 1){
            Title.Pause();
            Title.Stop();
            GameObject button = GameObject.FindGameObjectWithTag("ExitButton");
            Button btn = button.GetComponent<Button>();
		    btn.onClick.AddListener(Exit);
            
        }
    }

    public void Exit(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
        Debug.Log("Exit");
    }
}
