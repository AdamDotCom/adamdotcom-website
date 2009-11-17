namespace AdamDotCom.Website.App.Extensions
{
    using Resume = Resume.Service.Proxy.Resume;

    public static class ResumeExtensions
    {
        /// <summary>
        /// Make my resume more search engine friendly.
        /// This is really specific to my resume, not generic at all.
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public static Resume Enrich(this Resume resume)
        {
            if(resume.Specialties!=null)
            {
                resume.Specialties = AcronymEnricher(resume.Specialties);
            }
            if (resume.Positions != null)
            {
                foreach (var position in resume.Positions)
                {
                    if (position != null && position.Company != null)
                    {
                        position.Company = position.Company.Replace("Corbis", string.Format("Corbis / Veer {0}", EnrichedMarkup("Veer.com, Veer Marketplace, Calgary, Alberta, Canada")));
                        position.Company = position.Company.Replace("Critical Mass", string.Format("Critical Mass {0}", EnrichedMarkup("Hyatt, Calgary, Alberta, Canada")));                      
                        position.Company = position.Company.Replace("Allstream", string.Format("MTS Allstream {0}", EnrichedMarkup("CAAF: City of Calgary Application Architecture Framework, Calgary, Alberta, Canada")));
                        position.Company = position.Company.Replace("Cactus Commerce", string.Format("Cactus Commerce {0}", EnrichedMarkup("Ottawa, Ontario, Gatineau, Quebec, GameStop, Folica, Ecommerce, E-commerce, B2B, B2C, C2C, Biztalk, Commerce Server")));
                        position.Company = position.Company.Replace("Mercurial Communications", string.Format("Mercurial Communications {0}", EnrichedMarkup("Netscape 8.0 Browser, Tempus Microsystems, Victoria, British Columbia, Canada")));
                    }
                    if (position != null && position.Description != null)
                    {
                        position.Description = position.Description.Replace("&#x2022; Technologies Used:", "<strong>Technologies Used:</strong>");
                        position.Description = AcronymEnricher(position.Description);
                    }
                }
            }
            if (resume.Educations != null)
            {
                foreach (var education in resume.Educations)
                {
                    if (education.Institute != null)
                    {
                        if (education.Institute.Contains("Seneca"))
                        {
                            education.Institute = string.Format("<a href=\"http://www.senecac.on.ca/\" title=\"{0}\">{0}</a> {1}", education.Institute, EnrichedMarkup("Toronto, Ontario, Canada"));
                        }
                        if (education.Institute.Contains("Trent"))
                        {
                            education.Institute = string.Format("<a href=\"http://www.trentu.ca/\" title=\"{0}\">{0}</a> {1}", education.Institute, EnrichedMarkup("Peterborough, Ontario, Canada, BSc, B.Sc, Honors, Computer Science"));
                        }
                    }
                }
            }
            return resume;
        }

        public static string AcronymEnricher(string description)
        {
            var acronymTable = new[]
                                   {
                                       new[] {"CSS", "Cascading Style Sheets"},
                                       new[] {"IIS", "Microsoft's Internet Information Services"},
                                       new[] {"HTML", "Hyper Text Markup Language"},
                                       new[] {"PHP", "PHP: Hypertext Preprocessor"},
                                       new[] {"API", "Application programming interface"},
                                       new[] {"CVS", "Concurrent Versions System"},
                                       new[] {"XML", "Extensible Markup Language"},
                                       new[] {"XSLT", "Extensible Stylesheet Language Transformations"},
                                       new[] {"XSL", "Extensible Stylesheet Language"},
                                       new[] {"SOAP", "Simple Object Access Protocol"},
                                       new[] {"AJAX", "Asynchronous JavaScript and XML"},
                                       new[] {"TDD", "Test Driven Design"},
                                       new[] {"MOSS", "Microsoft's Office Sharepoint Server"},
                                       new[] {"WCF", "Microsoft's Windows Communication Foundation"},
                                       new[] {"TFS", "Microsoft's Team Foundation System"},
                                       new[] {"VSS", "Microsoft's Visual Source Safe"}, 
                                       new[] {"JSP", "JavaServer Pages"},
                                       new[] {"JSTL", "JavaServer Pages Standard Tag Library"},
                                       new[] {"MVC", "Model View Controller"},
                                       new[] {"XHTML", "Extensible Hypertext Markup Language"},                                       
                                       new[] {"VB6", "Visual Basic 6"}, 
                                       new[] {"WSDL", "Web Service Definition Language"},
                                       new[] {"REST", "Representational State Transfer"},
                                       new[] {"JSON", "JavaScript Object Notation"},
                                       new[] {"CMS", "Content Management System"},
                                       new[] {"SQL", "Structured Query Language"},
                                       new[] {"T-SQL", "Transact Structured Query Language"},
                                       new[] {"LINQ", "Microsoft's Language Integrated Query"},
                                       new[] {"CAAF Framework", "The City of Calgary's Application Architecture Framework"},
                                       new[] {"CAAF", "The City of Calgary's Application Architecture Framework"},
                                       new[] {"C#", "Microsoft's C-Sharp Programming Language"},
                                       new[] {"SOA", "Service Oriented Architecture"},
                                       new[] {"SEO", "Search Engine Optimization"},
                                       new[] {"PL/SQL", "Procedural Language / Structured Query Language"}
                                   };

            for (int i = 0; i < acronymTable.Length; i++)
            {
                var markup = AcronymMarkup(acronymTable[i][0], acronymTable[i][1]);
                description = description.Replace(string.Format(", {0}", acronymTable[i][0]), string.Format(", {0}", markup));
                description = description.Replace(string.Format(" {0},", acronymTable[i][0]), string.Format(" {0},", markup));
            }
            
            return description;
        }

        public static string AcronymMarkup(string acronym, string acronymDescription)
        {
            return string.Format("<acronym title=\"{0}\">{1}</acronym>", acronymDescription, acronym);
        }

        public static string EnrichedMarkup(string content)
        {
            return string.Format("<span class=\"enrich\">{0}</span>", content);
        }
    }
}
