using UnityEngine;
using System;

public class EventoRespostaDialogo : MonoBehaviour
{
    [SerializeField] ObjetoDialogo objetoDialogo;
    [SerializeField] EventoResposta[] eventos;

    public ObjetoDialogo ObjetoDialogo => objetoDialogo;

    public EventoResposta[] Eventos => eventos;

    public void OnValidate()
    {
        if (objetoDialogo == null) return;
        if (objetoDialogo.Respostas == null) return;
        if (eventos != null && eventos.Length == objetoDialogo.Respostas.Length) return;

        if(eventos == null)
        {
            eventos = new EventoResposta[objetoDialogo.Respostas.Length];
        }
        else
        {
            Array.Resize(ref eventos, objetoDialogo.Respostas.Length);
        }

        for (int i = 0; i < objetoDialogo.Respostas.Length; i ++)
        {
            Resposta resposta = objetoDialogo.Respostas[i];

            if (eventos[i] != null)
            {
                eventos[i].name = resposta.TextoResposta;
                continue;
            }

            eventos[i] = new EventoResposta() {name = resposta.TextoResposta};
        }
    }
}
