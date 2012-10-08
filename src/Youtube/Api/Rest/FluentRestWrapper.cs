//-----------------------------------------------------------------------
// <copyright file="FluentRestWrapper.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using RestSharp;

namespace Youtube.Api.Rest
{
    /// <summary>
    /// Fluent rest wrapper
    /// </summary>
    public class FluentRestWrapper
    {
        /// <summary>
        /// rest wrapper
        /// </summary>
        private readonly RestWrapper restWrapper;

        /// <summary>
        /// parameters of query
        /// </summary>
        private readonly List<Parameter> parameters;

        /// <summary>
        /// name of method 
        /// </summary>
        private readonly string method;

        private readonly RestSharp.Method type;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentRestWrapper"/> class.
        /// </summary>
        /// <param name="restWrapper">The rest wrapper.</param>
        /// <param name="method">The method.</param>
        public FluentRestWrapper(RestWrapper restWrapper, string method, Method type = Method.GET)
        {
            this.parameters = new List<Parameter>();
            this.restWrapper = restWrapper;
            this.method = method;
            this.type = type;
        }

        /// <summary>
        /// Params the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>Fluent wrapper</returns>
        public FluentRestWrapper AddParam(string name, object value, ParameterType type = ParameterType.GetOrPost)
        {
            this.parameters.Add(new Parameter { Name = name, Value = value, Type = type});
            return this;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <returns>Returning type</returns>
        public TModel Execute<TModel>() where TModel : new()
        {
            return this.restWrapper.Execute<TModel>(this.method, this.type, this.parameters.ToArray());
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <returns>Returning type</returns>
        public string Execute()
        {
            return this.restWrapper.Execute(this.method, this.type, this.parameters.ToArray());
        }

    }
}
