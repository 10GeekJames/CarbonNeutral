namespace WskCore.Entities;
public class AuthorAddedToBookDomainEventHandler : INotificationHandler<AuthorAddedToBookDomainEvent>
    {
        public async Task Handle(AuthorAddedToBookDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            await Task.Yield();
            // do awesome things            
        }
    }