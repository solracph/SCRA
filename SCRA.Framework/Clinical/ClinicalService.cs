using SCRA.Data.Clinical.Services;
using SCRA.Domain.Clinical;
using SCRA.Framework.Common.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SCRA.Data.Clinical.Entities;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using SCRA.Framework.Common.Errors;

namespace SCRA.Framework.Clinical
{
    public class ClinicalService : IClinicalService
    {
        private readonly ClinicalFactory _clinicalFactory = new ClinicalFactory();

        public ClinicalDbService ClinicalDbService;
        public RuleConstraintException RuleConstraintException;

        public ClinicalService(string connString)
        {
            ClinicalDbService = new ClinicalDbService(connString);
            RuleConstraintException = new RuleConstraintException(connString);
        }

        #region  Get
            public async Task<Result> GetApplications()
            {
                IList<Application> applications = (await ClinicalDbService.ApplicationRepository.GetAllAsync())
                    .Select(item => _clinicalFactory.MappingToApplication.DefaultContext.Mapper.Map<Application>(item)).ToList();

                return Result.New(applications);
            }

            public async Task<Result> GetContracts()
            {
                IList<Contract> contracts = (await ClinicalDbService.ContractRepository.GetAllAsync())
                     .Select(item => _clinicalFactory.MappingToContract.DefaultContext.Mapper.Map<Contract>(item)).ToList();

                return Result.New(contracts);
            }

            public async Task<Result> GetMeasures()
            {
                IList<Measure> mesures = (await ClinicalDbService.MeasureRepository.GetAllAsync())
                    .Select(item => _clinicalFactory.MappingToMesures.DefaultContext.Mapper.Map<Measure>(item)).ToList();

                return Result.New(mesures);
            }

            public async Task<Result> GetPbpList()
            {
                IList<Pbp> pbpList = (await ClinicalDbService.PbpRepository.GetAllAsync())
                    .Select(item => _clinicalFactory.MappingToPbp.DefaultContext.Mapper.Map<Pbp>(item)).ToList();

                return Result.New(pbpList);
            }

            public async Task<Result> GetRules()
            {
                IList<Rule> rules = (await ClinicalDbService.RuleRepository.GetAllAsync())
                    .Select(item => _clinicalFactory.MappingToRule.DefaultContext.Mapper.Map<Rule>(item)).ToList();

                return Result.New(rules);
            }

            public async Task<Result> GetSegments()
            {
                IList<Segment> segments = (await ClinicalDbService.SegmentRepository.GetAllAsync())
                    .Select(item => _clinicalFactory.MappingToSegment.DefaultContext.Mapper.Map<Segment>(item)).ToList();

                return Result.New(segments);
            }

            public async Task<Result> GetTinList()
            {
                IList<Tin> tinList = (await ClinicalDbService.TinRepository.GetAllAsync())
                    .Select(item => _clinicalFactory.MappingToTin.DefaultContext.Mapper.Map<Tin>(item)).ToList();

                return Result.New(tinList);
            }

            public async Task<Result> GetUsers()
            {
                IList<User> users = (await ClinicalDbService.UserRepository.GetAllAsync())
                        .Select(item => _clinicalFactory.MappingToUser.DefaultContext.Mapper.Map<User>(item)).ToList();

                return Result.New(users);
            }
        #endregion

        #region  Create
            public async Task<Result> CreateNewRule(Rule rule)
            {
                RuleEntity _ruleEntity = _clinicalFactory.MappingToRuleEntity.DefaultContext.Mapper.Map<RuleEntity>(rule);

                foreach (SegmentEntity Segment in _ruleEntity.Segments)
                {
                    ClinicalDbService.SegmentRepository.AddAndAttach(Segment);
                }

                foreach (ContractEntity Contract in _ruleEntity.Contracts)
                {
                    ClinicalDbService.ContractRepository.AddAndAttach(Contract);
                }

                foreach (PbpEntity Pbp in _ruleEntity.Pbp)
                {
                    ClinicalDbService.PbpRepository.AddAndAttach(Pbp);
                }

               foreach (TinEntity Tin in _ruleEntity.Tin)
                {
                    ClinicalDbService.TinRepository.AddAndAttach(Tin);
                }

                foreach (MeasureEntity Measures in _ruleEntity.Measures)
                {
                    ClinicalDbService.MeasureRepository.AddAndAttach(Measures);
                }

                foreach (ApplicationEntity Application in _ruleEntity.Applications)
                {
                    ClinicalDbService.ApplicationRepository.AddAndAttach(Application);
                }

                ClinicalDbService.RuleRepository.Add(_ruleEntity);

                await ClinicalDbService.SaveAsync();

                return Result.New(_ruleEntity);
            }
        #endregion

