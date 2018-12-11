using SCRA.Data.Clinical.Services;
using SCRA.Domain.Clinical;
using SCRA.Framework.Clinical;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRA.Framework.Common.Errors
{
    [Serializable] 
    public class RuleConstraintException : Exception
    {
        private readonly ClinicalFactory _clinicalFactory = new ClinicalFactory();

        public ClinicalDbService ClinicalDbService;

        public RuleConstraintException(string connString) : base()
        {
            ClinicalDbService = new ClinicalDbService(connString);
        }

        public string CheckRulesConstraintConsistency(IList<Rule> AllRules, IList<Rule> NewRules)
        {
            IList<Application> Applications = new Collection<Application>();

            foreach (Rule Rule in AllRules)
            {
                foreach (Application Application in Rule.Applications)
                {
                    Applications.Add(Application);
                }
            }

            IEnumerable<IGrouping<int, Application>> _duplicatedApplication = Applications.GroupBy(a => a.ApplicationId);
            string _return = "";

            foreach (IGrouping<int, Application> aplications in _duplicatedApplication)
            {
                if (aplications.Count() > 1)
                {
                    return CompareRuleContrais(AllRules.Where(r => r.Applications.Any(a => a.ApplicationId == aplications.First().ApplicationId)).ToList(), NewRules);
                }
            }

            return null;
        }

        protected string CompareRuleContrais(IList<Rule> sameApplicationRules, IList<Rule> newrules)
        {
            var _sameApplicationRules = sameApplicationRules.Where(r => !newrules.Any(or => or.RuleId == r.RuleId)).ToList();
            IList<Segment> Segments = new Collection<Segment>();
            IList<Contract> Contracts = new Collection<Contract>();

            string _return = null;
            string _rule = null;
            string _constraint = null;

            if (_sameApplicationRules.Count > 0)
            {
                

                foreach (Rule newrule in newrules)
                {
                    int i = 0;
                    foreach (Rule rule in _sameApplicationRules)
                    {
                        if (rule.Segments.Count > newrule.Segments.Count)
                        {
                            _constraint += !string.IsNullOrEmpty(_constraint) ? ", Segments" : "Segments"; 
                        }

                        if (rule.Contracts.Count > newrule.Contracts.Count)
                        {
                            _constraint += !string.IsNullOrEmpty(_constraint) ? ", Contracts" : "Contracts";
                        }

                        if (rule.Pbp.Count > newrule.Pbp.Count)
                        {
                            _constraint += !string.IsNullOrEmpty(_constraint) ? ", Pbp" : "Pbp"; 
                        }

                        if (rule.Tin.Count > newrule.Tin.Count)
                        {
                            _constraint += !string.IsNullOrEmpty(_constraint) ? ", TaxId" : "TaxId";
                        }

                        if (rule.Measures.Count > newrule.Measures.Count)
                        {
                            _constraint += !string.IsNullOrEmpty(_constraint) ? ", Measures": "Measures";
                        }

                        string _separator = i > 0 ? "and" : "";

                        if (!string.IsNullOrEmpty(_constraint))
                        {
                            _rule += string.Format(" {2} \"{1}\" on constraint(s): [{0}] ", _constraint, rule.Description, _separator);
                            _constraint = null;
                        }

                        i++;
                    }

                    if (!string.IsNullOrEmpty(_rule))
                    {
                        _return += string.Format("Constraint Inconsistency on rule \"{0}\", is more restricted than rule(s) {1}. ", newrule.Description, _rule);
                        _constraint = null;
                        _rule = null;
                    }
                }
            }
            else
            {
                foreach (Rule lrule in sameApplicationRules)
                {
                    int i = 0;
                    foreach (Rule rrule in sameApplicationRules)
                    {
                        if (rrule.RuleId != lrule.RuleId)
                        {
                            if (rrule.Segments.Count > lrule.Segments.Count)
                            {
                                _constraint += !string.IsNullOrEmpty(_constraint) ? ", Segments" : "Segments";
                            }

                            if (rrule.Contracts.Count > lrule.Contracts.Count)
                            {
                                _constraint += !string.IsNullOrEmpty(_constraint) ? ", Contracts" : "Contracts";
                            }

                            if (rrule.Pbp.Count > lrule.Pbp.Count)
                            {
                                _constraint += !string.IsNullOrEmpty(_constraint) ? ", Pbp" : "Pbp";
                            }

                            if (rrule.Tin.Count > lrule.Tin.Count)
                            {
                                _constraint += !string.IsNullOrEmpty(_constraint) ? ", TaxId" : "TaxId";
                            }

                            if (rrule.Measures.Count > lrule.Measures.Count)
                            {
                                _constraint += !string.IsNullOrEmpty(_constraint) ? ", Measures" : "Measures";
                            }

                            string _separator = i > 0 ? "and" : "";

                            if (!string.IsNullOrEmpty(_constraint))
                            {
                                _rule += string.Format(" {2} \"{1}\" on constraint(s): [{0}] ", _constraint, rrule.Description, _separator);
                                _constraint = null;
                                i++;
                            }
                        }
                        
                    }

                    if (!string.IsNullOrEmpty(_rule))
                    {
                        _return += string.Format("Constraint Inconsistency on rule \"{0}\", is more restricted than rule(s) {1}. ", lrule.Description, _rule);
                        _constraint = null;
                        _rule = null;
                    }
                }
            }


            return _return;
        }

    }
}
