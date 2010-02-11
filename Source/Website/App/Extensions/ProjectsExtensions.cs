using System.Linq;
using AdamDotCom.OpenSource.Service.Proxy;

namespace AdamDotCom.Website.App.Extensions
{
    public static class ProjectsExtensions
    {
        // In some cases I have a repo on GitHub and GoogleCode, so...
        //  filter out the oldest duplicate repo
        //  GitHub let's you associate projects to users, but GoogleCode requires unique project names, so...
        //  remove the unique prefix for comparison
        public static Projects RemoveOldDuplicates(this Projects projects)
        {
            if (projects == null || projects.Count == 0)
            {
                return null;
            }

            var orderedProjects = projects.Clean().OrderBy(p => p.Name).ThenByDescending(p => p.LastModified).ToList();
            
            var projectsToReturn = new Projects();
            var lastProjectName = string.Empty;
            for (var i = 0; i < orderedProjects.Count; i++)
            {
                var thisProjectName = orderedProjects[i].Name.RemoveTrailingCharacter("s").Remove("adamdotcom-");   

                if(lastProjectName != thisProjectName)
                {
                    projectsToReturn.Add(orderedProjects[i]);
                }

                lastProjectName = thisProjectName;
            }

            return projectsToReturn;
        }

        public static Projects Enhance(this Projects projects)
        {
            if (projects == null)
            {
                return null;
            }

            return new Projects(projects.Select(p => p.Enhance()));
        }

        public static Projects Clean(this Projects projects)
        {
            if (projects == null || projects.Count == 0)
            {
                return null;
            }

            return new Projects(projects.Select(p => p.Clean()));
        }

        public static Project Clean(this Project project)
        {
            project.Name = project.Name.Remove("adamdotcom-");
            if (project.Name == "script")
            {
                project.Name = "scripts";
            }

            return project;
        }

        // Project descriptions are written from the context of the hosting site
        //  re-word descriptions from the context of my site
        public static Project Enhance(this Project project)
        {
            if (project.Name == "scripts")
            {
                project.Description =
                    "A collection of my scripts that I use on a daily basis and other things. You'll find JavaScript, Ruby, and PowerShell here";
            }

            if (project.Name == "services")
            {
                project.Description =
                    "These are the services that drive this very site. Here you'll find a Whois, Amazon, Resume (from LinkedIn), and an Open Source Projects (from GitHub and Google Code) Service";
            }

            if (project.Name == "website" && project.Url.Contains("code.google"))
            {
                project.Description = "Here you'll find the source code for this very page and site";
            }

            if (project.Name == "amazon")
            {
                project.Description =
                    "This is an Amazon Web Services (AWS) client. This is actually the basis of my Amazon Service (see my Services repository too)";
            }

            project.Name = project.Name.Replace("-", " ").Capitalize();

            if (project.Url.Contains("code.google"))
            {
                project.Url = project.Url + "/source/browse/trunk";
            }
            return project;
        }

        public static string RemoveTrailingCharacter(this string value, string character)
        {
            if (value.LastIndexOf(character) == value.Length - 1)
            {
                return value.Remove(value.Length - 1);
            }
            return value;
        }

        public static string Remove(this string value, string stringToRemove)
        {
            return value.Replace(stringToRemove, "");
        }
    }
}
