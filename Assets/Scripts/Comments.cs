using System;
using System.Collections.Generic;
using UnityEngine;

public class Comments : MonoBehaviour
{
    /// <summary>
    /// Class para gestionar Players.
    /// </summary>
    /// <remarks>
    /// La clase agrega, elimina y devuelve la posición a través de la id del Player.
    /// </remarks>
    #region EVENTS VARIABLES


    public event Action<Player> PlayerAdded = delegate { };

    public event Action<Player> PlayerRemoved = delegate { };

    #endregion
    /// <summary>
    /// Lista de todos Players 
    /// </summary>

    #region PRIVATE VARIABLES

    ///<value>
    ///Lista para almacenar Players
    ///</value>
    private List<Player> _players;

    #endregion

    #region METHODS UNITY
    private void Awake()
    {
        _players = new List<Player>();
    }
    #endregion

    #region METHODS
    /// <summary>
    /// Recibe una intero <paramref name="id"/> y devuelve el Player. 
    /// </summary>
    /// <param name="id"> valor entero que identifica al Player</param>
    /// <returns>
    /// Devuelve la class Player
    /// </returns>
    /// <see cref="GetPlayerPositionById(int)"/> 
    public Player GetPlayerById(int id)
    {
        return _players.Find(player => player.Id == id);
    }
      

    /// <summary>
    /// Agregar un <paramref name="player"/> a la lista <paramref name="_players"/> y ejecuta el event OnPlayerAdded.
    /// </summary>
    /// <param name="player">Objeto que representa al Player.</param>
    /// <see cref="RemovePlayer(Player)"/> Para eliminar.
    public void AddPlayer(Player player)
    {
        _players.Add(player);

        OnPlayerAdded(player);
    }

    /// <summary>
    /// Elimina un <paramref name="player"/> de la lista <paramref name="_players"/> y ejecuta el event OnPlayerRemoved.
    /// </summary>
    /// <param name="player">>Objeto que representa al Player.</param>
    /// <see cref="AddPlayer(Player)"/> Para agregar.
    public void RemovePlayer(Player player)
    {
        _players.Remove(player);

        OnPlayerRemoved(player);
    } 
    /// <summary>
    /// Devuelve la posición del Player a través de un entero <paramref name="id"/>.
    /// </summary>
    /// <param name="id">valor entero que identifica al Player</param>
    /// <returns>Devuelve un Vector3</returns>
    public Vector3 GetPlayerPositionById(int id)
    {
        return GetPlayerById(id).transform.position;
    }
    #endregion

    #region METHODS EVENTS

    /// <summary>
    /// realizar una acción al agregar un <paramref name="player"/> a la lista. 
    /// </summary>
    ///  El evento no debe ser nulo 
    /// <param name="player">Objeto que representa al Player</param>
    public void OnPlayerAdded(Player player)
    {
        if(PlayerAdded != null)
        {
            PlayerAdded.Invoke(player);
        }
    }
    /// <summary>
    /// realizar una acción al eliminar un <paramref name="player"/> a la lista. 
    /// </summary>
    /// <remarks>
    /// El evento no debe ser nulo 
    /// </remarks>
    /// <param name="player">Objeto que representa al Player</param>
    public void OnPlayerRemoved(Player player)
    {
        if (PlayerAdded != null)
        {
            PlayerRemoved.Invoke(player);
        }
    }
    #endregion
}
