using UnityEngine;

[System.Serializable]
public class Resposta
{
    [SerializeField] string textoResposta;
    [SerializeField] ObjetoDialogo objetoDialogo;

    public string TextoResposta => textoResposta;
    public ObjetoDialogo ObjetoDialogo => objetoDialogo;
}
