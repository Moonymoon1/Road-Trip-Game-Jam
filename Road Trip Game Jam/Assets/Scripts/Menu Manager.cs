using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject painelSettings;
    [SerializeField] GameObject painelCreditos;

    void Start()
    {

    }


    void Update()
    {
        
    }

    public void LoadSpaceShipScene()
    {
        SceneManager.LoadScene("Nave");
    }

    public void Exit()
    {
        Application.Quit();
    }

}