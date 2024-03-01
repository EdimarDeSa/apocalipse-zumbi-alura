using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{

    public GameObject Jogador;
    public float Velocidade = 2;
    const string moveComponent = "Atacando";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 direcao = Jogador.transform.position - transform.position;     
        Vector3 posicaoFinal = GetComponent<Rigidbody>().position + direcao.normalized * Velocidade * Time.deltaTime;
        
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        GetComponent<Animator>().SetBool(moveComponent, true);

        if(distancia > 3)
        {
            GetComponent<Rigidbody>().MovePosition(posicaoFinal);

            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
            
            GetComponent<Animator>().SetBool(moveComponent, false);
        }
    
    }
}
