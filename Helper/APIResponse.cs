using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Helper
{
  /// <summary>
  /// Clase genérica que representa la respuesta de un endpoint de API.
  /// </summary>
  /// <typeparam name="T">El tipo de datos que contiene la respuesta.</typeparam>
  public class APIResponse<T>
  {
    /// <summary>
    /// Código de estado HTTP de la respuesta.
    /// </summary>
    public int StatusCode { get; set; } = 200;

    /// <summary>
    /// Datos contenidos en la respuesta.
    /// </summary>
    public T? Result { get; set; }

    /// <summary>
    /// Mensaje que describe la respuesta.
    /// </summary>
    public string Message { get; set; } = "OK";
  }
}