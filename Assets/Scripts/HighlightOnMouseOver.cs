using UnityEngine;

public class HighlightOnMouseOver : MonoBehaviour
{
    public Material highlightMaterial; // Материал для выделения граней

    private Material originalMaterial; // Исходный материал объекта
    private Renderer objectRenderer; // Компонент Renderer объекта

    private void Start()
    {
        // Получаем компонент Renderer и сохраняем исходный материал
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    private void OnMouseEnter()
    {
        // При наведении мыши на объект меняем его материал на материал для выделения
        objectRenderer.material = highlightMaterial;
    }

    private void OnMouseExit()
    {
        // При отводе мыши возвращаем объекту исходный материал
        objectRenderer.material = originalMaterial;
    }
}
