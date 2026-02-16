using UnityEngine;

[CreateAssetMenu(fileName = "SceneToGo", menuName = "Scriptable Objects/SceneToGo")]
public class SceneToGo : ScriptableObject
{
    [SerializeField] private string sceneName;

    public string SceneName
    {
        get => sceneName;
    }
}
