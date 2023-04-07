using CorporateChatClub.Domain.ViewModels.User;
using CorporateChatClub.Infrastructure.Data;
using CorporateChatClub.Infrastructure.Interfaces;
using Dapper;
using System.Data;

namespace CorporateChatClub.Infrastructure.Repositories.Dapper
{
    public class UserRepository : IUserRepository
    {
        private DbContext _db;
        private IDbConnection connection;

        public UserRepository(DbContext db)
        {
            _db = db;
            connection = _db.CreateConnection();
        }

        public bool IsUserExist(Guid UserId)
        {
            var query = "SELECT 1 FROM Users WHERE Id = @UserId";
            return connection.QueryFirstOrDefault<bool>(query, new { UserId });
        }

        public UserInformation GetUserInformation(Guid UserId)
        {
            var query = "Select * From UserInformationView Where Id = @UserId";
            return connection.QueryFirstOrDefault<UserInformation>(query, new { UserId });
        }

        public bool UpdateProfilePicture(Guid UserId, string picture)
        {
            var query = "UPDATE Users set ProfilePicture = @picture  where Id = @UserId ";
            int noOfRowsAffected = connection.Execute(query, new { UserId, picture });
            return noOfRowsAffected > 0;
        }

        public bool UpdatePersonalDetails(Guid UserId, UserPersonalDetails PersonalDetails)
        {
            var query = $"UPDATE Users set FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, DisplayName = @DisplayName, Gender = @Gender, MaritalStatus = @MaritalStatus, BloodGroup = @BloodGroup, DateOfBirth = @DateOfBirth , About = @About where Id = '{UserId}' ";
            int noOfRowsAffected = connection.Execute(query, PersonalDetails);
            return noOfRowsAffected > 0;
        }

        public bool UpdateUserSummary(Guid UserId, string userSummary)
        {
            var query = "UPDATE Users set Summary = @userSummary  where Id = @UserId";
            int noOfRowsAffected = connection.Execute(query, new { userSummary, UserId });
            return noOfRowsAffected > 0;
        }

        public Guid GetAddressId(Guid UserId)
        {
            var query = "Select Id from Address where UserId = @UserId";
            return connection.QueryFirstOrDefault<Guid>(query, new { UserId });
        }

        public int UpdateAddressDetails(Guid AddressId, UserContactDetails AddressDetails)
        {
            var query = $"UPDATE Address set Line1 = @Line1, Line2 = @Line2, City = @City, State = @State, ZipCode = @ZipCode where Id = '{AddressId}'";
            int noOfRowsAffected = connection.Execute(query, AddressDetails);
            return noOfRowsAffected;
        }

        public bool UpdateContactDetails(Guid UserId, UserContactDetails contactDetails)
        {
            var query = $"UPDATE Users set Phone = @Phone, Email = @Email where Id = '{UserId}'";
            int noOfRowsAffected = connection.Execute(query, contactDetails);
            Guid AddressId = GetAddressId(UserId);
            noOfRowsAffected = noOfRowsAffected + UpdateAddressDetails(AddressId, contactDetails);
            return noOfRowsAffected == 2;
        }

    }
}
