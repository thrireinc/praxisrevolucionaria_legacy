namespace Game.S.Scripts.ScriptableObjects
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "GeniusObject", menuName = "ScriptableObjects/GeniusObject", order = 1)]
    public class GeniusObject : ScriptableObject
    {
        public int Id => id;
        public Sprite Icone => icone;
    
        [SerializeField] private int id;
        [SerializeField] private Sprite icone;
    }   
}