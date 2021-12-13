using UnityEngine;

namespace Client.Scripts.MainGameScene
{
    public class EnemyDestroyed : MonoBehaviour
    {
        private AudioSource _source;

        private void Start()
        {
            _source = GameObject.FindWithTag("Audio").GetComponent<AudioSource>();
        }
        
        private void OnDestroy()
        {
            _source.Play();
            _source = null;
        }
    }
}