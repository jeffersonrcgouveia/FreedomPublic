using System.Collections;
using UnityEngine;

namespace Freedom.UI.ProgressBar.States.Actions
{
    public class ProgressBarAudioPlayer : MonoBehaviour
    {
        AudioSource _audioSource;

        bool _isPlaying;

        IEnumerator _coroutine;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _coroutine = PlayCoroutine();
        }

        public void StartPlaying()
        {
            if (_isPlaying) return;
            _isPlaying = true;
            StartCoroutine(_coroutine);
        }

        public void StopPlaying()
        {
            _isPlaying = false;
            StopCoroutine(_coroutine);
        }

        IEnumerator PlayCoroutine()
        {
            while (_isPlaying)
            {
                _audioSource.Play();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}