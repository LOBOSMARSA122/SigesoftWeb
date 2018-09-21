using System.Data.Entity;
using BE.Security;
using BE.Common;
using BE.Component;
using BE.Diagnostic;
using BE.History;
using BE.Organization;
using BE.Protocol;
using BE.Service;
using BE.Warehouse;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=BDSigesoft") { }
        public DbSet<SystemUserBE> SystemUser { get; set; }
        public DbSet<PersonBE> Person { get; set; }
        public DbSet<ProfessionalBE> Professional { get; set; }

        public DbSet<RoleNodeProfileBE> RoleNodeProfile { get; set; }
        public DbSet<RoleNodeBE> RoleNode { get; set; }
        public DbSet<SystemUserRoleNodeBE> SystemUserRoleNode { get; set; }
        
        public DbSet<SystemParameterBE> SystemParameter { get; set; }
        public DbSet<SystemUserGobalProfileBE> SystemUserGobalProfile { get; set; }
        public DbSet<AplicationHierarchyBE> AplicationHierarchy { get; set; }
        public DbSet<AttentionInAreaBE> AttentionInArea { get; set; }
        public DbSet<AttentionInAreaComponentBE> AttentionInAreaComponent { get; set; }
        public DbSet<Cie10BE> Cie10 { get; set; }
        public DbSet<CIIUIBE> CIIUI { get; set; }
        public DbSet<DataHierarchyBE> DataHierarchy { get; set; }
        public DbSet<EmailBE> Email { get; set; }
        public DbSet<LogBE> Log { get; set; }
        public DbSet<MasterRecommendationRestricctionBE> MasterRecommendationRestricction { get; set; }
        public DbSet<MultimediaFileBE> MultimediaFile { get; set; }
        public DbSet<NodeBE> Node { get; set; }
        public DbSet<NodeOrganizationLocationProfileBE> NodeOrganizationLocationProfile { get; set; }
        public DbSet<NodeOrganizationLocationWarehouseProfileBE> NodeOrganizationLocationWarehouseProfile { get; set; }
        public DbSet<NodeOrganizationProfileBE> NodeOrganizationProfile { get; set; }
        public DbSet<NodeServiceProfileBE> NodeServiceProfile { get; set; }
        public DbSet<PacientBE> Pacient { get; set; }
        public DbSet<PacientMultimediaDataBE> PacientMultimediaData { get; set; }
        public DbSet<RecommendationBE> Recommendation { get; set; }
        public DbSet<RestrictionBE> Restriction { get; set; }
        public DbSet<RoleNodeComponentProfileBE> RoleNodeComponentProfile { get; set; }

        public DbSet<ComponentFieldBE> ComponentField { get; set; }
        public DbSet<ComponentBE> Component { get; set; }
        public DbSet<ComponentFieldsBE> ComponentFields { get; set; }
        public DbSet<ComponentFieldValuesBE> ComponentFieldValues { get; set; }
        public DbSet<ComponentFieldValuesRecommendationBE> ComponentFieldValuesRecommendation { get; set; }
        public DbSet<ComponentFieldValuesRestrictionBE> ComponentFieldValuesRestriction { get; set; }


        public DbSet<DiseasesBE> Diseases { get; set; }
        public DbSet<DxFrecuenteBE> DxFrecuente { get; set; }
        public DbSet<DxFrecuenteDetalleBE> DxFrecuenteDetalle { get; set; }

        public DbSet<FamilyMedicalAntecedentsBE> FamilyMedicalAntecedents { get; set; }
        public DbSet<HistoryBE> History { get; set; }
        public DbSet<NoxiousHabitsBE> NoxiousHabits { get; set; }
        public DbSet<PersonMedicalHistoryBE> PersonMedicalHistory { get; set; }
        public DbSet<WorkStationDangersBE> WorkStationDangers { get; set; }

        public DbSet<AreaBE> Area { get; set; }
        public DbSet<CodigoEmpresaBE> CodigoEmpresa { get; set; }
        public DbSet<GesBE> Ges { get; set; }
        public DbSet<GroupOccupationBE> GroupOccupation { get; set; }
        public DbSet<LocationBE> Location { get; set; }
        public DbSet<OccupationBE> Occupation { get; set; }
        public DbSet<OrganizationBE> Organization { get; set; }

        public DbSet<ProtocolBE> Protocol { get; set; }
        public DbSet<ProtocolComponentBE> ProtocolComponent { get; set; }
        public DbSet<ProtocolSystemUserBE> ProtocolSystemUser { get; set; }
        public DbSet<SecuentialBE> Secuential { get; set; }

        public DbSet<AuthorizationModel> AuthorizationModel { get; set; }

        public DbSet<CalendarBE> Calendar { get; set; }
        public DbSet<DiagnosticRepositoryBE> DiagnosticRepository { get; set; }
        public DbSet<ServiceBE> Service { get; set; }
        public DbSet<ServiceComponentBE> ServiceComponent { get; set; }
        public DbSet<ServiceComponentFieldsBE> ServiceComponentFields { get; set; }
        public DbSet<ServiceComponentFieldValuesBE> ServiceComponentFieldValues { get; set; }
        public DbSet<ServiceComponentMultimediaBE> ServiceComponentMultimedia { get; set; }
        public DbSet<ServiceMultimediaBE> ServiceMultimedia { get; set; }

        public DbSet<MovementBE> Movement { get; set; }
        public DbSet<MovementDetailBE> MovementDetail { get; set; }
        public DbSet<ProductBE> Product { get; set; }
        public DbSet<ProductsForMigrationBE> ProductsForMigration { get; set; }
        public DbSet<ProductWarehouseBE> ProductWarehouse { get; set; }
        public DbSet<RestrictedWarehouseProfileBE> RestrictedWarehouseProfile { get; set; }
        public DbSet<WarehouseBE> Warehouse { get; set; }

        public DbSet<ApplicationHierarchyBE> ApplicationHierarchy { get; set; }
    }
}