        #region  Delete
            public async Task<Result> DeleteRule(Rule rule)
            {
            try
            {
                RuleEntity _ruleEntity = _clinicalFactory.MappingToRuleEntity.DefaultContext.Mapper.Map<RuleEntity>(rule);

                foreach (SegmentEntity Segment in _ruleEntity.Segments)
                {
                    ClinicalDbService.SegmentRepository.AddAndAttach(Segment);
                }

                foreach (ContractEntity Contract in _ruleEntity.Contracts)
                {
                    ClinicalDbService.ContractRepository.AddAndAttach(Contract);
                }

                foreach (PbpEntity Pbp in _ruleEntity.Pbp)
                {
                    ClinicalDbService.PbpRepository.AddAndAttach(Pbp);
                }

                foreach (TinEntity Tin in _ruleEntity.Tin)
                {
                    ClinicalDbService.TinRepository.AddAndAttach(Tin);
                }

                foreach (MeasureEntity Measures in _ruleEntity.Measures)
                {
                    ClinicalDbService.MeasureRepository.AddAndAttach(Measures);
                }

                foreach (ApplicationEntity Application in _ruleEntity.Applications)
                {
                    ClinicalDbService.ApplicationRepository.AddAndAttach(Application);
                }


                ClinicalDbService.RuleRepository.Delete(_ruleEntity);

                await ClinicalDbService.SaveAsync();

                return Result.New(_ruleEntity);
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;

                if (sqlException != null)
                {
                    var number = sqlException.Number;

                    if (number == 547)
                    {
                        Result result = Result.New(null);

                        return result.SetError("547", sqlException, "The rule could not be deleted, there are users associated with it.");
                    }
                }

                return Result.New(null);
            }

        }
        #endregion

        #region  Update
            public async Task<Result> UpdateUserRules(IList<User> users)
            {
                foreach (User user in users)
                {

                    UserEntity newUserEntity = _clinicalFactory.MappingToUserEntityPlain.DefaultContext.Mapper.Map<UserEntity>(user);
                    UserEntity originalUserEntity = ClinicalDbService.UserRepository.GetById(newUserEntity.UserId);

                    IList<Rule> originalRules = (originalUserEntity.Rules)
                       .Select(item => _clinicalFactory.MappingToRule.DefaultContext.Mapper.Map<Rule>(item)).ToList();

                    
                    string ruleConstraintException
                        =  RuleConstraintException.CheckRulesConstraintConsistency(user.Rules.ToList(), user.Rules.Where(r => !originalRules.Any(or => or.RuleId == r.RuleId)).ToList());

                    if (ruleConstraintException == null)
                    {
                        IEnumerable<int> originalRulesId = originalUserEntity.Rules.Select(r => r.RuleId);
                        IEnumerable<int> editedRulesId = newUserEntity.Rules.Select(r => r.RuleId);

                        IList<RuleEntity> rulesToAdd = new List<RuleEntity>();
                        IEnumerable<int> rulesIdToAdd = editedRulesId.Except(originalRulesId);
                        foreach (int ruleId in rulesIdToAdd)
                        {
                            RuleEntity segment = ClinicalDbService.RuleRepository.GetById(ruleId);
                            if (!rulesToAdd.Contains(segment))
                                rulesToAdd.Add(segment);
                        }

                        rulesToAdd.ToList().ForEach(r => originalUserEntity.Rules.Add(r));

                        IList<RuleEntity> rulesToRemove = new List<RuleEntity>();
                        IEnumerable<int> rulesIdRemove = originalRulesId.Except(editedRulesId);

                        foreach (int ruleId in rulesIdRemove)
                        {
                            RuleEntity segment = originalUserEntity.Rules.FirstOrDefault(r => r.RuleId == ruleId);
                            if (!rulesToRemove.Contains(segment))
                                rulesToRemove.Add(segment);
                        }
                        rulesToRemove.ToList().ForEach(r => originalUserEntity.Rules.Remove(r));

                        ClinicalDbService.UserRepository.Update(originalUserEntity);

                        await ClinicalDbService.SaveAsync();
                    }
                    else
                    {
                        Result result = Result.New(null);

                        return result.SetError(null, ruleConstraintException);
                    }
                  
                }

                return Result.New();
            }

