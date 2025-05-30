using UnityEngine;

public class DragObject : MonoBehaviour
{
    private float distanceToCamera;

    void OnMouseDown()
    {
        // Calcula a distância entre o objeto e a câmera para manter na mesma "profundidade"
        distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        Debug.Log("Down");
    }

    void OnMouseDrag()
    {
        // Pega a posição do mouse na tela com a profundidade do objeto
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = distanceToCamera; // distância do objeto até a câmera

        // Converte para posição no mundo
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Atualiza a posição do objeto (mantendo a altura Y fixa, por exemplo)
        transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);

        Debug.Log("Drag");
    }

    void OnMouseUp()
    {
        Debug.Log("Up");
    }

    void OnMouseExit()
    {
        Debug.Log("Exit");
    }
}
