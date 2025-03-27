using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EfeitoDigitar : MonoBehaviour
{
    [SerializeField] float velocidadeDigitação = 50f;

    public bool TaFuncionando { get; private set; }

    readonly List<Pontuação> pontuações = new List<Pontuação>()
    {
        new Pontuação(new HashSet<char>(){'.', '!', '?',}, 0.6f),
        new Pontuação(new HashSet<char>(){',', ';', ':',}, 0.3f),
    };

    Coroutine coroutineDigitando;
    public void Funcionar(string textoPraDigitar, TMP_Text textLabel)
    {
        coroutineDigitando = StartCoroutine(DigitarTexto(textoPraDigitar, textLabel));
    }
    public void Parar()
    {
        StopCoroutine(coroutineDigitando);
        TaFuncionando = false;
    }
    IEnumerator DigitarTexto(string textoPraDigitar, TMP_Text textLabel)
    {
        TaFuncionando = true;
        textLabel.text = string.Empty;
        float t = 0;
        int charIndex = 0;

        while (charIndex < textoPraDigitar.Length)
        {
            int ultimoCharIndex = charIndex;

            t += Time.deltaTime * velocidadeDigitação;

            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textoPraDigitar.Length);

            for(int i = ultimoCharIndex; i < charIndex; i++ )
            {
                bool éUltimo = i >= textoPraDigitar.Length - 1;

                textLabel.text = textoPraDigitar.Substring(0, i + 1);

                if(ÉPontuação(textoPraDigitar[i], out float tempoDeEspera) && !éUltimo && !ÉPontuação(textoPraDigitar[i +1], out _))
                {
                    yield return new WaitForSeconds(tempoDeEspera);
                }
            }

            yield return null;
        }
        TaFuncionando = false;

        bool ÉPontuação(char character, out float tempoDeEspera)
        {
            foreach(Pontuação categoriaDePontuação in pontuações)
            {
                if(categoriaDePontuação.Pontuações.Contains(character))
                {
                    tempoDeEspera = categoriaDePontuação.TempoDeEspera;
                    return true;
                }
            }

            tempoDeEspera = default;
            return false;
        }
    }
    readonly struct Pontuação
    {
        public readonly HashSet<char> Pontuações;
        public readonly float TempoDeEspera;

        public Pontuação(HashSet<char> pontuações, float tempoDeEspera)
        {
            Pontuações = pontuações;
            TempoDeEspera = tempoDeEspera;
        }
    }
}
