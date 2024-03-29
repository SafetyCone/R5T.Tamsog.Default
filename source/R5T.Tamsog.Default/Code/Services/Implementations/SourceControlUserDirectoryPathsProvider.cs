using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Tamsog.Types;using R5T.T0064;


namespace R5T.Tamsog.Default
{[ServiceImplementationMarker]
    public class SourceControlUserDirectoryPathsProvider : ISourceControlUserDirectoryPathsProvider,IServiceImplementation
    {
        private ISourceControlRootDirectoryPathsProvider SourceControlRootDirectoryPathsProvider { get; }
        private ISourceControlUserDirectoryPathsConvention SourceControlUserDirectoryPathsConvention { get; }


        public SourceControlUserDirectoryPathsProvider(
            ISourceControlRootDirectoryPathsProvider sourceControlRootDirectoryPathsProvider,
            ISourceControlUserDirectoryPathsConvention sourceControlUserDirectoryPathsConvention)
        {
            this.SourceControlRootDirectoryPathsProvider = sourceControlRootDirectoryPathsProvider;
            this.SourceControlUserDirectoryPathsConvention = sourceControlUserDirectoryPathsConvention;
        }

        public IEnumerable<SourceControlUserDirectoryPath> GetSourceControlUserDirectoryPaths()
        {
            // Simple non-LINQ implementation.
            //var sourceControlRootDirectoryPaths = this.SourceControlRootDirectoryPathsProvider.GetSourceControlRootDirectoryPaths();

            //foreach (var sourceControlRootDirectoryPath in sourceControlRootDirectoryPaths)
            //{
            //    var sourceControlUserDirectoryPaths = this.SourceControlUserDirectoryPathsConvention.GetSourceControlUserDirectoryPaths(sourceControlRootDirectoryPath);
            //    foreach (var sourceControlUserDirectoryPath in sourceControlUserDirectoryPaths)
            //    {
            //        yield return sourceControlUserDirectoryPath;
            //    }
            //}

            // LINQ implementation.
            var sourceControlUserDirectoryPaths = this.SourceControlRootDirectoryPathsProvider.GetSourceControlRootDirectoryPaths()
                .SelectMany(sourceControlRootDirectoryPath => this.SourceControlUserDirectoryPathsConvention.GetSourceControlUserDirectoryPaths(sourceControlRootDirectoryPath));

            return sourceControlUserDirectoryPaths;
        }
    }
}
