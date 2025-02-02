// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

// <auto-generated>This file has been auto generated from 'src\OpenTelemetry.SemanticConventions\scripts\templates\registry\SemanticConventionsAttributes.cs.j2' </auto-generated>

#nullable enable

#pragma warning disable CS1570 // XML comment has badly formed XML

namespace OpenTelemetry.SemanticConventions;

/// <summary>
/// Constants for semantic attribute names outlined by the OpenTelemetry specifications.
/// </summary>
public static class CicdAttributes
{
    /// <summary>
    /// The human readable name of the pipeline within a CI/CD system.
    /// </summary>
    public const string AttributeCicdPipelineName = "cicd.pipeline.name";

    /// <summary>
    /// The unique identifier of a pipeline run within a CI/CD system.
    /// </summary>
    public const string AttributeCicdPipelineRunId = "cicd.pipeline.run.id";

    /// <summary>
    /// The human readable name of a task within a pipeline. Task here most closely aligns with a <a href="https://wikipedia.org/wiki/Pipeline_(computing)">computing process</a> in a pipeline. Other terms for tasks include commands, steps, and procedures.
    /// </summary>
    public const string AttributeCicdPipelineTaskName = "cicd.pipeline.task.name";

    /// <summary>
    /// The unique identifier of a task run within a pipeline.
    /// </summary>
    public const string AttributeCicdPipelineTaskRunId = "cicd.pipeline.task.run.id";

    /// <summary>
    /// The <a href="https://wikipedia.org/wiki/URL">URL</a> of the pipeline run providing the complete address in order to locate and identify the pipeline run.
    /// </summary>
    public const string AttributeCicdPipelineTaskRunUrlFull = "cicd.pipeline.task.run.url.full";

    /// <summary>
    /// The type of the task within a pipeline.
    /// </summary>
    public const string AttributeCicdPipelineTaskType = "cicd.pipeline.task.type";

    /// <summary>
    /// The type of the task within a pipeline.
    /// </summary>
    public static class CicdPipelineTaskTypeValues
    {
        /// <summary>
        /// build.
        /// </summary>
        public const string Build = "build";

        /// <summary>
        /// test.
        /// </summary>
        public const string Test = "test";

        /// <summary>
        /// deploy.
        /// </summary>
        public const string Deploy = "deploy";
    }
}
