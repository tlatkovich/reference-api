using Equipment.Core.Domain.EquipmentAggregate.Events;

namespace Equipment.Infrastructure.Messaging.NotificationHandlers;

public class EquipmentAttachmentAddedEventHandler : INotificationHandler<EquipmentAttachmentAddedEvent>
{
    public Task Handle(EquipmentAttachmentAddedEvent notification, CancellationToken cancellationToken)
    {
        // TODO: Do some stuff with the event, like sending it to a message broker or logging it

        return Task.CompletedTask;
    }
}
