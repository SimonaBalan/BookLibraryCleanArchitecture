﻿using BookLibraryCleanArchitecture.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using BookLibraryCleanArchitecture.Domain.Contracts.Services;


namespace BookLibraryCleanArchitecture.Infrastructure.Persistence.Interceptors
{
    public class AuditableInterceptor : SaveChangesInterceptor
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILoggedInUserService _loggedInUserService;

        public AuditableInterceptor(IDateTimeProvider dateTimeProvider, ILoggedInUserService loggedInUserService)
        {
            _dateTimeProvider = dateTimeProvider;
            _loggedInUserService = loggedInUserService;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateAuditingProperties(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditingProperties(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateAuditingProperties(DbContext? context)
        {
            if (context is null)
                return;

            foreach (var entry in context.ChangeTracker.Entries<IAuditable>())
            {
                switch (entry.State)
                {
                    case (EntityState.Added):
                        entry.Entity.CreatedOn = _dateTimeProvider.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
