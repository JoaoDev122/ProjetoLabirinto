using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LanternaScript : MonoBehaviour
{
    private Transform target;                   //Variavel Referente a Posicao do Ponto de Luz da Laterna
    private Light Luzlanterna;                  //Variavel que Ira receber Componente da Luz
    public  float Velocidade;                   //Velocidade em que a Luz a Companha a Tela do Jogador
    public AudioSource AudioLanTerna;           //Componente de Efeito Sonoro da Lanterna

    void Start() //Ao Iniciar
    {
        target = Camera.main.transform;                    //Recebe Camera do Personagem
        Luzlanterna = GetComponentInChildren<Light>();     //Recebe Componente de Luz
    }

    void Update() //A Cada Tick de Atualizacao
    {
        transform.position = transform.position;                    //Alinha a Posicao da Luz com a da Camera                   
        transform.rotation = Quaternion.Lerp(transform.rotation,    //Alinha a Rotacao da Luz com a Camera
            transform.rotation, Velocidade * Time.deltaTime);       //Velocidade de Acompanhamento da Luz Referente a Camera do Jogador

        if (Input.GetKeyDown(KeyCode.F))    //Estrutura Condicional que Retorna Verdadeiro se a Tecla F é Pressionada
        {
            LigarLant(); //Executa Funcao LigarLanterna Enquanto a Tecla F Estiver Pressionada
        }

    }

    void LigarLant() //Funcao que Liga e Desliga a Lanterna
    {
        Luzlanterna.enabled = !Luzlanterna.enabled;         //Ao Apertar a Tecla F Alterna Entre Os Estados Verdadeiro ou Falso da Visibilidade da Luz
        AudioLanTerna.Play();                               //Executa o Audio da Lanterna
    }
}  
