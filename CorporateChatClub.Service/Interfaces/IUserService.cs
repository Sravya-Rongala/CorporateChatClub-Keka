using CorporateChatClub.Application.DTO.User;
using CorporateChatClub.Application.DTO.User.ViewModels;

namespace CorporateChatClub.Service.Interfaces
{
    public interface IUserService
    {
        public UserInformationDTO GetUserInformation(Guid UserId);
        public bool UpdateProfilePicture(Guid UserId, string picture);

        public bool UpdatePersonalDetails(Guid UserId, UserPersonalDetailsDTO userPersonalDetails);

        public bool UpdateUserSummary(Guid UserId, string userSummary);

        public bool UpdateContactDetails(Guid UserId, UserContactDetailsDTO contactDetails);
        public bool IsUserExist(Guid UserId);
    }
}
