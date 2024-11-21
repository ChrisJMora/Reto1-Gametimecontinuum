using UnityEngine;
using UnityEngine.Events;

public class ColisionesJugador : MonoBehaviour
{
    public UnityEvent JugadorColisionaConEnemigo;

    public void OnTriggerEnter(Collider other)
    {   // Verifica si el jugador hizo colisión con un enemigo en la escena
        if (other.CompareTag("Enemigo")) JugadorColisionaConEnemigo.Invoke();
    }
}
