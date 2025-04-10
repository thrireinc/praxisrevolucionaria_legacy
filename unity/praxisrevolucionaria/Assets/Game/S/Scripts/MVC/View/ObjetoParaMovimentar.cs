namespace Game.S.Scripts.MVC.View
{
    using UnityEngine;
    using UnityEngine.Events;
    using Interfaces.Movimentos;
    using Enumeradores;

    [RequireComponent(typeof(Rigidbody2D))]
    public class ObjetoParaMovimentar : MonoBehaviour
    {
        public Vector3 movimento;
        [SerializeField] private float velocidade;
        [SerializeField] private Movimentos tipoMovimento;
        [SerializeField] private UnityEvent morrer, ganhar, passar;

        public Movimentos TipoMovimento => tipoMovimento;
        public IMovimentos ReferenciaMovimento;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            ReferenciaMovimento.Movimento(_rigidbody2D, movimento * velocidade);
        }
        private void OnCollisionEnter2D(Collision2D collision2d)
        {
            var collider2d = collision2d.collider;

            if (collider2d.CompareTag("Morrer"))
                morrer?.Invoke();
        }
        private void OnTriggerEnter2D(Collider2D collider2d)
        {
            if (collider2d.CompareTag("Ganhar"))
                ganhar?.Invoke();

            if (collider2d.CompareTag("Passar"))
                passar?.Invoke();
        }
        public void MudarPosicao(Transform posicaoSpawn)
        {
            transform.position = posicaoSpawn.position;
        }
    }
}