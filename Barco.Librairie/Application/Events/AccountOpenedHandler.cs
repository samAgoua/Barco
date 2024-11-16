using Barco.Librairie.Domain.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barco.Librairie.Application.Events
{
    public class AccountOpenedHandler : IDomainEventHandler<AccountOpened>
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<AccountOpenedHandler> _logger;

        public AccountOpenedHandler(
            INotificationService notificationService,
            ILogger<AccountOpenedHandler> logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task HandleAsync(AccountOpened @event)
        {
            // Envoyer un email de bienvenue
            await _notificationService.SendWelcomeEmailAsync(@event.CustomerId);

            // Journaliser l'événement
            _logger.LogInformation(
                "New account {AccountId} opened for customer {CustomerId} with initial balance {Balance}",
                @event.AccountId,
                @event.CustomerId,
                @event.InitialBalance);
        }
    }
}