            public async Task<Result> UpdateRule(Rule rule )
            {
                RuleEntity newruleEntity = _clinicalFactory.MappingToRuleEntity.DefaultContext.Mapper.Map<RuleEntity>(rule);
                RuleEntity originalRuleEntity = ClinicalDbService.RuleRepository.GetById(newruleEntity.RuleId);

                originalRuleEntity.Description = newruleEntity.Description;

                #region Update Segments ------------------------------------------------------------------------------------

                    IEnumerable<int> originalSegmentsId = originalRuleEntity.Segments.Select(s => s.SegmentId);
                    IEnumerable<int> editedSegmentsId = newruleEntity.Segments.Select(s => s.SegmentId);

                    IList<SegmentEntity> segmentToAdd = new List<SegmentEntity>();
                    IEnumerable<int> segmentsIdToAdd = editedSegmentsId.Except(originalSegmentsId);
                    foreach (int segmentId in segmentsIdToAdd)
                    {
                        SegmentEntity segment = ClinicalDbService.SegmentRepository.GetById(segmentId);
                        if (!segmentToAdd.Contains(segment))
                            segmentToAdd.Add(segment);
                    }

                    segmentToAdd.ToList().ForEach(s => originalRuleEntity.Segments.Add(s));


                    IList<SegmentEntity> segmentToRemove = new List<SegmentEntity>();
                    IEnumerable<int> segmentsIdRemove = originalSegmentsId.Except(editedSegmentsId);

                    foreach (int segmentId in segmentsIdRemove)
                    {
                        SegmentEntity segment = originalRuleEntity.Segments.FirstOrDefault(s => s.SegmentId == segmentId);
                        if (!segmentToRemove.Contains(segment))
                            segmentToRemove.Add(segment);
                    }

                    segmentToRemove.ToList().ForEach(s => originalRuleEntity.Segments.Remove(s));
                #endregion

                #region Update Contracts -----------------------------------------------------------------------------------

                    IEnumerable<int> originalContractsId = originalRuleEntity.Contracts.Select(c => c.ContractId);
                    IEnumerable<int> editedContractsId = newruleEntity.Contracts.Select(c => c.ContractId);

                    IList<ContractEntity> contractToAdd = new List<ContractEntity>();
                    IEnumerable<int> contractsIdToAdd = editedContractsId.Except(originalContractsId);
                    foreach (int contractId in contractsIdToAdd)
                    {
                        ContractEntity contract = ClinicalDbService.ContractRepository.GetById(contractId);
                        if (!contractToAdd.Contains(contract))
                            contractToAdd.Add(contract);
                    }

                    contractToAdd.ToList().ForEach(c => originalRuleEntity.Contracts.Add(c));

                    IList<ContractEntity> contractToRemove = new List<ContractEntity>();
                    IEnumerable<int> contractsIdRemove = originalContractsId.Except(editedContractsId);

                    foreach (int contractId in contractsIdRemove)
                    {
                        ContractEntity contract = originalRuleEntity.Contracts.FirstOrDefault(s => s.ContractId == contractId);
                        if (!contractToRemove.Contains(contract))
                            contractToRemove.Add(contract);
                    }

                    contractToRemove.ToList().ForEach(c => originalRuleEntity.Contracts.Remove(c));
                #endregion

                #region Update Pbp -----------------------------------------------------------------------------------------

                    IEnumerable<int> originalPbpId = originalRuleEntity.Pbp.Select(c => c.PbpId);
                    IEnumerable<int> editedPbpId = newruleEntity.Pbp.Select(c => c.PbpId);

                    IList<PbpEntity> pbpToAdd = new List<PbpEntity>();
                    IEnumerable<int> pbpsIdToAdd = editedPbpId.Except(originalPbpId);
                    foreach (int pbpId in pbpsIdToAdd)
                    {
                        PbpEntity pbp = ClinicalDbService.PbpRepository.GetById(pbpId);
                        if (!pbpToAdd.Contains(pbp))
                            pbpToAdd.Add(pbp);
                    }

                    pbpToAdd.ToList().ForEach(c => originalRuleEntity.Pbp.Add(c));

                    IList<PbpEntity> pbpToRemove = new List<PbpEntity>();
                    IEnumerable<int> pbpsIdRemove = originalPbpId.Except(editedPbpId);

                    foreach (int pbpId in pbpsIdRemove)
                    {
                        PbpEntity pbp = originalRuleEntity.Pbp.FirstOrDefault(s => s.PbpId == pbpId);
                        if (!pbpToRemove.Contains(pbp))
                            pbpToRemove.Add(pbp);
                    }

                    pbpToRemove.ToList().ForEach(c => originalRuleEntity.Pbp.Remove(c));
                #endregion

                #region Update TIN -----------------------------------------------------------------------------------------

                    IEnumerable<int> originalTinId = originalRuleEntity.Tin.Select(c => c.TinId);
                    IEnumerable<int> editedTinId = newruleEntity.Tin.Select(c => c.TinId);

                    IList<TinEntity> tinToAdd = new List<TinEntity>();
                    IEnumerable<int> tinsIdToAdd = editedTinId.Except(originalTinId);
                    foreach (int tinId in tinsIdToAdd)
                    {
                        TinEntity tin = ClinicalDbService.TinRepository.GetById(tinId);
                        if (!tinToAdd.Contains(tin))
                            tinToAdd.Add(tin);
                    }

                    tinToAdd.ToList().ForEach(c => originalRuleEntity.Tin.Add(c));

                    IList<TinEntity> tinToRemove = new List<TinEntity>();
                    IEnumerable<int> tinsIdRemove = originalTinId.Except(editedTinId);

                    foreach (int tinId in tinsIdRemove)
                    {
                        TinEntity tin = originalRuleEntity.Tin.FirstOrDefault(s => s.TinId == tinId);
                        if (!tinToRemove.Contains(tin))
                            tinToRemove.Add(tin);
                    }

                    tinToRemove.ToList().ForEach(c => originalRuleEntity.Tin.Remove(c));
                #endregion

                #region Update Measures ------------------------------------------------------------------------------------

                    IEnumerable<int> originalMeasuresId = originalRuleEntity.Measures.Select(c => c.MeasureId);
                    IEnumerable<int> editedMeasuresId = newruleEntity.Measures.Select(c => c.MeasureId);

                    IList<MeasureEntity> measuresToAdd = new List<MeasureEntity>();
                    IEnumerable<int> measuresIdToAdd = editedMeasuresId.Except(originalMeasuresId);
                    foreach (int measureId in measuresIdToAdd)
                    {
                        MeasureEntity measure = ClinicalDbService.MeasureRepository.GetById(measureId);
                        if (!measuresToAdd.Contains(measure))
                        measuresToAdd.Add(measure);
                    }

                    measuresToAdd.ToList().ForEach(c => originalRuleEntity.Measures.Add(c));

                    IList<MeasureEntity> measuresToRemove = new List<MeasureEntity>();
                    IEnumerable<int> measuresIdRemove = originalMeasuresId.Except(editedMeasuresId);

                    foreach (int measureId in measuresIdRemove)
                    {
                        MeasureEntity measure = originalRuleEntity.Measures.FirstOrDefault(s => s.MeasureId == measureId);
                        if (!measuresToRemove.Contains(measure))
                        measuresToRemove.Add(measure);
                    }

                    measuresToRemove.ToList().ForEach(c => originalRuleEntity.Measures.Remove(c));
                #endregion

                #region Update Applications --------------------------------------------------------------------------------

                    IEnumerable<int> originalApplicationsId = originalRuleEntity.Applications.Select(c => c.ApplicationId);
                    IEnumerable<int> editedApplicationsId = newruleEntity.Applications.Select(c => c.ApplicationId);

                    IList<ApplicationEntity> applicationsToAdd = new List<ApplicationEntity>();
                    IEnumerable<int> applicationsIdToAdd = editedApplicationsId.Except(originalApplicationsId);
                    foreach (int applicationId in applicationsIdToAdd)
                    {
                        ApplicationEntity application = ClinicalDbService.ApplicationRepository.GetById(applicationId);
                        if (!applicationsToAdd.Contains(application))
                            applicationsToAdd.Add(application);
                    }

                    applicationsToAdd.ToList().ForEach(c => originalRuleEntity.Applications.Add(c));

                    IList<ApplicationEntity> applicationsToRemove = new List<ApplicationEntity>();
                    IEnumerable<int> applicationsIdRemove = originalApplicationsId.Except(editedApplicationsId);

                    foreach (int applicationId in applicationsIdRemove)
                    {
                        ApplicationEntity application = originalRuleEntity.Applications.FirstOrDefault(s => s.ApplicationId == applicationId);
                        if (!applicationsToRemove.Contains(application))
                            applicationsToRemove.Add(application);
                    }

                    applicationsToRemove.ToList().ForEach(c => originalRuleEntity.Applications.Remove(c));
                #endregion

                ClinicalDbService.RuleRepository.Update(originalRuleEntity);

                await ClinicalDbService.SaveAsync();

                return Result.New(originalRuleEntity);
            }
        #endregion
        
    }


}
