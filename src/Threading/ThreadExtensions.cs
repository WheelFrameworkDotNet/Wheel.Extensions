using System;
using System.Threading;

namespace Wheel.Extensions.Threading
{
    /// <summary>
    /// Clase con métodos de extensión para un hilo o subproceso (Thread).
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <h2 class="groupheader">Registro de versiones</h2>
    ///         <ul>
    ///             <li>1.0.0</li>
    ///             <table>
    ///                 <tr style="font-weight: bold;">
    ///                     <td>Autor</td>
    ///                     <td>Fecha</td>
    ///                     <td>Descripción</td>
    ///                 </tr>
    ///                 <tr>
    ///                     <td>Marcos Abraham Hernández Bravo.</td>
    ///                     <td>10/11/2016</td>
    ///                     <td>Versión Inicial.</td>
    ///                 </tr>
    ///             </table>
    ///         </ul>
    ///     </para>
    /// </remarks>
    public static class ThreadExtensions
    {
        /// <summary>
        /// Guarda un objeto o valor en un espacio de memoria disponible sólo para el hilo actual.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>10/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="hilo">Hilo de origen.</param>
        /// <param name="nombre">Nombre del valor a guardar.</param>
        /// <param name="data">Valor a guardar.</param>
        public static void Guardar(this Thread hilo, string nombre, object data)
        {
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(nombre);
            if (slot == null)
            {
                slot = Thread.AllocateNamedDataSlot(nombre);
            }
            Thread.SetData(slot, data);
        }

        /// <summary>
        /// Obtiene un objeto guardado en el hilo actual.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <h2 class="groupheader">Registro de versiones</h2>
        ///         <ul>
        ///             <li>1.0.0</li>
        ///             <table>
        ///                 <tr style="font-weight: bold;">
        ///                     <td>Autor</td>
        ///                     <td>Fecha</td>
        ///                     <td>Descripción</td>
        ///                 </tr>
        ///                 <tr>
        ///                     <td>Marcos Abraham Hernández Bravo.</td>
        ///                     <td>10/11/2016</td>
        ///                     <td>Versión Inicial.</td>
        ///                 </tr>
        ///             </table>
        ///         </ul>
        ///     </para>
        /// </remarks>
        /// <param name="hilo">Hilo de origen.</param>
        /// <param name="nombre">Nombre del valor guardado.</param>
        /// <returns>Valor guardado.</returns>
        public static object Obtener(this Thread hilo, string nombre)
        {
            var slot = Thread.GetNamedDataSlot(nombre);
            return Thread.GetData(slot);
        }
    }
}
