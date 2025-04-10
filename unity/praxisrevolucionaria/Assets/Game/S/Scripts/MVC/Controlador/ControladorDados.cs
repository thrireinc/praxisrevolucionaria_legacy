namespace Game.S.Scripts.MVC.Controlador
{
    using System;
    using UnityEngine;
    using Model;
    
    public class ControladorDados : MonoBehaviour
    {
        public Arquivo[] ArquivosParaSalvarNoStart {get => arquivosParaSalvarNoStart; set => arquivosParaSalvarNoStart = value;}

        [SerializeField] private Arquivo[] arquivosParaSalvarNoStart;
        [SerializeField] private Arquivo[] arquivosParaSalvar;
        [SerializeField] private Arquivo[] arquivosParaCarregar;
        
        public void SalvarObjeto(int indexDado)
        {
            var location = arquivosParaSalvar[indexDado].executarNaPastaDoPersonagem ? "/" + Personagem.Personagens[PlayerPrefs.GetInt("PersonagemAtual")] + "/" : "/";

            if (indexDado < arquivosParaSalvar.Length)
            {
                Dados.SalvarDado($"{Diretorios.SavePath}{location}{arquivosParaSalvar[indexDado].nome}.save", arquivosParaSalvar[indexDado].valor, true);
                return;
            }

            Debug.Log("Error: the given index is invalid.");

        }
        public object CarregarObjeto(int indexDado)
        {
            var location = arquivosParaCarregar[indexDado].executarNaPastaDoPersonagem ? "/" + Personagem.Personagens[PlayerPrefs.GetInt("PersonagemAtual")] + "/" : "/";
            
            if (indexDado < arquivosParaSalvar.Length)
                return Dados.CarregarDado($"{Diretorios.SavePath}{location}{arquivosParaCarregar[indexDado].nome}.save", true);

            Debug.Log("Error: the given index is invalid.");
            return null;
        }
    }

    [Serializable]
    public struct Arquivo
    { 
        public string nome;
        public string valor;
        public bool executarNaPastaDoPersonagem;
    }
}