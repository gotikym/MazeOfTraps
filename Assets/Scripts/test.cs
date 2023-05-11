using UnityEngine;
using IJunior.TypedScenes;

public class test : MonoBehaviour
{
    void Start()
    {
        AsyncOperation asyncOperation = Level1.LoadAsync();

        asyncOperation.allowSceneActivation = false;
    }
}