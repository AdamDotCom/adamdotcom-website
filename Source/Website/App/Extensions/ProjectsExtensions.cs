using System.Linq;
using AdamDotCom.OpenSource.Service.Proxy;

namespace AdamDotCom.Website.App.Extensions
{
    public static class ProjectsExtensions
    {
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
                project.Description = "Scripts that I use on a daily basis. You'll find JavaScript, Ruby, and PowerShell here. You may be interested in learning more about my PoweShell work <a href='http://adam.kahtava.com/journal/category/powershell/'>here</a>";
            }

            if (project.Name == "services")
            {
                project.Description = "The services that deliver the data to this website. Here you'll find a Whois service, an Amazon service, a Resume (from LinkedIn) service, and an Open Source Projects service that combines project repositories from both GitHub and Google Code. There's more information about these services <a href='http://adam.kahtava.com/journal/category/open-source/adc-services/'>here</a>";
            }

            if (project.Name == "website" && project.Url.Contains("code.google"))
            {
                project.Description = "The source code for this entire website! As well as the source for this page, and the source for this entire site. Read more about how this site is constructed <a href='http://adam.kahtava.com/journal/category/open-source/adc-website/'>here</a>";
            }

            if (project.Name == "amazon")
            {
                project.Description = "An Amazon Web Services (AWS) client. This is the basis of my Amazon service. Learn more about this topic <a href='http://adam.kahtava.com/journal/category/amazon/'>here</a>";
            }

            if (project.Name == "project badge")
            {
                project.Description += " The source code for this very widget you're hovering your mouse over";
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