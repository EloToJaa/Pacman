using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public readonly List<Vector2> availableDirections = new List<Vector2>();

    private void Start()
    {
        availableDirections.Clear();

        // Okre�lamy czy kierunek jest dot�pny korzystaj�c z BoxCast aby sprawdzi�
        // czy uderzymy w �cian�. Kierunki kt�re s� wolne dodajemy do listy
        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);
    }

    private void CheckAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.4f, 0f, direction, 1.5f, obstacleLayer);

        // je�li �aden kollider nie jest zosta� wykryty - nie ma �adnej przeszkody w tym kierunku
        if (hit.collider == null) {
            availableDirections.Add(direction); // wiec dodajemy do listy
        }
    }

}
