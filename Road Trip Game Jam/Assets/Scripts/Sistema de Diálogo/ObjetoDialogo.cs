using UnityEngine;

[CreateAssetMenu(menuName = "Dialogo/ObjetoDialogo")]
public class ObjetoDialogo : ScriptableObject
{
    [SerializeField] [TextArea] string[] dialogo;
    [SerializeField] Resposta[] respostas;

    public string[] Dialogo => dialogo;

    public bool temRespostas => Respostas != null && Respostas.Length > 0;

    public Resposta[] Respostas => respostas;
}
