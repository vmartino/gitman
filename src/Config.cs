using System.Text.RegularExpressions;

namespace gitman {
    public static class Config
        {
            public static class Github {
                public static string User { get; set; }
                public static string Token { get; set; }
                public static string Org {get; set;} = "sectigo-eng";

                public static new string ToString() => $"Github[user={User} token={!string.IsNullOrEmpty(Token)} Org={Org}]";
            }
            
            private static bool dryrun;

            public static string TeamStructureFile { get; set; }
            public static string RepoStructureFile { get; set; }
            public static string ReportingPath { get; set; } = "./";
            public static string DryRunMode { get; set; } = "yes";
            public static bool DryRun
            {
                get { return DryRunMode.Equals("yes"); }
            }
            
            public static bool Help { get; set; }

            public static bool HasTeamsStructureFile { get => !string.IsNullOrEmpty(TeamStructureFile); }
            public static bool HasRepoStructureFile { get => !string.IsNullOrEmpty(RepoStructureFile); }

            public static bool Validate() => !string.IsNullOrEmpty(Github.User) && !string.IsNullOrEmpty(Github.Token)
                && Regex.IsMatch(DryRunMode, "yes|no")
                && (HasRepoStructureFile ? System.IO.File.Exists(RepoStructureFile) : true)
                && (HasTeamsStructureFile ? System.IO.File.Exists(TeamStructureFile) : true);

            public static new string ToString() => $"{Github.ToString()} TeamStructure={TeamStructureFile} RepoStructureFile={RepoStructureFile} DryRun={DryRun} Help={Help}";
        }
}