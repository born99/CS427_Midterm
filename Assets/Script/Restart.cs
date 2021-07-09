using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject clicksound;
    // Update is called once per frame
    public void PlayGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
