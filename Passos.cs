using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public GameObject footstep; //Recebe GameObject Contendo o Som de Passos

    void Start() //Ao Iniciar
    {
        footstep.SetActive(false); //Define False como Estado Padrao do Som de Passos
    }
    
    void Update() //A Cada Atualizacao
    {
        if(Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d")) //Detecta Quando uma Tecla e Pressionada
        {
            footsteps();    //Citacao de Metodo
        }

        if(Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d")) //Detecta Quando a Tecla e Despressionada
        {
            StopFootsteps();  //Citacao de Metodo
        }
    }
    void footsteps()                   //Metodo que Toca o Som de Passos
    {
        footstep.SetActive(true); //Define o Estado como Ativo
    }
    void StopFootsteps()                //Metodo Que Pausa o Som de Passos
    {
        footstep.SetActive(false); //Define o Estado como Desativado
    }
}