using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    private Vector3 entradaJogador;                        //Variavel das Entradas (AWSD) do Jogador
    private CharacterController characterController;       //Varivel que Ira Receber CharacterController
    private Transform Mycamera;                            //Variavel Refente a Camera
    private Animator animator;                             //Variavel Referente a Animacao do Personagem
    public float Velocidade;                               //Variavel Referente a Velocidade do Player

    void Awake() //Ao iniciar Configura as Variaveis
    {
        characterController = GetComponent<CharacterController>();      //Recebe GComponent CharacterController do Player
        Mycamera = Camera.main.transform;                               //Defindo Variavel Mycamera a Nossa Camera do Personagem
        animator = GetComponent<Animator>();                            //Recebe Component Animator do GameObject
    }

    void Start() //Metodo Start So Executa-se uma vez
    {
        Cursor.lockState = CursorLockMode.Locked; //Esconde o Cursor do Mouse
    }


    void Update() //Metodo Update é Constantemente Executado no Programa
    {
        //Movimentacao do Jogador e Transformando Metodo de Visao do Jogador em Local

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mycamera.eulerAngles.y, transform.eulerAngles.z); //Transforma Posicao da Camera em Local

        entradaJogador.Set(Input.GetAxis("Horizontal"),
         0 ,Input.GetAxis("Vertical"));                                         //Recebe as Teclas Presionadas (AWSD)
        entradaJogador = transform.TransformDirection(entradaJogador);          //Transforma a CameraPosition nos Eixos (XYZ)

        characterController.Move(entradaJogador * Velocidade * Time.deltaTime);             //Move o Player Baseado nas Teclas Pressionadas

        //Animacao do Personagem

        if (entradaJogador != Vector3.zero)                 //Estrutura Condicional que Altera o Valor Boleano Para as Animações Idle e Run
        {
            animator.SetBool("Andando", true);              //Coloca Animacao de Andar em Verdadeiro
        }
        else
        {
            animator.SetBool("Andando", false);             //Coloca Animacao de Andar em Falso
        }

        //Correr

        if (Input.GetKeyDown(KeyCode.LeftShift))            //Detecta Quando a Tecla LeftShift é Pressionada e Adiciona +2 de Velocidade ao jogador
        {
            Velocidade = 7;      //Define velocidade de corrida
        }
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)                   //Switch Referente a Tag do GameObject
        {
            case "Inimigo":                                 //Caso Tag do GameObject For Igual a Inimigo
                SceneManager.LoadScene("SampleScene");      //Volta Para o Menu do Jogo, Derrota
            break;                                          //Break

            case "Vitoria":                                 //Caso Tag do GameObject Seja Igual a Vitoria
                SceneManager.LoadScene("Vitoria");          //Carrega a Tela de Vitória do Jogador
            break;                                          //Break
        }
    }
}
