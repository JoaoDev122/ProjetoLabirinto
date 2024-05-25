using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    private NavMeshAgent navmesh;       //Variavel que Recebera o Component NavMeshAgent
    private GameObject player;          //Variavel que Recebera o Player
    public float VelocidadeInimigo;     //Variavel que Define a Velocidade do Inimigo
    public Transform jog;               //Variavel que Recebe a Posicao do Jogador


    void Awake() //Ao Iniciar Configura As Variaveis 
    {
        navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();      //NavMesh Recebe o Componente navMeshAgent
        player = GameObject.FindWithTag("Player");                  //Variavel Player Procura Pela Hierarquia um GameObject com a Tag Player
        navmesh.speed = VelocidadeInimigo;                          //Altera o Valor do Atributo do NavMeshAgent pela Velocidade do Inimigo    
    
    }

    void Update() //Em Atualizacao Constante
    {
        navmesh.destination = player.transform.position;                                //Define o Destino do Nosso Inimigo Como a Posicao Atual do Jogador

        Vector3 direction = (jog.position - transform.position).normalized;             //Rotaciona a Face do Inimigo Sempre Para Direcao do Player
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);            //Rotaciona a Face do Inimigo Sempre Para Direcao do Player          
    }
}
