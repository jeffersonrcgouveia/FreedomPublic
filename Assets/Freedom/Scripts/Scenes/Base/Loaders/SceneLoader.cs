using Tymski;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Freedom.Scenes.Base.Loaders
{
	public class SceneLoader : MonoBehaviour
	{
		[SerializeField] SceneReference sceneReference;

		public void LoadScene() => SceneManager.LoadScene(sceneReference);
	}
}