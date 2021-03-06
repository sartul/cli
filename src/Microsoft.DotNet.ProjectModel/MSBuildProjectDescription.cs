﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.DotNet.ProjectModel.Graph;

namespace Microsoft.DotNet.ProjectModel
{
    /// <summary>
    /// Represents an MSBuild project.
    /// It has been invisibly built by MSBuild, so it behaves like a package: can provide all assets up front
    /// 
    /// Path points to the project's directory
    /// MSBuildPRojectPath points to the csproj file
    /// </summary>
    public class MSBuildProjectDescription : TargetLibraryWithAssets
    {
        public MSBuildProjectDescription(
            string path,
            string msbuildProjectPath,
            LockFileProjectLibrary projectLibrary,
            LockFileTargetLibrary lockFileLibrary,
            Project projectFile,
            IEnumerable<LibraryRange> dependencies,
            bool compatible,
            bool resolved)
            : base(
                  new LibraryIdentity(projectLibrary.Name, projectLibrary.Version, LibraryType.MSBuildProject),
                  string.Empty, //msbuild projects don't have hashes
                  path,
                  lockFileLibrary,
                  dependencies,
                  resolved: resolved,
                  compatible: compatible,
                  framework: null)
        {
            MSBuildProjectPath = msbuildProjectPath;
            ProjectFile = projectFile;
            ProjectLibrary = projectLibrary;
        }

        public LockFileProjectLibrary ProjectLibrary { get; }

        public string MSBuildProjectPath { get; set; }

        public Project ProjectFile { get; }
    }
}
