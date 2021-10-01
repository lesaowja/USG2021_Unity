using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PixelController : MonoBehaviour
{
    public InputField inputField_ID;
    public  string user = "";
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void testStartButton()
    {
        user = inputField_ID.text; 
        SceneManager.LoadScene(1);
        Debug.Log(user);
    } 
}
