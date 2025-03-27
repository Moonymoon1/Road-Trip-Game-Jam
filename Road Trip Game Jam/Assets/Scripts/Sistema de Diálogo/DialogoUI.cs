using System.Collections;
using TMPro;
using UnityEngine;

public class DialogoUI : MonoBehaviour
{
    [SerializeField] GameObject caixaDialogo;
    [SerializeField] TMP_Text textLabel;

    public bool EstaAberto { get; private set; }

    ManejadorDeRespostas manejadorDeRespostas;
    EfeitoDigitar efeitoDigitar;
    void Start()
    {
        efeitoDigitar = GetComponent<EfeitoDigitar>();
        manejadorDeRespostas = GetComponent<ManejadorDeRespostas>();

        FecharDialogo();
    }

    public void MostrarDialogo(ObjetoDialogo objetoDialogo)
    {
        EstaAberto = true;
        caixaDialogo.SetActive(true);
        StartCoroutine(PercorrerDialogo(objetoDialogo));
    }

    public void AddEventosRespostas(EventoResposta[] eventosRespostas)
    {
        manejadorDeRespostas.AddEventosRespostas(eventosRespostas);
    }

    IEnumerator PercorrerDialogo(ObjetoDialogo objetoDialogo)
    {
        for(int i = 0; i < objetoDialogo.Dialogo.Length; i++)
        {
            string dialogo = objetoDialogo.Dialogo[i];
            
            yield return LigarEfeitoDititação(dialogo);

            textLabel.text = dialogo;

            if(i == objetoDialogo.Dialogo.Length - 1 && objetoDialogo.temRespostas) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if(objetoDialogo.temRespostas)
        {
            manejadorDeRespostas.MostrarRespostas(objetoDialogo.Respostas);
        }
        else {FecharDialogo();}
    }

    IEnumerator LigarEfeitoDititação(string dialogo)
    {
        efeitoDigitar.Funcionar(dialogo, textLabel);

        while (efeitoDigitar.TaFuncionando)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                efeitoDigitar.Parar();
            }
        }
    }
    public void FecharDialogo()
    {
        EstaAberto = false;
        caixaDialogo.SetActive(false);
        textLabel.text = string.Empty;
    }
}
