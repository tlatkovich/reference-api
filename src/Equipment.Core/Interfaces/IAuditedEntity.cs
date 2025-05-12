namespace Equipment.Core.Interfaces;

public interface IAuditedEntity
{
    string CreatedBy { get; set; }
    DateTime? CreatedDate { get; set; }
    string ModifiedBy { get; set; }
    DateTime? ModifiedDate { get; set; }
}