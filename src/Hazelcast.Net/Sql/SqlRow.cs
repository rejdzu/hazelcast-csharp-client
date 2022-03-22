﻿// Copyright (c) 2008-2021, Hazelcast, Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;

namespace Hazelcast.Sql
{
    /// <summary>
    /// Represents a row in an <see cref="ISqlQueryResult"/>.
    /// </summary>
    public class SqlRow
    {
        private const string KeyColumnName = "__key";
        private const string ValueColumnName = "this";
        private readonly IList<object> _values;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlRow"/> class.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="metadata"></param>
        public SqlRow(IList<object> values, SqlRowMetadata metadata)
        {
            _values = values;
            Metadata = metadata;
        }

        /// <summary>
        /// Gets the row metadata.
        /// </summary>
        public SqlRowMetadata Metadata { get; }

        /// <summary>
        /// Gets th
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetColumn<T>(int index) => (T)_values[index];

        /// <summary>
        /// Gets the value of a column identified by its name.
        /// </summary>
        /// <typeparam name="T">The expected type of the value.</typeparam>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column with the specified name.</returns>
        public T GetColumn<T>(string name) => GetColumn<T>(Metadata.GetColumnIndexByName(name));

        /// <summary>
        /// Gets the key of the row.
        /// </summary>
        /// <typeparam name="T">The expected type of the key.</typeparam>
        /// <returns>The key of the row.</returns>
        public T GetKey<T>() => GetColumn<T>(KeyColumnName);

        /// <summary>
        /// Gets the value of the row.
        /// </summary>
        /// <typeparam name="T">The expected type of the value.</typeparam>
        /// <returns>The value of the row.</returns>
        public T GetValue<T>() => GetColumn<T>(ValueColumnName);
    }
}