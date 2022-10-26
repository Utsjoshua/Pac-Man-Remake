using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public AudioSource Title;
    private static GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        if (obj == null){
            obj = gameObject;
        }
        else{
            Destroy(gameObject);
        }
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
            GameObject Level1Button = GameObject.FindGameObjectWithTag("Level1Button");
            Button btn = Level1Button.GetComponent<Button>();
		    btn.onClick.AddListener(LoadFirstlevel);
        }
        if (scene.buildIndex == 1){
            Title.Pause();
            Title.Stop();
            GameObject Exitbutton = GameObject.FindGameObjectWithTag("ExitButton");
            Button btn = Exitbutton.GetComponent<Button>();
		    btn.onClick.AddListener(Exit);
            
        }
    }

    public void Exit(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
        Debug.Log("Exit");
    }
}
