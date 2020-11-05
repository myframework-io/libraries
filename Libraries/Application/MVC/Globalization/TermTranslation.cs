using System.Linq;

namespace Myframework.Libraries.Application.MVC.Globalization
{
    public class TermTranslation
    {
        public long TermId { get; set; }
        public string Term { get; set; }
        public string Translation { get; set; }
        public bool RegexPattern { get; set; }

        public string TermRegex
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Term) || !RegexPattern || !Term.Contains("{"))
                    return Term;

                string term = Term;
                int count = term.Count(it => it == '{');

                for (int j = 0; j < count; j++)
                {
                    term = term.Replace($"{{{j}}}", ".*");
                }

                return term;
            }
        }
    }
}