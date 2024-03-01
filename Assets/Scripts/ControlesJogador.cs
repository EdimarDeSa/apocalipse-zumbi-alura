using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Video;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidade = 10;

    const string moveComponent = "Movendo";
    const string horizontal = "Horizontal";
    const string vertical = "Vertical";

    Vector3 direcao;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetBool(moveComponent, false);

        float eixoX = Input.GetAxis(horizontal);
        float eixoZ = Input.GetAxis(vertical);
        direcao = new Vector3(eixoX, 0, eixoZ);

        if (! direcao.Equals(Vector3.zero))
        {
            GetComponent<Animator>().SetBool(moveComponent, true);
        }
    }

    void FixedUpdate() 
    {
        Vector3 posicaoInicial = GetComponent<Rigidbody>().position;
        Vector3 deslocamento = direcao * velocidade * Time.deltaTime;
        Vector3 posicaoFinal = posicaoInicial + deslocamento;
     
        GetComponent<Rigidbody>().MovePosition(posicaoFinal);
    }
}
