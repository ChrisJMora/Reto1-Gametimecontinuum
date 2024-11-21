using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    [SerializeField] private GameObject jugador;

    public void Start()
    {
        if (jugador.TryGetComponent(out VidaJugador vida))
        {   // Cuando el jugador se quede sin vidas, se ejecuta el método: 'AcabarJuego'
            vida.ElJugadorSeQuedoSinVidas.AddListener(AcabarJuego);
        }
        else Debug.LogError($"El componente {vida.GetType()} no está presente en el objeto {jugador.name}.");
    }

    /// <summary>
    /// Muestra en consola el mensaje 'GAME OVER'
    /// </summary>
    private void AcabarJuego() => Debug.Log("GAME OVER");
}
