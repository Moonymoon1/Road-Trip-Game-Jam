using Unity.VisualScripting;
using UnityEngine;

public class AtivadorDeDialogo : MonoBehaviour, Interagivel
{
    [SerializeField] ObjetoDialogo objetoDialogo;

    public void UpdateObjetoDialogo(ObjetoDialogo objetoDialogo)
    {
        this.objetoDialogo = objetoDialogo;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            player.Interagivel = this;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            if (player.Interagivel is AtivadorDeDialogo ativadorDeDialogo && ativadorDeDialogo == this)
            {
                player.Interagivel = null;
            }
        }
    }
    public void Interagir(Player player)
    {
        foreach(EventoRespostaDialogo eventoResposta in GetComponents<EventoRespostaDialogo>())
        {
            if (eventoResposta.ObjetoDialogo == objetoDialogo)
            {
                player.DialogoUI.AddEventosRespostas (eventoResposta.Eventos);
                break;
            }
        }

        player.DialogoUI.MostrarDialogo(objetoDialogo);
    }
}
