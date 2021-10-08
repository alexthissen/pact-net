using System;

namespace PactNet.Verifier.Messaging
{
    /// <summary>
    /// The scenarios used to generate messages when verifying messaging pacts
    /// </summary>
    public interface IMessageScenariosFactory
    {
        /// <summary>
        /// Add a configured scenario
        /// </summary>
        /// <param name="scenario">Scenario</param>
        IMessageScenariosFactory Add(Scenario scenario);

        /// <summary>
        /// Add a message scenario
        /// </summary>
        /// <param name="description">Scenario description</param>
        /// <param name="factory">Message content factory</param>
        IMessageScenariosFactory Add(string description, Func<dynamic> factory);

        /// <summary>
        /// Add a message scenario
        /// </summary>
        /// <param name="description">Scenario description</param>
        /// <param name="metadata">Message metadata</param>
        /// <param name="factory">Message content factory</param>
        IMessageScenariosFactory Add(string description, dynamic metadata, Func<dynamic> factory);
    }
}