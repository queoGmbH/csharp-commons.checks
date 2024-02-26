using System.IO;

using Build.Common.Enums;

using Cake.Common.Tools.DotNet;
using Cake.Frosting;

namespace Build.Tasks
{
    public sealed class BuildNuGetPackage : FrostingTask<Context>
    {
        public override void Run(Context context)
        {
            string versionPrefix, versionSuffix;
            foreach (var projectToBuild in context.Lib)
            {
                if (!context.General.IsLocal && context.General.CurrentBranch == Branches.Main)
                {
                    versionSuffix = string.Empty;
                }
                else
                {
                    versionSuffix = $"{projectToBuild.ArtifactVersion.Prerelease}-{projectToBuild.ArtifactVersion.Build}";
                }
                context.DotNetPack(Path.Combine(context.Environment.WorkingDirectory.FullPath, projectToBuild.MainProject),
                    new Cake.Common.Tools.DotNet.Pack.DotNetPackSettings()
                    {
                        Configuration = "Release",
                        OutputDirectory = "./.artifacts",
                        VersionSuffix = versionSuffix
                    });
            }
        }
    }
}
