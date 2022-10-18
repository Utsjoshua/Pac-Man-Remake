using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(0);
        DontDestroyOnLoad(gameObject);
        Title.Pause();
        Title.Stop();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.buildIndex != 0){
            Title.Play();
        }
    }

}
