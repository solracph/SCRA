using AutoMapper;
using SCRA.Data.Clinical.Entities;
using SCRA.Domain.Clinical;

namespace SCRA.Framework.Clinical
{
    public class ClinicalFactory
    {
        private Mapper _mappingToApplication;
        private Mapper _mappingToSegment;
        private Mapper _mappingToPbp;
        private Mapper _mappingToContract;
        private Mapper _mappingToTin;
        private Mapper _mappingToMesure;
        private Mapper _mappingToRule;
        private Mapper _mappingToRuleEntity;
        private Mapper _mappingToUser;
        private Mapper _mappingToUserEntity;

        public Mapper MappingToApplication
            => _mappingToApplication ?? (_mappingToApplication = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ApplicationEntity, Application>())));

        public Mapper MappingToSegment
            => _mappingToSegment ?? (_mappingToSegment = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SegmentEntity, Segment>())));

        public Mapper MappingToContract
          => _mappingToContract ?? (_mappingToContract = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ContractEntity, Contract>())));

        public Mapper MappingToPbp
            => _mappingToPbp ?? (_mappingToPbp = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PbpEntity, Pbp>())));

        public Mapper MappingToTin
          => _mappingToTin ?? (_mappingToTin = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TinEntity, Tin>())));

        public Mapper MappingToMesures
          => _mappingToMesure ?? (_mappingToMesure = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MeasureEntity, Measure>())));

        public Mapper MappingToRule
          => _mappingToRule ?? (_mappingToRule = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<RuleEntity, Rule>())));

        public Mapper MappingToRuleEntity
            => _mappingToRuleEntity ?? (_mappingToRuleEntity = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rule, RuleEntity>();
                cfg.CreateMap<Segment, SegmentEntity>();
                cfg.CreateMap<Contract, ContractEntity>();
                cfg.CreateMap<Pbp, PbpEntity>();
                cfg.CreateMap<Tin, TinEntity>();
                cfg.CreateMap<Measure, MeasureEntity>();
                cfg.CreateMap<Application, ApplicationEntity>();
            }
        )));

        public Mapper MappingToUser
         => _mappingToUser ?? (_mappingToUser = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserEntity, User>())));

        public Mapper MappingToUserEntity
           => _mappingToUserEntity ?? (_mappingToUserEntity = new Mapper(new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<User, UserEntity>();
               cfg.CreateMap<Rule, RuleEntity>();
               cfg.CreateMap<Application, ApplicationEntity>();
           }
       )));

    public Mapper MappingToUserEntityPlain
          => _mappingToUserEntity ?? (_mappingToUserEntity = new Mapper(new MapperConfiguration(cfg =>
          {
              cfg.CreateMap<User, UserEntity>();
              cfg.CreateMap<Rule, RuleEntity>()
                .ForMember(r => r.Segments, opt => opt.Ignore())
                .ForMember(r => r.Contracts, opt => opt.Ignore())
                .ForMember(r => r.Pbp, opt => opt.Ignore())
                .ForMember(r => r.Tin, opt => opt.Ignore())
                .ForMember(r => r.Measures, opt => opt.Ignore())
                .ForMember(r => r.Applications, opt => opt.Ignore());
              cfg.CreateMap<Application, ApplicationEntity>();
          }
      )));
    }
}
