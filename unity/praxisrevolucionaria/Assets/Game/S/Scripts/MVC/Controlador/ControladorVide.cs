namespace Game.S.Scripts.MVC.Controlador
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    using VIDE_Data;
    using Model;
    
    public class ControladorVide : MonoBehaviour
    {
        [SerializeField] private GameObject container, pnlBloquearInput;
        [SerializeField] private Text texto;
        [SerializeField] private Image imagemA, imagemB; 
        [SerializeField] private AudioSource audioSource;
        
        private VIDE_Assign _gerenciadorDialogo;
        private char _dadoAnterior;
        private bool _acabouFalaAtual, _clicouNaTela, _encontrouGerenciadorDialogo;

        private void Awake()
        {
            _gerenciadorDialogo = GetComponent<VIDE_Assign>();
            Controles.Master.Dialogos.PassarDialogo.performed += _ => _clicouNaTela = _acabouFalaAtual || _clicouNaTela;
        }
        private void OnEnable()
        {
            Controles.Master.Enable();
        }
        private void OnDisable()
        {
            Controles.Master.Disable();
            
            if (container != null)
                End(null);
        }
        private void Start()
        {
            _acabouFalaAtual = true;
            _dadoAnterior = 'i';
            _encontrouGerenciadorDialogo = _gerenciadorDialogo != null;
            container.SetActive(false);
            VD.LoadDialogues();
        }
        private void Update()
        {
            if (_encontrouGerenciadorDialogo && _clicouNaTela && _acabouFalaAtual)
                VD.Next();
        }
        
        public void Begin(string nomeDialogo)
        {
            container.SetActive(true);
            imagemA.gameObject.SetActive(true);
            pnlBloquearInput.SetActive(true);
            _gerenciadorDialogo.assignedDialogue = nomeDialogo;

            VD.OnNodeChange += UpdateUI;
            VD.OnEnd += End;
            VD.BeginDialogue(_gerenciadorDialogo);
        }
        private void UpdateUI(VD.NodeData data)
        {
            if (_dadoAnterior == 'i' || ((data.isPlayer && _dadoAnterior == 'n') || (!data.isPlayer && _dadoAnterior == 'p')))
                MudarImagem(data.sprite);

            ReproduzirFala(data.audios[0]);
            texto.text = "";
            _acabouFalaAtual = _clicouNaTela = false;
            StartCoroutine(Escrever(data));
            _dadoAnterior = data.isPlayer ? 'p' : 'n';
        }
        private void End(VD.NodeData data)
        {
            container.SetActive(false);
            pnlBloquearInput.SetActive(false);
            imagemA.gameObject.SetActive(false);
            VD.OnNodeChange -= UpdateUI;
            VD.OnEnd -= End;
            PlayerPrefs.SetInt("DialogosFeitos", PlayerPrefs.GetInt("DialogosFeitos") + 1);
            VD.EndDialogue();
        }
        private void MudarImagem(Sprite tmpSprite)
        {
            Image tmpImg;
            var gameObjectImagemA = imagemA.gameObject;
            var gameObjectImagemB = imagemB.gameObject;
            
            gameObjectImagemA.SetActive(!gameObjectImagemA.activeSelf);
            gameObjectImagemB.SetActive(!gameObjectImagemB.activeSelf);
            tmpImg = imagemA.IsActive() ? imagemA : imagemB;
            tmpImg.sprite = tmpSprite;
            audioSource = tmpImg.GetComponent<AudioSource>();
        }
        private IEnumerator Escrever(VD.NodeData data)
        {
            foreach (var letra in data.comments[data.commentIndex])
            {
                texto.text += letra;
                yield return new WaitForSeconds(0.015f);
            }
            audioSource.Stop();
            _acabouFalaAtual = true;
        }
        private void ReproduzirFala(AudioClip somFala)
        {
            audioSource.clip = somFala;
            audioSource.Play();
        }
    }
}