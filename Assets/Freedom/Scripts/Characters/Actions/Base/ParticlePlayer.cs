using UnityEngine;

namespace Freedom.Characters.Actions.Base
{
    public class ParticlePlayer : MonoBehaviour
    {
        [SerializeField] ParticleSystem particle;

        public void Play() => particle.Play();

        public void Stop() => particle.Stop();
    }
}