﻿using BookLibraryCleanArchitecture.Domain.UserAggregate;

namespace BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects
{
    public class UserDto
    {
        public string Id { get; set; }

        public string? UserName { get; set; }

        public string Name { get;set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get;set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public DateTime BirthDate { get; set; }

        public UserStatus Status { get; set; }

        public string? Address { get; set; }
    }
}
