using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Jogo"); //Inicia o Jogo
    }

    public void Menu()
    {
        SceneManager.LoadScene("SampleScene"); //Volta ao Menu
    }
}
