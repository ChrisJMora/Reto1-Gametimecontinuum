using UnityEngine;
using UnityEngine.Events;

public class VidaJugador : MonoBehaviour
{
    /// <summary>
    /// Las vidas del jugador (Por defecto tiene 3).
    /// </summary>
    [SerializeField] private int vidas = 3;

    public UnityEvent ElJugadorSeQuedoSinVidas;

    public void OnValidate()
    {
        // Verifica que el jugador cuente con una o más vidas.
        if (vidas <= 0)
        {
            Debug.LogWarning("Un jugador debe contar con una o más vidas");
            vidas = 1;
        }
    }

    public void Start()
    {
        if (TryGetComponent(out ColisionesJugador colisionesJugador))
        {   // Cuando el evento de colisión sea invocado, se ejecuta el método: 'DisminuirVida'
            colisionesJugador.JugadorColisionaConEnemigo.AddListener(DisminuirVida);
        }
        else Debug.LogError($"El componente {colisionesJugador.GetType()} no está presente en el objeto {gameObject.name}.");
    }

    /// <summary>
    /// Disminuye la vida del jugador en 1.
    /// </summary>
    private void DisminuirVida()
    {
        vidas--;
        if (vidas < 0) vidas = 0; // No permite que las vidas bajen de cero
        if (vidas == 0) ElJugadorSeQuedoSinVidas.Invoke();
    }
}
