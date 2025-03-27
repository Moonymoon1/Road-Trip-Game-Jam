using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventoResposta
{
    [HideInInspector] public string name;
    [SerializeField] UnityEvent naRespostaEscolhida;

    public UnityEvent NaRespostaEscolhida => naRespostaEscolhida;
}