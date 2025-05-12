using Equipment.Core.Interfaces;

namespace Equipment.Core.Common.Entities;

public abstract class BaseAuditedEntity<TId> : BaseEntity<TId>, IAuditedEntity
{
    #region Audit Properties

    public string CreatedBy { get; set; } = default!;
    public DateTime? CreatedDate { get; set; } = default!;
    public string ModifiedBy { get; set; } = default!;
    public DateTime? ModifiedDate { get; set; } = default!;

    #endregion
}