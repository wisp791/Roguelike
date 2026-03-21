using UnityEngine;
using UnityEngine.UI;

public class RemoveBlackBackground : MonoBehaviour
{
    [Range(0f, 0.5f)] public float blackThreshold = 0.05f;

    void Start()
    {
        Shader shader = Shader.Find("Custom/RemoveBlackBackground");
        if (shader == null) { Debug.LogError("Shader not found"); return; }

        Material mat = new Material(shader);
        mat.SetFloat("_BlackThreshold", blackThreshold);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) { sr.material = mat; return; }

        Image img = GetComponent<Image>();
        if (img != null) { img.material = mat; }
    }
}