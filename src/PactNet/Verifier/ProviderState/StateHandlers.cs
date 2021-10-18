using System;
using System.Collections.Generic;
using System.Linq;
using PactNet.Exceptions;

namespace PactNet.Verifier.ProviderState
{
    /// <summary>
    /// Defines the stateHandlers static list for messaging support
    /// </summary>
    internal static class StateHandlers
    {
        /// <summary>
        /// The available stateHandlers
        /// </summary>
        private static readonly List<IStateHandler> AllStateHandlers = new List<IStateHandler>();

        /// <summary>
        /// Number of stateHandlers
        /// </summary>
        internal static int NumberOfStates => AllStateHandlers.Count;

        /// <summary>
        /// Add a stateHandler
        /// </summary>
        /// <param name="stateHandler">the stateHandler to add</param>
        internal static void AddStateHandler(IStateHandler stateHandler)
        {
            if (stateHandler == null)
            {
                throw new ArgumentNullException(nameof(stateHandler));
            }

            if (Exist(stateHandler))
            {
                throw new StateHandlerConfigurationException(stateHandler);
            }

            AllStateHandlers.Add(stateHandler);
        }

        /// <summary>
        /// Add multiple stateHandlers
        /// </summary>
        /// <param name="stateHandlers">the stateHandler list to add</param>
        internal static void AddStateHandlers(IReadOnlyCollection<StateHandler> stateHandlers)
        {
            if (stateHandlers == null || stateHandlers.Any() == false)
            {
                throw new ArgumentException("state handlers list cannot be null or empty");
            }

            var existingStateHandler = stateHandlers.FirstOrDefault(Exist);
            if (existingStateHandler != null)
            {
                throw new StateHandlerConfigurationException(existingStateHandler);
            }

            AllStateHandlers.AddRange(stateHandlers);
        }

        /// <summary>
        /// Checks if a stateHandler exists
        /// </summary>
        /// <param name="stateHandler">the stateHandler to verify</param>
        /// <returns>If the stateHandler exists</returns>
        private static bool Exist(IStateHandler stateHandler)
        {
            return AllStateHandlers.Any(x => x.Description == stateHandler.Description && x.Action == stateHandler.Action);
        }

        /// <summary>
        /// Get a provider stateHandler by stateHandler description 
        /// </summary>
        /// <param name="description">the description</param>
        /// <param name="stateAction"></param>
        /// <returns>The stateHandler</returns>
        internal static IStateHandler GetByDescriptionAndAction(string description, StateAction stateAction)
        {
            var providerState = AllStateHandlers.FirstOrDefault(x => x.Description == description && x.Action == stateAction);

            return providerState;
        }

        /// <summary>
        /// Clear all stateHandlers
        /// </summary>
        internal static void ClearStateHandlers()
        {
            AllStateHandlers.Clear();
        }
    }
}