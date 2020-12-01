using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class twoXtwoTest : MonoBehaviour
{
    public int test;
    public GameObject canvas;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void testId(int testId)
    {
        test = testId;
    }

    public void levelId(int levelId)
    {
        SceneManager.LoadScene(levelId);
        Destroy(canvas); 
    }

}
