using Equipment.Core.Domain.EquipmentAggregate.Events;

namespace Equipment.Infrastructure.Messaging.Handlers;

public class EquipmentAttachmentRemovedEventHandler : INotificationHandler<EquipmentAttachmentRemovedEvent>
{
    public Task Handle(EquipmentAttachmentRemovedEvent notification, CancellationToken cancellationToken)
    {
        // TODO: Do some stuff with the event, like sending it to a message broker or logging it

        return Task.CompletedTask;
    }
}