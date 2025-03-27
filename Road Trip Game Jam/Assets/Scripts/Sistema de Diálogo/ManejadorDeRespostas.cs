using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ManejadorDeRespostas : MonoBehaviour
{
    [SerializeField] RectTransform caixaDeResposta;
    [SerializeField] RectTransform botãoDeRespostaTemplate;
    [SerializeField] RectTransform respostaContainer;

    DialogoUI dialogoUI;
    EventoResposta[] eventosRespostas;

    List<GameObject> botõesRespostaTemporários = new List<GameObject>();

    void Start()
    {
        dialogoUI = GetComponent<DialogoUI>();
    }

    public void AddEventosRespostas(EventoResposta[] eventosRespostas)
    {
        this.eventosRespostas = eventosRespostas;
    }

    public void MostrarRespostas(Resposta[] respostas)
    {
        float alturaCaixaDeResposta = 0;

        for(int i = 0; i < respostas.Length; i ++)
        {
            Resposta resposta = respostas[i];
            int indexresposta = i;

            GameObject botãoResposta = Instantiate(botãoDeRespostaTemplate.gameObject, respostaContainer);
            botãoResposta.gameObject.SetActive(true);
            botãoResposta.GetComponent<TMP_Text>().text = resposta.TextoResposta;
            botãoResposta.GetComponent<Button>().onClick.AddListener(() => NaRespostaEscolhida(resposta, indexresposta));

            botõesRespostaTemporários.Add(botãoResposta);

            alturaCaixaDeResposta += botãoDeRespostaTemplate.sizeDelta.y;
        }

        caixaDeResposta.sizeDelta = new Vector2(caixaDeResposta.sizeDelta.x, alturaCaixaDeResposta);
        caixaDeResposta.gameObject.SetActive(true);
    }

    void NaRespostaEscolhida(Resposta resposta, int indexresposta)
    {
        caixaDeResposta.gameObject.SetActive(false);

        foreach(GameObject botão in botõesRespostaTemporários)
        {
            Destroy(botão);
        }
        botõesRespostaTemporários.Clear();

        if (eventosRespostas != null && indexresposta <= eventosRespostas.Length)
        {
            eventosRespostas[indexresposta].NaRespostaEscolhida?.Invoke();
        }

        eventosRespostas = null;

        if(resposta.ObjetoDialogo)
        {
            dialogoUI.MostrarDialogo(resposta.ObjetoDialogo);
        }
        else
        {
            dialogoUI.FecharDialogo();
        }
    }
}
