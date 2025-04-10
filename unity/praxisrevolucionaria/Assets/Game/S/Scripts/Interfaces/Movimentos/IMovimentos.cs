    namespace Game.S.Scripts.Interfaces.Movimentos
{
    using UnityEngine;

    public interface IMovimentos
    {
        public void Movimento(Rigidbody2D rigidbodyParaMovimentar, Vector2 movimento);
    }
}