﻿using CorporateChatClub.Domain.ViewModels.User;

namespace CorporateChatClub.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public UserInformation GetUserInformation(Guid UserId);

        public bool UpdateProfilePicture(Guid UserId, string Picture);

        public bool UpdatePersonalDetails(Guid UserId, UserPersonalDetails PersonalDetails);

        public bool UpdateUserSummary(Guid UserId, string userSummary);

        public Guid GetAddressId(Guid UserId);

        public bool IsUserExist(Guid UserId);

        public int UpdateAddressDetails(Guid AddressId, UserContactDetails contactDetails);

        public bool UpdateContactDetails(Guid UserId, UserContactDetails ContactDetails);

    }
}
